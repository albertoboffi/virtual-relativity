using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SCSProbePlaneMonoBehavior : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCSProbe.World.addObject(this, 0f);

    }

}