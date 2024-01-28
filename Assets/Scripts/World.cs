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

    // Adds object to the world -> Axioms 2 - 5

    public void addObject(MonoBehaviour obj, float v){

        this.objects.Add(

            obj,
            new Dictionary<string, float>()

        );

        this.setSpeed(obj, v);

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

    // Implements space contraction

    public void contractSpace(MonoBehaviour obs, MonoBehaviour obj){

        // get parameters

        float v = this.getRelativeSpeed(obs, obj);
        float length = this.meshHandler.getLength(obj, this.dir_motion);

        // perform the calculation

        float scale_fact = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));
        float shift_fact = length * (1 - scale_fact) / 2;

        // contract the mesh

        this.meshHandler.scale(obj, scale_fact, this.dir_motion);
        this.meshHandler.shift(obj, shift_fact, this.dir_motion);

    }

    // Time dilation

    public float dilateTime(float v){

        float scale = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));

        return scale;

    }

}