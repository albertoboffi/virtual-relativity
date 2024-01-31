using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObserverMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        NYC.World.addObject(this, 0.0f); // approximation of the observer as static

    }

    void Update(){

            NYC.World.contractSpace(this);

    }

}
