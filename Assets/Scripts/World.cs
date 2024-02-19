using UnityEngine;
using System;
using System.Collections.Generic;

public class World{
    
    // SPEEDS ARE EXPRESSED IN [km/h]

    private float user_c; // speed of light set by the user by the default

    private float c; // speed of light

    private Vector3 dir_motion; // direction of motion of the objects within the world

    private Dictionary<MonoBehaviour, Dictionary<string, float>> objects; // objects inside the world

    private MeshHandler meshHandler;

    private bool isDopplerActive; // true if the doppler effect is active in the scene, false otherwise

    private void set(float c){

        this.c = c;
        this.dir_motion = new Vector3(1, 0, 0); // movements are allowed only along the x-axis -> Axiom 4
        this.objects = new Dictionary<MonoBehaviour, Dictionary<string, float>>();
        this.meshHandler = new MeshHandler();
        this.isDopplerActive = true; // the doppler effect is active, if the user wants it can apply it

    }

    public World(float c){

        this.user_c = c;
        this.set(c);

    }

    public void reset(){

        this.set(this.user_c);

    }

    // Sets the speed of an object inside the world -> Axiom 3

    private void setSpeed(MonoBehaviour obj, float v){

        if (Math.Abs(v) >= Math.Abs(this.c)){ // |v| < |c| -> Axiom 6

            throw new ArgumentException("Objects must be slower than light");

        }

        this.objects[obj].Add("speed", v);

    }

    // Sets the initial scale and shift of the object

    private void setScale(MonoBehaviour obj){

        float scale_fact = 1.0f;
        float shift_fact = 0.0f;

        this.objects[obj].Add("scale_fact", scale_fact);
        this.objects[obj].Add("shift_fact", shift_fact);

    }

    // Sets the initial time of the object

    private void setTime(MonoBehaviour obj){

        float time_fact = 1.0f;

        this.objects[obj].Add("time_fact", time_fact);

    }

    // Sets the emitted wavelength of the object

    private void setWavelength(MonoBehaviour obj, float wavelength){

        this.objects[obj].Add("wavelength", wavelength);

    }

    // Adds object to the world -> Axioms 2 - 5

    public void addObject(MonoBehaviour obj, float v, float wavelength = 0){

        this.objects.Add(

            obj,
            new Dictionary<string, float>()

        );

        this.setSpeed(obj, v);
        this.setScale(obj);
        this.setTime(obj);
        this.setWavelength(obj, wavelength);

    }

    // Composes speeds by means of the velocity composition law

    private float getRelativeSpeed(MonoBehaviour a, MonoBehaviour b){
        
        float v_a = this.objects[a]["speed"];
        float v_b = this.objects[b]["speed"];

        float gal_term = v_b - v_a;
        float ein_term = 1 - (v_a * v_b) / Mathf.Pow(c, 2);
        
        float rel_speed = gal_term / ein_term;

        return rel_speed;

    }

    // Moves an object relative to the observer

    private void moveObject(MonoBehaviour obs, MonoBehaviour obj){

        float speed = this.getRelativeSpeed(obs, obj);

        Vector3 velocity = speed * this.dir_motion;

        this.meshHandler.move(obj, velocity);

    }

    // Implements the motion of the objects in a mono-directional motion

    public void move(MonoBehaviour obs){

        foreach(var obj in objects.Keys){

            if (obj != obs) this.moveObject(obs, obj);
        
        }

    }

    // Contracts an object relative to the observer

