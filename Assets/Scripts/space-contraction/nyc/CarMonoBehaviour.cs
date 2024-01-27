using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class CarMonoBehaviour : MonoBehaviour{

    public int ID;

    private float waitingTime;

    void Start(){

        // CONSTRUCTOR

        NYC.World.addObject(this);
        NYC.World.setSpeed(this, 35.0f);

        this.waitingTime = 0.0f;

        // STARTING ROUTINE

        int cars_count = 7;

        float start_queue = 154.0f; // x-coordinate of the start of the queue
        float cars_distance = 9.5f; // distance between each car along the x-axis

        // cars are arranged in ascending order of their ID

        float car_order = (cars_count - 1) - this.ID; 
        float x_pos = start_queue + cars_distance * car_order;

        // set starting position

        this.transform.position = new Vector3(x_pos, 40.3f, -54.5f);

    }

    void Update(){

        float cars_delay = 6.0f; // delay between each car
        float starting_time = cars_delay * this.ID; // cars start in order of their id

        if (this.waitingTime < starting_time) this.waitingTime += Time.deltaTime; // wait to start until it's your turn
        else NYC.World.move(this);


    }

}