using UnityEngine;
using System.Collections.Generic;

public class TDProbePlaneMonoBehaviour : MonoBehaviour{

    private float extr_pos; // position of the extreme of the journey, in absolute value

    private void setStartingPosition(){

        this.transform.position = new Vector3(this.extr_pos, 0f, 1f);

    }

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, 0);

        this.extr_pos = 190f;

        // STARTING ROUTINE

        this.setStartingPosition();

    }

    void Update(){

        float boundary = - this.extr_pos / 2; // position of the plane where it needs to be restarted

        if (this.transform.position.x <= boundary){

            this.setStartingPosition();            

        }

    }

}