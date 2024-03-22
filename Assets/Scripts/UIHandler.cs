using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class UIHandler{

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

    public UIHandler(World world){

        this.world = world;

    }

    // Sets the value of the speed of light indicator

    private void setSpeedLightIndicator(TextMeshProUGUI light_indicator, float val){

        // string light_speed_val = ((int) Math.Ceiling(val)).ToString();
        string light_speed_val = ((int) val).ToString();

        // pass to scientific notation if the value is too big

        int max_char = 4; // max number of characters
        int light_speed_len = light_speed_val.Length;

        if (light_speed_len > max_char){

            string coefficient = light_speed_val.Substring(0, max_char - 2);
            int exponent = light_speed_len - max_char + 2;

            light_speed_val = coefficient + "E" + exponent;

        }

        light_indicator.text = "Light Speed: " + light_speed_val + " km/h";

    }


    // Sets the value of the time flow rate indicator

    private void setTimeFlowRateIndicator(TextMeshProUGUI time_indicator, float val){

        time_indicator.text = "Time Flow Rate: " + val.ToString("F1");

    }


    // Sets the value of the speed of light slider and calculates the associated functions

    private void setSpeedLightSlider(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position, float c_min, float c_max){

        this.c0_perc = position;

        float c0 = this.world.getC();

        if (c0 < c_min || c0 > c_max){ // the speed of light set by the user is out of range

            // sets the initial speed of light to the 20% of the spectrum

            c0 = (c_max - c_min) * 0.2f;
            this.world.setC(c0);

        }

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

    // Initiates the slider used to adjust the speed of light

    public void speedLightInit(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position){

        // get maximum speed

        float v_max = this.world.getMaxV();

        // calculates c_min and c_max

        float k = 0.01f;

        float c_min = v_max + 0.1f;
        float c_max = Mathf.Sqrt(Mathf.Pow(v_max, 2) / (2 * k + Mathf.Pow(k, 2)));

        // sets the slider

        this.setSpeedLightSlider(speed_light_slider, light_indicator, position, c_min, c_max);

    }

    // Initiates the slider used to adjust the speed of light in case of the Doppler effect

    public void dopEffSpeedLightInit(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position, float v_min, float w_min, float w_max){

        // get maximum speed

        float v_max = this.world.getMaxV();

        // visible spectrum

        float w_vis_min = 380f;
        float w_vis_max = 780f;

        // calculates c_min in case of toward motion

        float v = v_max;
        float w = w_min;

        float c_min_tow =   (1 + Mathf.Pow((w_vis_min / w_min), 2)) * v_max /
                            (1 - Mathf.Pow((w_vis_min / w_min), 2));

        // calculates c_min in case of away motion

        float c_min_awa =   (Mathf.Pow((w_vis_max / w_max), 2) + 1) * v_min /
                            (Mathf.Pow((w_vis_max / w_max), 2) - 1);

        // calculates the overall minimum c

        float c_min = Mathf.Max(c_min_tow, c_min_awa);

        // sets the maximum c

        float c_max = 1079252848.8f; // real speed of light

        // sets the slider

        this.setSpeedLightSlider(speed_light_slider, light_indicator, position, c_min, c_max);

    }
    

    // Initiates the slider used to adjust the "bullet time"

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

    // Activates / deactivates the Doppler effect

    public void toggleDopplerEffect(){

        this.world.toggleDopplerEffect();

    }

    // Unified method for the space contraction control

    public void setSpaceContractionUI(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position, Slider bullet_time_slider, TextMeshProUGUI time_indicator){    

        this.speedLightInit(speed_light_slider, light_indicator, position);
        this.bulletTimeInit(bullet_time_slider, time_indicator);

    }

    // Unified method for the time dilation control

    public void setTimeDilationUI(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position){

        speedLightInit(speed_light_slider, light_indicator, position);

    }

    // Unified method for the doppler effect control

    public void setDopplerEffectUI(Slider speed_light_slider, TextMeshProUGUI light_indicator, float position, float v_min, float w_min, float w_max, Slider bullet_time_slider, TextMeshProUGUI time_indicator){    

        this.dopEffSpeedLightInit(speed_light_slider, light_indicator, position, v_min, w_min, w_max);
        this.bulletTimeInit(bullet_time_slider, time_indicator);

    }
    
}