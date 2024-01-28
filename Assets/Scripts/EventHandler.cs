using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EventHandler{

    // SPEEDS ARE EXPRESSED IN [km/h]

    // Parameters for adjusting the speed of light

    private float c0_perc; // initial percentage of the slider used to adjust the speed of light

    // exponential function parameters
    private float exp_a;
    private float exp_b;

    // linear function parameter
    private float lin_m; // angular coefficient

    // Sets initial position of the slider used to adjust the speed of light

    public void speedLightInit(Slider speed_light_slider, float position, World world){

        this.c0_perc = position;

        speed_light_slider.value = this.c0_perc;

        float c0 = world.getC();

        // sets linear function parameter

        this.lin_m = c0 / this.c0_perc;

        // sets exponential function parameters

        const float real_c = 1079252848.8f; 

        this.exp_b = Mathf.Pow((real_c / c0), (1 / (1 - this.c0_perc)));
        this.exp_a = real_c / this.exp_b;

    }
    

    // Sets initial position of the slider used to adjust the "bullet time"

    public void bulletTimeInit(Slider bullet_time_slider){

        bullet_time_slider.value = 1.0f;

    }

    
    // Changes the current speed of light

    public void setSpeedLight(Slider speed_light_slider, World world){

        float scale_fact = speed_light_slider.value;
        float c;

        // linear function

        if (scale_fact <= this.c0_perc){

            c = this.lin_m * scale_fact;

        }

        // exponential function

        else{

            c = this.exp_a * Mathf.Pow(this.exp_b, scale_fact);

        }

        world.setC(c);

    }
    
    
    // Changes the current bullet time

    public void setBulletTime(Slider bullet_time_slider){

        float scale_fact = bullet_time_slider.value;

        Time.timeScale = scale_fact;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }
    
}