using UnityEngine;
using System;

public class World{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    private float c; // speed of light

    Dictionary<GameObject, Dictionary<string, float>> objects; // objects inside the world

    public World(float c){

        this.c = c;
        this.objects = new Dictionary<GameObject, Dictionary<string, float>>();

    }

    // Adds object to the world -> Axioms 2 - 4

    public void addObject(GameObject obj){

        this.objects.Add(
            obj,
            new Dictionary<string, float>
        );

    }

    // Set the speed of an object inside the world -> Axiom 3

    public void setSpeed(GameObject obj, float v){

        if (Math.Abs(v) >= Math.Abs(this.c)){ // |v| < |c| -> Axiom 5

            throw new ArgumentException("Objects must be slower than light");

        }

        this.objects[obj].Add("v", v);

    }

    // Velocity composition law

    public float getRelativeSpeed(float v_a, float v_b){
        
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