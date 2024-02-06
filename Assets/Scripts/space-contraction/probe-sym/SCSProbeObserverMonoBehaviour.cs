using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCSProbeObserverMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCSProbe.World.addObject(this, 0.0f);

    }

    void Update(){

        SCSProbe.World.contractSpace(this);

    }

}