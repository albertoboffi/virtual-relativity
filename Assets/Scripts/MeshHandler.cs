using UnityEngine;
using System;
using System.Collections.Generic;

public class MeshHandler{

    // Parameters for time management

    private float timeScale; // current scale of the time (useful for the slow motion effect)
    private float waitingTime; // current amount of time the component is waiting in case "wait" is called
    private MonoBehaviour? waitLock; // only the first object acquire the lock to change the waiting time

    public MeshHandler(){

        this.timeScale = 1.0f;
        this.waitingTime = 0.0f;
        this.waitLock = null;

    }

    // Changes the current time scale

    public void setTimeScale(float scale_fact){

        this.timeScale = scale_fact;

    }

    // Returns the delta time with respect to the time scale factor

    private float getDeltaTime(){

        float delta_time = Time.deltaTime * this.timeScale;

        return delta_time;

    }

    // Warns when a given amount of time has passed

    public bool wait(float time, MonoBehaviour obj){

        if (this.waitLock == null){ // the lock has not been acquired yet

            this.waitLock = obj;

        }

        if (this.waitLock == obj){ // only the object that acquires the lock change the waiting time

            this.waitingTime += this.getDeltaTime();

        }

        if (this.waitingTime < time){

            return false;

        }

        else{

            return true;

        }

    }

    // Moves a mesh by the provided velocity

    public void move(MonoBehaviour obj, Vector3 velocity){

        obj.transform.Translate(
            
            velocity * this.getDeltaTime(),
            Space.World

        );

    }

    // Returns the position of an obect along a direction

    public float getPosition(MonoBehaviour obj, Vector3 direction){

        // the dot product keeps only the size along the given direction
        float position = Vector3.Dot(obj.transform.position, direction);

        return position;

    }

    // Returns the length of a mesh along a direction

    public float getLength(MonoBehaviour obj, float prev_scale_fact, Vector3 direction){

        MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;

        float length = Vector3.Dot(size, direction); // the dot product keeps only the size along the given direction

        float orig_length = length / prev_scale_fact;

        return orig_length;

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

    // Tells if an object is in front of the other along a direction

    public bool isInFront(MonoBehaviour obj_a, MonoBehaviour obj_b, Vector3 direction){

        float pos_a = this.getPosition(obj_a, direction);
        float pos_b = this.getPosition(obj_b, direction);

        if (pos_a > pos_b) return true;
        return false;

    }

    // Converts a light wavelength to RGB

    private (int r, int g, int b) getColorfromWavelength(float wavelength){

        float gamma = 0.8f;
        float max_intensity = 255f;

        float r_temp, g_temp, b_temp;

        if ((wavelength >= 380) && (wavelength < 440)){

            r_temp = - (wavelength - 440) / (440 - 380);
            g_temp = 0f;
            b_temp = 1f;

        }

        else if ((wavelength >= 440) && (wavelength < 490)){

            r_temp = 0f;
            g_temp = (wavelength - 440) / (490 - 440);
            b_temp = 1f;
        }

        else if ((wavelength >= 490) && (wavelength < 510)){

            r_temp = 0f;
            g_temp = 1f;
            b_temp = - (wavelength - 510) / (510 - 490);

        }

        else if ((wavelength >= 510) && (wavelength < 580)){

            r_temp = (wavelength - 510) / (580 - 510);
            g_temp = 1f;
            b_temp = 0f;

        }

        else if ((wavelength >= 580) && (wavelength < 645)){

            r_temp = 1f;
            g_temp = - (wavelength - 645) / (645 - 580);
            b_temp = 0f;

        }

        else if ((wavelength >= 645) && (wavelength < 781)){

            r_temp = 1f;
            g_temp = 0f;
            b_temp = 0f;

        }

        else{ // out of the visible spectrum!

            r_temp = 0f;
            g_temp = 0f;
            b_temp = 0f;

        }

        // restrict intensity inside vision bounds

        float factor;

        if ((wavelength >= 380) && (wavelength < 420)){

            factor = 0.3f + 0.7f * (wavelength - 380) / (420 - 380);

        }

        else if ((wavelength >= 420) && (wavelength < 701)){

            factor = 1f;
        
        }

        else if ((wavelength >= 701) && (wavelength < 781)){

            factor = 0.3f + 0.7f * (780 - wavelength) / (780 - 700);

        }
        
        else{

            factor = 0f;
        }

        // construct final RGB color

        int r, g, b;

        if (r_temp == 0f){

            r = 0;

        }

        else{

            r = (int) Mathf.Round(max_intensity * Mathf.Pow(r_temp * factor, gamma));

        }

        if (g_temp == 0f){

            g = 0;

        }

        else{

            g = (int) Mathf.Round(max_intensity * Mathf.Pow(g_temp * factor, gamma));

        }

        if (b_temp == 0f){

            b = 0;

        }
        
        else{

            b = (int) Mathf.Round(max_intensity * Mathf.Pow(b_temp * factor, gamma));

        }

        return (r, g, b);

    }

    // Changes the color of an object

    public void changeColor(MonoBehaviour obj, float wavelength){

        // get the color associated to the wavelength

        (int r, int g, int b) = this.getColorfromWavelength(wavelength);

        // get the material representing the main color of a mesh

        MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();

        Material material;
        MeshRenderer renderer;

        float main_material_count = 0; // number of main material composing the object

        for (int i = 0; i < renderers.Length; i ++){

            renderer = renderers[i];

            material = Array.Find(

                renderer.materials,
                item => (item.name.StartsWith("_MM"))
            
            );

            if (material != null){

                // apply the color to the material

                material.SetColor(
                    
                    "_Color",
                    new Color32((byte) r, (byte) g, (byte) b, 255)

                );

                main_material_count ++;

            }

        }

        if (main_material_count == 0){

            throw new InvalidOperationException("The object does not have a main material to apply Doppler effect.");

        }

    }

}