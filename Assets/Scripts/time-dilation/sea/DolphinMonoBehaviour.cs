using UnityEngine;
using System;
using System.Collections.Generic;

public class DolphinMonoBehaviour : MonoBehaviour{
    
    private Vector3 p0; // starting position
    private Vector3 v0; // starting velocity

    private float depth; // depth of the dolphin under the sea surface

    void Start(){

        // CONSTRUCTOR

        float speed = -5; // since the sea is moving, the dolphin moves beackward

        Sea.World.addObject(this, speed);

        this.depth = -4f;

        this.p0 = new Vector3(

            this.transform.position.x,
            this.depth,
            this.transform.position.z

        );

        this.v0 = new Vector3(speed, 9f, 0f);

        // STARTING ROUTINE        

        this.transform.position = this.p0; // FIX the position of the dolphin

    }

    private void jump(float t){

        float g = 9.8f; // gravity

        // POSITION

        float x = this.p0.x + this.v0.x * t;
        float y = this.p0.y + this.v0.y * t - 0.5f * g * Mathf.Pow(t, 2);
        float z = this.p0.z;

        this.transform.position = new Vector3(x, y, z);

        // VELOCITY

        float vx = Math.Abs(this.v0.x);
        float vy = this.v0.y - g * t;

        // INCLINATION

        float angle_sensitivity = 0.7f; // how much the trajectory influences the angle of the dolphin (1 = the dolphin follows the direction of the trajectory)

        float dir_angle = // angle of the vector tangent to the trajectory

            - Mathf.Atan2(vy, vx) // angle in radians
            * 180 / Mathf.PI // conversion in degrees
            * angle_sensitivity; // applying sensitivity
        
        this.transform.eulerAngles = new Vector3(dir_angle, 90, 0);


    }

    void Update(){



    }

}