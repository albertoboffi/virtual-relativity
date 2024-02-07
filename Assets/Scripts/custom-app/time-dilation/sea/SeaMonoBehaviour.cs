using UnityEngine;
using System.Collections.Generic;

public class SeaMonoBehaviour : MonoBehaviour{

    void Start(){

        // CONSTRUCTOR

        Sea.World.addObject(this, -35f); // for a simplified management, we move the sea

    }

    void Update(){

        Sea.World.move(this);

    }

}