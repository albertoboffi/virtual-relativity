using UnityEngine;
using System;
using System.Collections.Generic;

public class MeshHandler{

    // Moves a mesh by the provided velocity

    public void move(MonoBehaviour obj, Vector3 velocity){

        obj.transform.Translate(
            
            velocity * Time.deltaTime,
            Space.World

        );

    }

    // Returns the current scale factor of a mesh along a direction

    public float getScale(MonoBehaviour obj, Vector3 direction){

        Vector3 scale = obj.transform.localScale;

        float scale_fact = Vector3.Dot(scale, direction); // the dot products keeps only the scale along the given direction

        return scale_fact;

    }

    // Returns the length of a mesh along a direction

    public float getLength(MonoBehaviour obj, Vector3 direction){

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;

        float length = Vector3.Dot(size, direction); // the dot product keeps only the size along the given direction

        return length;

    }

    // Scales the mesh along a direction

    public void scale(MonoBehaviour obj, float prev_scale_fact, float scale_fact, Vector3 direction){

        // scale is done in local coordinates, so the direction must be converted

        Vector3 local_dir = obj.transform.InverseTransformDirection(direction);

        // creates the scale vectors based on the local direction

        Vector3 prev_scale_vec = (local_dir * (prev_scale_fact - 1)) + new Vector3(1, 1, 1);

        Vector3 scale_vec = (local_dir * (scale_fact - 1)) + new Vector3(1, 1, 1);

        // gets original scale of the object

        Vector3 orig_scale = Vector3.Scale(

            obj.transform.localScale,
            new Vector3 (
                
                1 / prev_scale_vec.x,
                1 / prev_scale_vec.y,
                1 / prev_scale_vec.z
                
            )

        );

        // scales the object

        obj.transform.localScale = Vector3.Scale(
        
            orig_scale,
            scale_vec

        );

    }

    // Shifts a mesh along a direction

    public void shift(MonoBehaviour obj, float prev_shift_fact, float shift_fact, Vector3 direction){

        Vector3 adjustment = (prev_shift_fact - shift_fact) * direction; // the shift is in the opposite direction to the motion
        
        obj.transform.Translate(
            
            adjustment,
            Space.World
        
        );

    }


}