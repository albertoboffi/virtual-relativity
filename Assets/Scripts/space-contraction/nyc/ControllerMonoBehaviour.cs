using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMonoBehaviour : MonoBehaviour{

    public Slider bulletTimeSlider;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler();

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider);


    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider);

    }

}