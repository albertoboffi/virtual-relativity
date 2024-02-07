using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCProbeObserverMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCProbe.World.addObject(this, 0.0f); // approximation of the observer as static

    }

    void Update(){

            SCProbe.World.contractSpace(this);
            SCProbe.World.applyDoppler(this);

    }

}