using UnityEngine;
using System;
using System.Collections.Generic;

public class MeshHandler{

    public void move(MonoBehaviour obj, Vector3 velocity){

        obj.transform.Translate(
            
            velocity * Time.deltaTime,
            Space.World

        );

    }

    public float getLength(MonoBehaviour obj, Vector3 direction){

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;

        float length = Vector3.Dot(size, direction); // the dot product keeps only the size along the direction of motion

        return length;

    }

    public void scale(MonoBehaviour obj, float scale_fact, Vector3 direction){

        Vector3 local_dir = obj.transform.InverseTransformDirection(direction); // scale is done in local coordinates, so the direction must be converted

        Vector3 scale_vec = (local_dir * (scale_fact - 1)) + 1; // create the scale vector based on the local direction

        obj.transform.localScale = Vector3.Scale(
        
            obj.transform.localScale,
            scale_vec

        );

    }

    public void shift(MonoBehaviour obj, float shift_fact, Vector3 direction){

        Vector3 adjustment = shift_fact * direction * (-1); // the shift is in the opposite direction to the motion
        
        obj.transform.Translate(
            
            adjustment,
            Space.World
        
        );

    }


}