using UnityEngine;
using System.Collections.Generic;

public class TDCubeMonoBehaviour : MonoBehaviour{

    private Vector3 direction; // direction of motion
    private float speed;

    private float startingHeight;
    private float endingHeight;

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, -35f); // since the plane is moving, the cube moves backwards

        this.direction = new Vector3(0, 1, 0); // the cube moves upwards at the beginning
        this.speed = 5f;

        this.startingHeight = 0.6f;
        this.endingHeight = 10f;

        // STARTING ROUTINE

        this.transform.position = new Vector3(

            this.transform.position.x,
            this.startingHeight,
            this.transform.position.z

        );

    }

    void Update(){

        TDProbe.World.move(this);

        // check for possible change in direction needed

        float direction_y = this.direction.y;
        float position_y = this.transform.position.y;

        bool change_dir_cond =  (direction_y == 1) && (position_y >= this.endingHeight) ||
                                (direction_y == -1) && (position_y <= this.startingHeight);

        if (change_dir_cond) this.direction *= -1; // invert the direction of motion

        // move the cube

        Vector3 velocity = this.speed * this.direction;

        this.transform.Translate(
            
            velocity * TDProbe.World.getDeltaTime(this),
            Space.World

        );

    }

}