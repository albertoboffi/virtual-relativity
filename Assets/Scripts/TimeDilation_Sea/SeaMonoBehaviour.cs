using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonoBehaviour : MonoBehaviour{

    // SPEEDS ARE EXPRESSED IN [km/h]

    public GameObject boatObj;

    private float speed;

    public SeaMonoBehaviour(){

        this.speed = 0.0f;

    }

    void Start(){

    }

    void Update(){

        BoatMonoBehaviour boat = this.boatObj.GetComponent<BoatMonoBehaviour>();

        float boat_speed = boat.getSpeed();
        Vector3 boat_direction = boat.getDirection();
        Vector3 boat_velocity = boat_speed * boat_direction * (-1);

        this.transform.Translate(

            boat_velocity * Time.deltaTime,
            Space.World

        );
        
    }

    public float getSpeed(){

        return this.speed;

    }
    
}
