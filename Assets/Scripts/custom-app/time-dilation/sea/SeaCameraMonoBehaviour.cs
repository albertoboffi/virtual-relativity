using UnityEngine;
using System.Collections.Generic;

public class SeaCameraMonoBehaviour : MonoBehaviour{

    public Camera mainCamera;

    private bool centered; // true if and only if the camera has been centered
    private Vector3 offset; // amount of space the camera is shifted

    void Start(){

        this.centered = false;
        this.offset = new Vector3(0, 0, 0);

    }

    private void centerCamera(){

        // reset the orientation of the headset
        
        float camera_orientation = this.mainCamera.transform.rotation.eulerAngles.y;
        
        this.transform.Rotate(0, 90f - camera_orientation, 0);

        // reset the position of the camera

        Vector3 camera_position = this.mainCamera.transform.position;

        this.offset = new Vector3(

            camera_position.x,
            0f,
            camera_position.z

        );

        this.transform.position = new Vector3(

            this.transform.position.x - this.offset.x,
            this.transform.position.y,
            this.transform.position.z - this.offset.z

        );

    }

    void Update(){

        if (! this.centered){

            this.centerCamera();
            this.centered = true;

        }

    }

    public Vector3 getOffset(){

        return this.offset;

    }

}