using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMonoBehaviour : MonoBehaviour{

    void Start(){

    }

    void Update(){

        GameObject boat_obj = GameObject.Find("Boat");
        BoatMonoBehaviour boat = boat_obj.GetComponent<BoatMonoBehaviour>();

        float boat_speed = boat.getSpeed();
        Vector3 boat_direction = boat.getDirection();
        Vector3 boat_velocity = boat_speed * boat_direction * (-1);

        this.transform.Translate(

            boat_velocity * Time.deltaTime,
            Space.World

        );
        
    }

    /*
    public float getPosition(){

        return this.transform.position.x; // x-coordinate of the position

    }
    */
}
