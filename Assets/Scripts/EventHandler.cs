using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class EventHandler{

    // SPEEDS ARE EXPRESSED IN [km/h]

    private World world;

    // Parameters for adjusting the speed of light

    private float c0_perc; // initial percentage of the slider used to adjust the speed of light

    // exponential function parameters

    private float exp_a;
    private float exp_b;

    // linear function parameter

    private float lin_m; // angular coefficient
    private float lin_q; // c-intercept

    public EventHandler(World world){

        this.world = world;

    }

    // Sets initial position of the slider used to adjust the speed of light

    public void speedLightInit(Slider speed_light_slider, float position, float min_c, float max_c){

        this.c0_perc = position;

        float c0 = this.world.getC();

        // sets linear function parameter

        this.lin_m = (c0 - min_c) / this.c0_perc;
        this.lin_q = min_c;

        // sets exponential function parameters

        this.exp_b = Mathf.Pow((max_c / c0), (1 / (1 - this.c0_perc)));
        this.exp_a = max_c / this.exp_b;

        // sets the correct position on the slider

        speed_light_slider.value = this.c0_perc;

    }
    

    // Sets initial position of the slider used to adjust the "bullet time"

    public void bulletTimeInit(Slider bullet_time_slider){

        bullet_time_slider.value = 1.0f;

    }

    
    // Changes the current speed of light

    public void setSpeedLight(Slider speed_light_slider){

        float scale_fact = speed_light_slider.value;
        float c;

        // linear function

        if (scale_fact <= this.c0_perc){

            c = this.lin_m * scale_fact + this.lin_q;

        }

        // exponential function

        else{

            c = this.exp_a * Mathf.Pow(this.exp_b, scale_fact);

        }

        this.world.setC(c);

    }
    
    
    // Changes the current bullet time

    public void setBulletTime(Slider bullet_time_slider){

        float scale_fact = bullet_time_slider.value;

        this.world.setTimeScale(scale_fact);

        // Time.timeScale = scale_fact;
        // Time.fixedDeltaTime = Time.timeScale * .02f;

    }
    
}