using UnityEngine;
using System;
using System.Collections.Generic;

public class DolphinMonoBehaviour : DolphinMonoBehaviour{
    
    private Vector3 p0; // starting position
    private Vector3 v0; // starting velocity

    private float depth; // depth of the dolphin under the sea surface

    void Start(){

        float speed = -5; // since the sea is moving, the dolphin moves beackward

        Sea.World.addObject(this, speed);

        this.depth = -4f;

        this.transform.position.y = this.depth; // adjust the position of the dolphin

        this.p0 = this.transform.position;
        this.v0 = new Vector3(speed, 9f, 0f);

    }

    void Update(){



    }

}