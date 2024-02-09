using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DEProbeObserverMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        DEProbe.World.addObject(this, 0.0f); // approximation of the observer as static

    }

    void Update(){

            DEProbe.World.applyDoppler(this);

    }

}