    private void contractObject(MonoBehaviour obs, MonoBehaviour obj){

        // get parameters

        float v = this.getRelativeSpeed(obs, obj);

        float prev_scale_fact = this.objects[obj]["scale_fact"];
        float prev_shift_fact = this.objects[obj]["shift_fact"];

        float length = this.meshHandler.getLength(obj, prev_scale_fact, this.dir_motion);

        // perform the calculation

        float scale_fact = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));
        float shift_fact = length * (1 - scale_fact) / 2;

        // checks for the contraction side

        Vector3 shift_dir = this.dir_motion;

        if (this.objects[obs]["speed"] - this.objects[obj]["speed"] > 0){

            shift_dir *= -1;

        }

        // contract the mesh

        this.meshHandler.scale(obj, prev_scale_fact, scale_fact, this.dir_motion);
        this.meshHandler.shift(obj, prev_shift_fact, shift_fact, shift_dir);

        // update scale and shift values associated to the object

        this.objects[obj]["scale_fact"] = scale_fact;
        this.objects[obj]["shift_fact"] = shift_fact;

    }

    // Implements space contraction

    public void contractSpace(MonoBehaviour obs){

        foreach(var obj in objects.Keys){

            if (obj != obs) this.contractObject(obs, obj);
        
        }

    }

    // Dilates the time of an object relative to the observer

    private void dilateObjectTime(MonoBehaviour obs, MonoBehaviour obj){

        // get relative speed

        float v = this.getRelativeSpeed(obs, obj);

        // perform the calculation

        float time_fact = Mathf.Sqrt(1 - Mathf.Pow(v, 2) / Mathf.Pow(this.c, 2));

        // update time flow rate associated to the object

        this.objects[obj]["time_fact"] = time_fact;

    }

    // Implements time dilation

    public void dilateTime(MonoBehaviour obs){

        foreach(var obj in objects.Keys){

            if (obj != obs) this.dilateObjectTime(obs, obj);
        
        }

    }

    // Returns the delta time of the object based on time dilation

    public float getDeltaTime(MonoBehaviour obj){

        float time_fact = this.objects[obj]["time_fact"];

        float delta_time = Time.deltaTime * time_fact;

        return delta_time;

    }

    // Applies Doppler effect to an object relative to the observer

    public void applyDopplerToObject(MonoBehaviour obs, MonoBehaviour obj){

        // get emitted wave length

        float _w = this.objects[obj]["wavelength"];

        if (_w == 0) return;

        // get relative speed

        float v = this.getRelativeSpeed(obs, obj);

        // calculate if the objects are moving towards or away from each other

        bool towards;

        if (this.meshHandler.isInFront(obs, obj, this.dir_motion)){

            if (v > 0)  towards = true;
            else towards = false;

        }
        else{

            if (v > 0)  towards = false;
            else towards = true;

        }

        // calculate resulting wavelength

        float w;

        if (towards){

            w = _w * Mathf.Sqrt((this.c - v) / (this.c + v));

        }

        else{

            w = _w * Mathf.Sqrt((this.c + v) / (this.c - v));

        }

        // apply the resulting wavelength to the object

        this.meshHandler.changeColor(obj, w);

    }

    // Implements the Doppler effect

    public void applyDoppler(MonoBehaviour obs){

        foreach(var obj in objects.Keys){

            if (obj != obs){
                
                if (this.isDopplerActive){ // if the doppler effect is active
                
                    this.applyDopplerToObject(obs, obj);
                
                }

                else{ // if it is not active

                    this.meshHandler.changeColor(obj, this.objects[obj]["wavelength"]); // restores the original color

                }

            }
        
        }

    }

    // Changes the speed of light (useful for user interaction)

    public void setC(float c){

        foreach(var obj in objects.Values){
            
            // |v| < |c| -> Axiom 6

            if (Math.Abs(obj["speed"]) >= c){

                throw new ArgumentException("Light must be faster than objects");

            }

        }

        this.c = c;

    }

    // Returns current speed of light

    public float getC(){

        return this.c;

    }

    // Activates / deactivates the Doppler effect

    public void toggleDopplerEffect(){

        this.isDopplerActive = !this.isDopplerActive;

    }

    // Changes the current time scale

    public void setTimeScale(float scale_fact){

        this.meshHandler.setTimeScale(scale_fact);

    }

    // Warns when a given amount of time has passed

    public bool wait(float time, MonoBehaviour obj){

        return this.meshHandler.wait(time, obj);

    }

}