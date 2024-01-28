using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public Slider bulletTimeSlider;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler();

        this.eventHandler.speedLightInit(this.speedLightSlider, 0.4f, NYC.World);

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider);


    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, NYC.World);

    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider);

    }

}