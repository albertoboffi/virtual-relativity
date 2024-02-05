using UnityEngine;
using System.Collections.Generic;

public class TDProbePlaneMonoBehaviour : MonoBehaviour{

    private float extr_pos; // position of the extreme of the journey, in absolute value

    private void setStartingPosition(){

        this.transform.position = new Vector3(this.extr_pos, 0f, 1f);

    }

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, -35f); // for a simplified management, the plane moves

        this.extr_pos = 190f;

        // STARTING ROUTINE

        this.setStartingPosition();

    }

    void Update(){

        TDProbe.World.move(this);

        if (this.transform.position.x <= (-this.extr_pos)){

            this.setStartingPosition();            

        }

    }

}