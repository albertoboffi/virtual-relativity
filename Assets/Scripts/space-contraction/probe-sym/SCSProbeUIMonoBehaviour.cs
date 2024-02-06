using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCSProbeUIMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCSProbe.World.addObject(this, 35.0f);

    }

    void Update(){

        SCSProbe.World.move(this);

    }

}