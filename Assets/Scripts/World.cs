using UnityEngine;

public class World{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    // Speed of light
    private float c;

    public World(){

        this.c = 40.0f;

    }

    // Velocity composition law
    public float getRelativeSpeed(float v_a, float v_b){
        
        float gal_term = v_b - v_a;
        float ein_term = 1 - (v_a * v_b) / Mathf.Pow(c, 2);
        
        return gal_term / ein_term;

    }

}