using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TDProbeControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public TextMeshProUGUI lightIndicator;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(TDProbe.World);

        this.eventHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f);

    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

}