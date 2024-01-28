using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EventHandler{

    /*
    // Sets initial position of the slider used to adjust the speed of light

    public setSpeedLightSlider(){

        
    }
    */

    // Sets initial position of the slider used to adjust the "bullet time"

    public void bulletTimeInit(Slider bullet_time_slider){

        bullet_time_slider.value = 1.0f;

    }

    /*
    public void setSpeedLight(World world, float scale_fact){


    }
    */
    
    // Changes the current bullet time scale factor

    public void setBulletTime(Slider bullet_time_slider){

        float scale_fact = bullet_time_slider.value;

        Time.timeScale = scale_fact;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }
    
}