using UnityEngine;
using System.Collections.Generic;

public class LakeCameraMonoBehaviour : MonoBehaviour{

    public Camera mainCamera;

    private bool centered; // true if and only if the camera has been centered

    void Start(){

        this.centered = false;

    }

    private void centerCamera(){

        // reset the orientation of the headset
        
        float camera_orientation = this.mainCamera.transform.rotation.eulerAngles.y;
        
        this.transform.Rotate(0, - camera_orientation, 0);

        // reset the position of the camera

        Vector3 camera_position = this.mainCamera.transform.position;

        this.transform.position = new Vector3(

            this.transform.position.x - camera_position.x - 2f,
            this.transform.position.y,
            this.transform.position.z - camera_position.z + 9f

        );

    }

    void Update(){

        if (! this.centered){

            this.centerCamera();
            this.centered = true;

        }

    }

}