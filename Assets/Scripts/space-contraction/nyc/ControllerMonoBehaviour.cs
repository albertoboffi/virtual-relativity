using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public Slider bulletTimeSlider;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(NYC.World);

        this.eventHandler.speedLightInit(this.speedLightSlider, 0.4f);

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider);


    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider);

    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider);

    }

}