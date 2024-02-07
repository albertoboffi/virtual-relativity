using UnityEngine;
using System.Collections.Generic;

public class SCProbeParallelepipedMonoBehaviour : MonoBehaviour{

    private float extr_pos; // position of the extreme of the journey, in absolute value

    private void setStartingPosition(){

        this.transform.position = new Vector3(-this.extr_pos, 0.6f, 5f);

    }

    void Start(){

        // CONSTRUCTOR

        SCProbe.World.addObject(this, 35.0f);

        this.extr_pos = 190f;

        // STARTING ROUTINE

        this.setStartingPosition();

    }

    void Update(){

        SCProbe.World.move(this);

        if (this.transform.position.x >= this.extr_pos){

            this.setStartingPosition();            

        }

    }

}