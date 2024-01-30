using UnityEngine;
using System;
using System.Collections.Generic;

public class MeshHandler{

    // Parameters for time management

    private float timeScale; // current scale of the time (useful for the slow motion effect)
    private float waitingTime; // current amount of time the component is waiting in case "wait" is called

    public MeshHandler(){

        this.timeScale = 1.0f;
        this.waitingTime = 0.0f;

    }

    // Changes the current time scale

    public void setTimeScale(float scale_fact){

        this.timeScale = scale_fact;

    }

    // Returns the delta time with respect to the time scale factor

    private float getDeltaTime(){

        float delta_time = Time.deltaTime * this.timeScale;

        return delta_time;

    }

    // Warns when a given amount of time has passed

    public bool wait(float time){

        if (this.waitingTime < time){

            this.waitingTime += this.getDeltaTime();

            return false;

        }

        else{

            return true;

        }

    }

    // Moves a mesh by the provided velocity

    public void move(MonoBehaviour obj, Vector3 velocity){

        obj.transform.Translate(
            
            velocity * this.getDeltaTime(),
            Space.World

        );

    }

    // Returns the length of a mesh along a direction

    public float getLength(MonoBehaviour obj, Vector3 direction){

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;

        float length = Vector3.Dot(size, direction); // the dot product keeps only the size along the given direction

        return length;

    }

    // Scales the mesh along a direction

    public void scale(MonoBehaviour obj, float prev_scale_fact, float scale_fact, Vector3 direction){

        // scale is done in local coordinates, so the direction must be converted

        Vector3 local_dir = obj.transform.InverseTransformDirection(direction);

        // creates the scale vectors based on the local direction

        Vector3 prev_scale_vec = (local_dir * (prev_scale_fact - 1)) + new Vector3(1, 1, 1);

        Vector3 scale_vec = (local_dir * (scale_fact - 1)) + new Vector3(1, 1, 1);

        // gets original scale of the object

        Vector3 orig_scale = Vector3.Scale(

            obj.transform.localScale,
            new Vector3 (
                
                1 / prev_scale_vec.x,
                1 / prev_scale_vec.y,
                1 / prev_scale_vec.z
                
            )

        );

        // scales the object

        obj.transform.localScale = Vector3.Scale(
        
            orig_scale,
            scale_vec

        );

    }

    // Shifts a mesh along a direction

    public void shift(MonoBehaviour obj, float prev_shift_fact, float shift_fact, Vector3 direction){

        Vector3 adjustment = (prev_shift_fact - shift_fact) * direction; // the shift is in the opposite direction to the motion
        
        obj.transform.Translate(
            
            adjustment,
            Space.World
        
        );

    }


}