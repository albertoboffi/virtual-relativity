using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMonoBehaviour : MonoBehaviour{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    public List<GameObject> dolphinsObj;

    private float speed; // speed relative to the world
    private Vector3 direction; // direction of motion

    private World world;

    private void dilateDolphinTime(DolphinMonoBehaviour dolphin){

        float boat_speed = this.world.getRelativeSpeed(
        
            this.speed,
            dolphin.getSpeed()
        
        );

        var dilation_factor = this.world.dilateTime(boat_speed);

        Debug.Log(dilation_factor);

        dolphin.setSlowMotion(dilation_factor);

    }

    public BoatMonoBehaviour(){

        this.speed = 20.0f;
        this.direction = new Vector3(1, 0, 0); // the boar move along the x-direction in the world space

        this.world = new World(25.0f);

    }

    void Start(){

        DolphinMonoBehaviour dolphin;
        
        foreach (GameObject dolphin_obj in this.dolphinsObj){

            dolphin = dolphin_obj.GetComponent<DolphinMonoBehaviour>();
            this.dilateDolphinTime(dolphin);
            
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
