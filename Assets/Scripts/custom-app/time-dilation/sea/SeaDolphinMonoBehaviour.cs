using UnityEngine;
using System;
using System.Collections.Generic;

public class SeaDolphinMonoBehaviour : MonoBehaviour{

    private Vector3 p0; // starting position
    private Vector3 v0; // starting velocity

    private float depth; // depth of the dolphin under the sea surface

    // TIME MANAGEMENT

    // Since the wait method and the event timing belong to two distinct time management mechanism, we need two distinct definitions
    private float t; // time of the event showing time dilation (dolphin jump)
    private float _t; // time destined to the wait method

    // For the wait method, we need to properties that are thus related to _t and NOT to t
    private float jumpDelay; // interval between each jump
    private float jumpStartTime; // instant in which the dolphin must jump

    void Start(){

        // CONSTRUCTOR

        Sea.World.addObject(this, 0f);

        this.depth = -3f;

        this.p0 = new Vector3(

            this.transform.position.x,
            this.depth,
            this.transform.position.z

        );

        this.v0 = new Vector3(-35f, 9f, 0f);

        this.t = 0f;
        this._t = 0f;

        this.jumpDelay = 2f;
        this.jumpStartTime = this._t + this.jumpDelay;

        // STARTING ROUTINE        

        this.transform.position = this.p0; // FIX the position of the dolphin

    }

    // changes the position of the dolphin along the jump trajectory
    // returns true if and only if the jump is over

    private bool jump(){

        float g = 9.8f; // gravity

        // POSITION

        float x = this.transform.position.x;
        float y = this.p0.y + this.v0.y * this.t - 0.5f * g * Mathf.Pow(this.t, 2);
        float z = this.p0.z;

        this.transform.position = new Vector3(x, y, z);

        // VELOCITY

        float vx = Math.Abs(this.v0.x);
        float vy = this.v0.y - g * this.t;

        // INCLINATION

        float angle_sensitivity = 0.7f; // how much the trajectory influences the angle of the dolphin (1 = the dolphin follows the direction of the trajectory)

        float dir_angle = // angle of the vector tangent to the trajectory

            - Mathf.Atan2(vy, vx) // angle in radians
            * 180 / Mathf.PI // conversion in degrees
            * angle_sensitivity; // applying sensitivity
        
        this.transform.eulerAngles = new Vector3(dir_angle, 90, 0);

        // JUMP STATUS

        if (y < this.depth) return true;
        return false;

    }

    void Update(){

        bool is_jump_over = false;

        if (Sea.World.wait(this.jumpStartTime, this)){

            this.t += Sea.World.getDeltaTime(this);

            is_jump_over = this.jump();

        }

        this._t += Time.deltaTime;

        if (is_jump_over){

            this.t = 0;
            this.jumpStartTime = this._t + this.jumpDelay;
            this.transform.position = this.p0;

        }

    }

}