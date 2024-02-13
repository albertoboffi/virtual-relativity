using UnityEngine;
using System.Collections.Generic;

public class NYCCarMonoBehaviour : MonoBehaviour{

    public int ID;

    private int cars_count;
    private float cars_delay; // delay between each car
    private float starting_time; // time of the car's start of the journey

    private void setStartingPosition(){

        float start_queue = 154.0f; // x-coordinate of the start of the queue
        float cars_distance = 9.5f; // distance between each car along the x-axis

        // cars are arranged in ascending order of their ID

        float car_order = (this.cars_count - 1) - this.ID; 
        float x_pos = start_queue + cars_distance * car_order;

        // set starting position

        this.transform.position = new Vector3(x_pos, 40.3f, -54.5f);

    }

    void Start(){

        // CONSTRUCTOR

        NYC.World.addObject(this, 35.0f);

        this.cars_count = 7;
        this.cars_delay = 5.0f; 
        this.starting_time = this.cars_delay * this.ID; // cars start in order of their id

        // STARTING ROUTINE

        this.setStartingPosition();

    }

    void Update(){

        if (!NYC.World.wait(this.starting_time, this)){ // wait to start until it's your turn

            this.setStartingPosition();

        }

        if (this.transform.position.x >= 890f){ // the car reached the end of the journey

            this.setStartingPosition();
            this.starting_time += this.cars_delay * this.cars_count;

        }

    }

}