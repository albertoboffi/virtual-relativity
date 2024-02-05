using UnityEngine;
using System.Collections.Generic;

public class ParallelepipedMonoBehaviour : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        SCProbe.World.addObject(this, 35.0f);

    }

    void Update(){

        SCProbe.World.move(this);

    }

}