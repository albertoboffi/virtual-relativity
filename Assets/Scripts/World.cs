using UnityEngine;
using System;
using System.Collections.Generic;

public class World{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    private float c; // speed of light

    private Vector3 dir_motion; // direction of motion of the objects within the world

    private Dictionary<MonoBehaviour, Dictionary<string, float>> objects; // objects inside the world

    private MeshHandler meshHandler;

    public World(float c){

        this.c = c;
        this.dir_motion = new Vector3(1, 0, 0); // movements are allowed only along the x-axis -> Axiom 4
        this.objects = new Dictionary<MonoBehaviour, Dictionary<string, float>>();
        this.meshHandler = new MeshHandler();

    }

    // Sets the speed of an object inside the world -> Axiom 3

    private void setSpeed(MonoBehaviour obj, float v){

        if (Math.Abs(v) >= Math.Abs(this.c)){ // |v| < |c| -> Axiom 6

            throw new ArgumentException("Objects must be slower than light");

        }

        this.objects[obj].Add("speed", v);

    }

    // Sets the initial scale and shift of the object

    private void setScale(MonoBehaviour obj){

        float scale_fact = 1.0f;
        float shift_fact = 0.0f;

        this.objects[obj].Add("scale_fact", scale_fact);
        this.objects[obj].Add("shift_fact", shift_fact);

    }

    // Adds object to the world -> Axioms 2 - 5

    public void addObject(MonoBehaviour obj, float v){

        this.objects.Add(

            obj,
            new Dictionary<string, float>()

        );

        this.setSpeed(obj, v);
        
        this.setScale(obj);

    }

    // Moves the object in mono-directional motion

    public void move(MonoBehaviour obj){

        float speed = this.objects[obj]["speed"];

        Vector3 velocity = speed * this.dir_motion;

        this.meshHandler.move(obj, velocity);

    }

    // Composes speeds by means of the velocity composition law

    private float getRelativeSpeed(MonoBehaviour a, MonoBehaviour b){
        
        float v_a = this.objects[a]["speed"];
        float v_b = this.objects[b]["speed"];

        float gal_term = v_b - v_a;
        float ein_term = 1 - (v_a * v_b) / Mathf.Pow(c, 2);
        
        float rel_speed = gal_term / ein_term;

        return rel_speed;

    }

    // Contracts an object relative to the observer

    private void contractObject(MonoBehaviour obs, MonoBehaviour obj){

        // get parameters

        float v = this.getRelativeSpeed(obs, obj);

        float prev_scale_fact = this.objects[obj]["scale_fact"];
        float prev_shift_fact = this.objects[obj]["shift_fact"];

        float length = this.meshHandler.getLength(obj, prev_scale_fact, this.dir_motion);

        // perform the calculation

        float scale_fact = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));
        float shift_fact = length * (1 - scale_fact) / 2;

        // contract the mesh

        this.meshHandler.scale(obj, prev_scale_fact, scale_fact, this.dir_motion);
        this.meshHandler.shift(obj, prev_shift_fact, shift_fact, this.dir_motion);

        // update scale and shift values associated to the object

        this.objects[obj]["scale_fact"] = scale_fact;
        this.objects[obj]["shift_fact"] = shift_fact;

    }

    // Implements space contraction

    public void contractSpace(MonoBehaviour obs){

        foreach(var obj in objects.Keys){

            if (obj != obs) this.contractObject(obs, obj);
        
        }

    }

    // Time dilation

    public float dilateTime(float v){

        float scale = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));

        return scale;

    }

    // Changes the speed of light (useful for user interaction)

    public void setC(float c){

        foreach(var obj in objects.Values){
            
            // |v| < |c| -> Axiom 6

            if (Math.Abs(obj["speed"]) >= c){

                throw new ArgumentException("Light must be faster than objects");

            }

        }

        this.c = c;

    }

    // Returns current speed of light

    public float getC(){

        return this.c;

    }

    // Changes the current time scale

    public void setTimeScale(float scale_fact){

        this.meshHandler.setTimeScale(scale_fact);

    }

    // Warns when a given amount of time has passed

    public bool wait(float time){

        return this.meshHandler.wait(time);

    }

}