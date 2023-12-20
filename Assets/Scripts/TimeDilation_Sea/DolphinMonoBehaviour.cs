using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DolphinMonoBehaviour : MonoBehaviour{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    Vector3 start_vel;
    Vector3 start_pos;
    float g = 9.8f; // gravity

    float t = 0; // time since the beginning of the animation

    float depth = -3; // depth of the dolphin under the sea surface

    void Start(){
        
        this.start_vel = new Vector3(3.0f, 2.0f, 0);
        this.start_pos = this.transform.position;

        this.t = 0;

        this.transform.position = new Vector3(0, this.depth, -5);

        this.setSlowMotion();

    }

    void Update(){
        
        this.t += Time.deltaTime; // update time

        // POSITION

        float x = start_pos.x + start_vel.x * t;
        float y = start_pos.y + start_vel.y * t - 0.5f * g  * (float)Math.Pow(t, 2);

        this.transform.position = new Vector3(x, y, -5);

        // VELOCITY

        float vx = start_vel.x;
        float vy = start_vel.y - this.g * t;

        float angle_sensitivity = 0.7f; // ho much the trajectory influences the angle of the dolphin (1 = the dolphin follows the direction of the trajectory)

        float dir_angle = - (float)Math.Atan2(vy, vx); // angle of the vector tangent to the trajectory in radians
        dir_angle = dir_angle * 180 / (float)Math.PI; // conversion in degrees
        dir_angle *= angle_sensitivity; // applying sensitivity

        this.transform.eulerAngles = new Vector3(dir_angle, 90, 0);

        // RESTART MOTION

        if (y < this.depth) this.t = 0;

    }

    public void setSlowMotion(float timescale){

        Time.timeScale = timescale;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }
}
