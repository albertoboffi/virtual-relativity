using UnityEngine;
using System.Collections.Generic;

public class TDCubeMonoBehaviour : MonoBehaviour{

    private Vector3 direction; // direction of motion
    private float speed;

    private float startingHeight;
    private float endingHeight;

    private void setStartingPosition(){

        this.transform.position = new Vector3(

            this.transform.position.x,
            this.startingHeight,
            this.transform.position.z

        );

    }

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, 0f);

        this.direction = new Vector3(0, 1, 0); // the cube moves upwards
        this.speed = 5f;

        this.startingHeight = 0.6f;
        this.endingHeight = 10f;

    }

    void Update(){

        // check if the movement must be restarted

        if (this.transform.position.y >= this.endingHeight){

            this.setStartingPosition();

        }

        // move the cube

        Vector3 velocity = this.speed * this.direction;

        this.transform.Translate(
            
            velocity * TDProbe.World.getDeltaTime(this),
            Space.World

        );

    }

}