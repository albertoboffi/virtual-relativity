using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMonoBehaviour : MonoBehaviour{

    // SPEEDS ARE EXPRESSED IN [km/h]

    private int carsCount;

    // Car's information

    public int ID; // id of each individual car

    private float speed; // speed relative to the world
    private Vector3 direction; // direction of motion
    private float waitingTime; // car current waiting time before start

    private void setStartingPosition(){

        float start_queue = 154.0f; // x-coordinate of the start of the queue
        float cars_distance = 9.5f; // distance between each car along the x-axis

        float car_order = (this.carsCount - 1) - this.ID; // cars are arrenged in ascending order of their ID

        float x_pos = start_queue + cars_distance * car_order; // cars are ordered by their id

        this.transform.position = new Vector3(x_pos, 40, -54.5f);

    }

    void Start(){
        
        this.carsCount = 7;

        this.speed = 35.0f;
        this.direction = new Vector3(1, 0, 0); // cars move along the x-direction in the world space
        this.waitingTime = 0.0f;

        setStartingPosition();

    }

    void Update(){

        float cars_delay = 3.0f; // delay between each car
        float starting_time = cars_delay * this.ID; // cars start in order of their id

        Vector3 velocity = this.speed * this.direction;

        if (this.waitingTime < starting_time){ // wait to start until it's your turn

            this.waitingTime += Time.deltaTime;

        }

        else{   // move when it's your turn

            this.transform.Translate(velocity * Time.deltaTime, Space.World);

        }
        
    }
}
