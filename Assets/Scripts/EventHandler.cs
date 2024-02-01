using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    // Sets the value of the speed of light indicator

    private void setSpeedLightIndicator(TextMeshProUGUI light_indicator, float val){

        // int light_speed_val = (int) Math.Ceiling(val);
        int light_speed_val = (int) val;

        light_indicator.text = "Light Speed: " + light_speed_val + " km/h";

    }


    // Sets the value of the time flow rate indicator

    private void setTimeFlowRateIndicator(TextMeshProUGUI time_indicator, float val){

        time_indicator.text = "Time Flow Rate: " + val.ToString("F1");

    }

    // Sets initial position of the slider used to adjust the speed of light

    public void speedLightInit(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position, float v_max){

        // calculates c_min and c_max

        float k = 0.01f;

        float c_min = v_max + 0.1f;
        float c_max = Mathf.Sqrt(Mathf.Pow(v_max, 2) / (2 * k + Mathf.Pow(k, 2)));

        this.c0_perc = position;

        float c0 = this.world.getC();

        // sets linear function parameter

        this.lin_m = (c0 - c_min) / this.c0_perc;
        this.lin_q = c_min;

        // sets exponential function parameters

        this.exp_b = Mathf.Pow((c_max / c0), (1 / (1 - this.c0_perc)));
        this.exp_a = c_max / this.exp_b;

        // sets the correct position on the slider

        speed_light_slider.value = this.c0_perc;

        // sets the corresponding speed indicator

        this.setSpeedLightIndicator(light_indicator, c0);

    }
    

    // Sets initial position of the slider used to adjust the "bullet time"

    public void bulletTimeInit(Slider bullet_time_slider, TextMeshProUGUI time_indicator){

        float scale_fact0 = 1.0f;

        // sets the correct position on the slider

        bullet_time_slider.value = scale_fact0;

        // sets the corresponding time indicator

        this.setTimeFlowRateIndicator(time_indicator, scale_fact0);

    }

    
    // Changes the current speed of light

    public void setSpeedLight(Slider speed_light_slider, TextMeshProUGUI light_indicator){

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

        // sets the corresponding speed indicator

        this.setSpeedLightIndicator(light_indicator, c);

    }
    
    
    // Changes the current bullet time

    public void setBulletTime(Slider bullet_time_slider, TextMeshProUGUI time_indicator){

        float scale_fact = bullet_time_slider.value;

        this.world.setTimeScale(scale_fact);

        // Time.timeScale = scale_fact;
        // Time.fixedDeltaTime = Time.timeScale * .02f;

        // sets the corresponding time indicator

        this.setTimeFlowRateIndicator(time_indicator, scale_fact);

    }
    
}