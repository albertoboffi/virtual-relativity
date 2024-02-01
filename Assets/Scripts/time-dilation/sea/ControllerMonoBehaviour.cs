using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public TextMeshProUGUI lightIndicator;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(Sea.World);

        this.eventHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 20.0f);

    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

}