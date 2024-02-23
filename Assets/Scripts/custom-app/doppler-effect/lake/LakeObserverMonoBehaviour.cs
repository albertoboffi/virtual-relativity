using UnityEngine;
using System.Collections.Generic;

public class LakeObserverMonoBehaviour : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        Lake.World.addObject(this, 0.0f); // approximation of the observer as static

    }

    void Update(){

        Lake.World.move(this);

        Lake.World.applyDoppler(this);

    }

}