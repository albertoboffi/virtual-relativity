using UnityEngine;
using System.Collections.Generic;

public class SeaBoatMonoBehaviour: MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        Sea.World.addObject(this, 35.0f);

    }

    void Update(){

        Sea.World.move(this);

        Sea.World.dilateTime(this);

    }

    

}