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
            camera_position.z + 0.6f

        );

        this.transform.position = ui_position + camera_offset;

    }

}

/****************************************

We attempted to rotate the UI according to the viewer movements as well. Unfortunately, the results were too confusing.

using UnityEngine;
using System.Collections.Generic;

public class LakeUIMonoBehaviour : MonoBehaviour{

    public GameObject camera;

    float last_rotation;

    void Start(){

        this.last_rotation = 0f;

    }

    void Update(){

        // get camera localization parameters

        Vector3 camera_position = this.camera.transform.position;

        float camera_orientation = this.camera.transform.rotation.eulerAngles.y;

        // set camera rotation

        this.transform.Rotate(
        
            0f,
            camera_orientation - this.last_rotation,
            0f

        );

        this.last_rotation = camera_orientation;

        // set camera position

        LakeCameraMonoBehaviour camera_script = this.camera.GetComponent<//LakeCameraMonoBehaviour>();
        Vector3 camera_offset = camera_script.getOffset(); // amount of space the main camera is shifted inside the XR ring

        float camera_distance = 0.6f;
        float x_offset =    camera_distance * Mathf.Sin(camera_orientation * Mathf.Deg2Rad) +
                            camera_offset.x;

        float z_offset =    camera_distance * Mathf.Cos(camera_orientation * Mathf.Deg2Rad) +
                            camera_offset.z;

        this.transform.position = new Vector3(

            camera_position.x + x_offset,
            1.2f,
            camera_position.z + z_offset

        );

    }

}

****************************************/