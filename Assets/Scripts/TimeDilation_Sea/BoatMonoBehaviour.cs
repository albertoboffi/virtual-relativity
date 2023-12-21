using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMonoBehaviour : MonoBehaviour{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    public GameObject seaObj;
    public List<GameObject> dolphins;

    private World world;

    private float speed; // speed relative to the world
    private Vector3 direction; // direction of motion

    public BoatMonoBehaviour(){

        this.world = new World(25.0f);

        this.speed = 20.0f;
        this.direction = new Vector3(1, 0, 0); // the boar move along the x-direction in the world space

    }

    void Start(){

        DolphinMonoBehaviour dolphin;
        SeaMonoBehaviour sea = this.seaObj.GetComponent<SeaMonoBehaviour>();
        
        float boat_speed = this.world.getRelativeSpeed(
        
            this.speed,
            sea.getSpeed()
        
        );

        var dilation_factor = this.world.dilateTime(boat_speed);

        foreach (GameObject dolphin_obj in this.dolphins){

            dolphin = dolphin_obj.GetComponent<DolphinMonoBehaviour>();
            dolphin.setSlowMotion(dilation_factor);

        }


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
