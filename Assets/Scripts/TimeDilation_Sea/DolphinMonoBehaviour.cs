using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DolphinMonoBehaviour : MonoBehaviour{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    public GameObject boatObj;

    Vector3 start_vel;
    Vector3 start_pos;
    float g = 9.8f; // gravity

    float t = 0; // time since the beginning of the animation

    float depth = -4; // depth of the dolphin under the sea surface
    bool jumpMov = false; // if true the dolphin is jumping, if false it's under the sea surface
    float waitingTime = 2; // time the dolphin remains under the sea surface before jumping

    private void resetTime(){

        this.t = 0;
        this.jumpMov = !this.jumpMov;

    }

    private void jump(){

        // POSITION

        float x = this.start_pos.x + this.start_vel.x * t;
        float y = this.start_pos.y + this.start_vel.y * t - 0.5f * g  * (float)Math.Pow(t, 2);
        float z = this.start_pos.z;

        this.transform.position = new Vector3(x, y, z);

        // VELOCITY

        float vx = Math.Abs(this.start_vel.x);
        float vy = this.start_vel.y - this.g * t;

        float angle_sensitivity = 0.7f; // ho much the trajectory influences the angle of the dolphin (1 = the dolphin follows the direction of the trajectory)

        float dir_angle = - (float)Math.Atan2(vy, vx); // angle of the vector tangent to the trajectory in radians
        dir_angle = dir_angle * 180 / (float)Math.PI; // conversion in degrees
        dir_angle *= angle_sensitivity; // applying sensitivity

        this.transform.eulerAngles = new Vector3(dir_angle, 90, 0);

        if (y < depth) this.resetTime();

    }

    private void wait(){

        if (this.t >= this.waitingTime) this.resetTime();

    }

    public DolphinMonoBehaviour(){

        this.start_vel = new Vector3(-12.0f, 11.0f, 0);

    }

    void Start(){
        
        Vector3 current_position = this.transform.position;
        current_position.y = this.depth;
        this.start_pos = current_position;
        this.transform.position = current_position;

        this.t = 0;

    }

    void Update(){
        
        this.t += Time.deltaTime; // update time

        if (jumpMov) this.jump();
        else this.wait();

    }

    public void setSlowMotion(float timescale){

        Time.timeScale = timescale;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }

    public float getSpeed(){

        BoatMonoBehaviour boat = this.boatObj.GetComponent<BoatMonoBehaviour>();
        float dolphin_speed = boat.getSpeed() + this.start_vel.x;

        return dolphin_speed;

    }
}
