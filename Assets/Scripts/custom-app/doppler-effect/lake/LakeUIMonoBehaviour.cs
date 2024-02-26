using UnityEngine;
using System.Collections.Generic;

public class LakeUIMonoBehaviour : MonoBehaviour{

    public GameObject camera;

    void Update(){

        Vector3 camera_position = this.camera.transform.position;

        LakeCameraMonoBehaviour camera_script = this.camera.GetComponent<LakeCameraMonoBehaviour>();

        Vector3 camera_offset = camera_script.getOffset(); // amount of space the main camera is shifted inside the XR ring

        Vector3 ui_position = new Vector3(

            camera_position.x,
            1.2f,
            camera_position.z + 0.5f

        );

        this.transform.position = ui_position + camera_offset;

    }

}