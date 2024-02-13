using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TDProbeObserverMonoBehaviour : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, 35f);

    }

    void Update(){

            TDProbe.World.move(this);

            TDProbe.World.dilateTime(this);

    }

}