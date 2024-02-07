using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCSProbeObserverMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCSProbe.World.addObject(this, 35.0f);

    }

    void Update(){

        SCSProbe.World.move(this);

        SCSProbe.World.contractSpace(this);

    }

}