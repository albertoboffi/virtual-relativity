using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TDProbeObserverMonoBehaviour : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        TDProbe.World.addObject(this, 0f);

    }

    void Update(){

            TDProbe.World.dilateTime(this);

    }

}