using UnityEngine;
using System.Collections.Generic;

public class LakeBoatMonoBehaviour : MonoBehaviour{

    public int ID;

    private int boats_count;
    private float boats_delay; // delay between each boat
    private float starting_time; // time of the boat's start of the journey

    private void setStartingPosition(){

        float start_queue = -400f; // x-coordinate of the start of the queue
        float boats_distance = 20f; // distance between each boat along the x-axis

        // boats are arranged in ascending order of their ID

        float boat_order = (this.boats_count - 1) - this.ID; 
        float x_pos = start_queue + boats_distance * boat_order;

        // set starting position

        this.transform.position = new Vector3(x_pos, -1.3f, 25f);

    }

    void Start(){

        // CONSTRUCTOR

        Lake.World.addObject(this, 30.0f, 500f);

        this.boats_count = 2;
        this.boats_delay = 7f; 
        this.starting_time = this.boats_delay * this.ID; // boats start in order of their id

        // STARTING ROUTINE

        this.setStartingPosition();

    }

    void Update(){

        // wait to start until it's your turn

        if (!Lake.World.wait(this.starting_time, this)){

            this.setStartingPosition();

        }

        // the boat reached the end of the journey

        if (this.transform.position.x >= 450f){ 

            this.setStartingPosition();
            this.starting_time += this.boats_delay * this.boats_count;

        }

    }

}