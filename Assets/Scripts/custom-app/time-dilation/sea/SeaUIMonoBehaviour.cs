using UnityEngine;
using System.Collections.Generic;

public class SeaUIMonoBehaviour : MonoBehaviour{

    public GameObject camera;

    void Update(){

        Vector3 camera_position = this.camera.transform.position;
        
        Vector3 ui_position = new Vector3(

            camera_position.x + 0.65f,
            1f,
            camera_position.z

        );

        this.transform.position = ui_position;

    }

}