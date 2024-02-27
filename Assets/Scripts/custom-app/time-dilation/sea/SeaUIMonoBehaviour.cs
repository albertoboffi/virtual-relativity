using UnityEngine;
using System.Collections.Generic;

public class SeaUIMonoBehaviour : MonoBehaviour{

    public GameObject camera;

    void Update(){

        Vector3 camera_position = this.camera.transform.position;

        SeaCameraMonoBehaviour camera_script = this.camera.GetComponent<SeaCameraMonoBehaviour>();

        Vector3 camera_offset = camera_script.getOffset(); // amount of space the main camera is shifted inside the XR ring
        
        Vector3 ui_position = new Vector3(

            camera_position.x + 0.65f,
            1f,
            camera_position.z

        );

        this.transform.position = ui_position + camera_offset;

    }

}