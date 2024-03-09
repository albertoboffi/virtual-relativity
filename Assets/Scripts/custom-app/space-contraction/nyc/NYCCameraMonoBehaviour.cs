using UnityEngine;
using System.Collections.Generic;

public class NYCCameraMonoBehaviour : MonoBehaviour{

    public Camera mainCamera;

    private bool centered; // true if and only if the camera has been centered
    private Vector3 offset; // amount of space the camera is shifted

    void Start(){

        this.centered = false;
        this.offset = new Vector3(0, 0, 0);

    }

    private void centerCamera(){

        // reset the orientation of the headset
        
        //float camera_orientation = this.mainCamera.transform.rotation.eulerAngles.y;
        
        //this.transform.Rotate(0, - camera_orientation, 0);

        // reset the position of the camera

        Vector3 camera_position = this.mainCamera.transform.position;

        this.offset = new Vector3(

            camera_position.x - 530f,
            0f,
            camera_position.z + 63f

        );

        this.transform.position = new Vector3(

            this.transform.position.x - this.offset.x,
            this.transform.position.y,
            this.transform.position.z - this.offset.z

        );

    }

    private void constraintMovement(){

        // boundaries

        float x_min =  154f - this.offset.x;
        float x_max =  890f - this.offset.x;
        float z_min = -63.2f - this.offset.z;
        float z_max = -51f - this.offset.z;

        // actual position

        float x = this.transform.position.x;
        float z = this.transform.position.z;

        // control over the boundary constraints

        bool out_of_boundaries = false;

        // eventually adjust the position

        if (x >= x_max){
        
            x = x_max;
            out_of_boundaries = true;
        
        }
        else if (x <= x_min){
        
            x = x_min;
            out_of_boundaries = true;
        
        }

        if (z >= z_max){

            z = z_max;
            out_of_boundaries = true;

        }

        else if (z <= z_min){
        
            z = z_min;
            out_of_boundaries = true;
        
        }

        // set the position

        if (out_of_boundaries){

            this.transform.position = new Vector3(x, this.transform.position.y, z);

        }

    }

    void Update(){

        if (! this.centered){

            this.centerCamera();
            this.centered = true;

        }

        this.constraintMovement();

    }

    public Vector3 getOffset(){

        return this.offset;

    }

}