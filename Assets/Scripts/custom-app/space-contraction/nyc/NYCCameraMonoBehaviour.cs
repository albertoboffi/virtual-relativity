using UnityEngine;
using System.Collections.Generic;

public class NYCCameraMonoBehaviour : MonoBehaviour{

    public Camera mainCamera;

    private bool centered; // true if and only if the camera has been centered

    void Start(){

        this.centered = false;

    }

    private void centerCamera(){

        // reset the orientation of the headset
        
        float camera_orientation = this.mainCamera.transform.rotation.eulerAngles.y;
        
        this.transform.Rotate(0, - camera_orientation, 0);

        // reset the position of the headset

        Vector3 camera_position = this.mainCamera.transform.position;

        this.transform.position = new Vector3(

            - camera_position.x,
            this.transform.position.y,
            - camera_position.z

        );

    }

    void Update(){

        if (! this.centered){

            this.centerCamera();
            this.centered = true;

        }

    }


}