using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMonoBehaviour : MonoBehaviour{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    private float speed; // speed relative to the world
    private Vector3 direction; // direction of motion

    public BoatMonoBehaviour(){

        this.speed = 20.0f;
        this.direction = new Vector3(1, 0, 0); // the boar move along the x-direction in the world space

    }

    void Start(){
        
    }

    void Update(){
        
    }

    public float getSpeed(){

        return this.speed;

    }

    public Vector3 getDirection(){

        return this.direction;

    }
}
