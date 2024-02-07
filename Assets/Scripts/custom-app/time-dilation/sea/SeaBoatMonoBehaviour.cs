using UnityEngine;
using System.Collections.Generic;

public class SeaBoatMonoBehaviour: MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        Sea.World.addObject(this, 0.0f); // for a simplified management, we move the sea

    }

    void Update(){

        Sea.World.dilateTime(this);

    }

    

}