using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DEProbeControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public Slider bulletTimeSlider;

    public TextMeshProUGUI lightIndicator;
    public TextMeshProUGUI timeIndicator;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(DEProbe.World);

        this.eventHandler.DopEffSpeedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f, 35.0f, 513f, 513f);

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider, this.timeIndicator);        

    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider, this.timeIndicator);

    }

}