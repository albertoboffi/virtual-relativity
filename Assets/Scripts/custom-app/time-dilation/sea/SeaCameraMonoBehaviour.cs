using UnityEngine;
using System.Collections.Generic;

public class SeaCameraMonoBehaviour : MonoBehaviour{

    public Camera mainCamera;

    private bool centered; // true if and only if the camera has been centered

    void Start(){

        this.centered = false;

    }

    private void centerCamera(){

        // reset the orientation of the headset
        
        float camera_orientation = this.mainCamera.transform.rotation.eulerAngles.y;
        
        this.transform.Rotate(0, - camera_orientation, 0);

    }

    void Update(){

        if (! this.centered){

            this.centerCamera();
            this.centered = true;

        }

    }

}