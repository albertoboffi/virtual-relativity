using UnityEngine;
using System;
using System.Collections.Generic;

public class World{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    private float c; // speed of light

    private Vector3 dir_motion; // direction of motion of the objects within the world

    private Dictionary<MonoBehaviour, Dictionary<string, float>> objects; // objects inside the world

    public World(float c){

        this.c = c;
        this.dir_motion = new Vector3(1, 0, 0); // movements are allowed only along the x-axis -> Axiom 4
        this.objects = new Dictionary<MonoBehaviour, Dictionary<string, float>>();

    }

    // Adds object to the world -> Axioms 2 - 5

    public void addObject(MonoBehaviour obj){

        this.objects.Add(

            obj,
            new Dictionary<string, float>()

        );

    }

    // Sets the speed of an object inside the world -> Axiom 3

    public void setSpeed(MonoBehaviour obj, float v){

        if (Math.Abs(v) >= Math.Abs(this.c)){ // |v| < |c| -> Axiom 6

            throw new ArgumentException("Objects must be slower than light");

        }

        this.objects[obj].Add("speed", v);

    }

    // Moves the object in mono-directional motion

    public void move(MonoBehaviour obj){

        float speed = this.objects[obj]["speed"];

        Vector3 velocity = speed * this.dir_motion;

        obj.transform.Translate(
            
            velocity * Time.deltaTime,
            Space.World

        );

    }

    // Composes speeds by means of the velocity composition law

    public float getRelativeSpeed(MonoBehaviour a, MonoBehaviour b){
        
        float v_a = this.objects[a]["speed"];
        float v_b = this.objects[b]["speed"];

        float gal_term = v_b - v_a;
        float ein_term = 1 - (v_a * v_b) / Mathf.Pow(c, 2);
        
        return gal_term / ein_term;

    }

    // Space contraction

    public (float scale, float shift) contractSpace(float v, float length){

        float scale = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));
        float shift = length * (1 - scale) / 2; // only the edge facing the direction of motion contracts

        return (scale, shift);

    }

    // Time dilation

    public float dilateTime(float v){

        float scale = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));

        return scale;

    }

}