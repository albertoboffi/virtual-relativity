using UnityEngine;
using System.Collections.Generic;

public class LakeBoatMonoBehaviour : MonoBehaviour{

    private void setStartingPosition(){

        this.transform.position = new Vector3(-200f, -0.938f, 22.5f);

    }

    void Start(){

        // CONSTRUCTOR

        Lake.World.addObject(this, 35.0f, 500f);

        // STARTING ROUTINE

    }

    void Update(){

        if (this.transform.position.x >= 200f){

            this.setStartingPosition();

        }

    }

}