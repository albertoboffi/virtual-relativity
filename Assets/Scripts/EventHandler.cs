using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EventHandler{

    public Slider speedLightSlider;

    private World world;

    public EventHandler(World world){

        this.world = world;

    }

    /*
    // Sets initial position of the slider used to adjust the speed of light

    public setSpeedLightSlider(){

        
    }
    */

    // Sets initial position of the slider used to adjust the "bullet time"

    public void bulletTimeInit(){

        this.speedLightSlider.value = 1.0f;

    }

    /*
    public void setSpeedLight(World world, float scale_fact){


    }
    */
    
    // Changes the current bullet time scale factor

    public void setBulletTime(float scale_fact){

        Time.timeScale = scale_fact;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }
    
}