using UnityEngine;
using System.Collections.Generic;

public class SeaMonoBehaviour : MonoBehaviour{

    private bool isDuplicated;

    void Start(){

        // CONSTRUCTOR

        Sea.World.addObject(this, 0f);

        this.isDuplicated = false;

    }

    void Update(){

        float length = 10000f; // length of the sea surface

        Vector3 displacement = new Vector3(length, 0, 0);

        if ((this.transform.position.x < 0f) && (!this.isDuplicated)){

            GameObject duplicate = Instantiate(gameObject);
            duplicate.transform.position += displacement;

            this.isDuplicated = true;

        }

        if (this.transform.position.x < (-length)){

            Destroy(gameObject);

        }

    }

}