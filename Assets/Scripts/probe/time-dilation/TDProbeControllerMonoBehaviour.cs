using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TDProbeControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public TextMeshProUGUI lightIndicator;

    private UIHandler uiHandler;

    void Start(){

        // CONSTRUCTOR

        this.uiHandler = new UIHandler(TDProbe.World);

        this.uiHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f);

    }

    public void setSpeedLight(){

        this.uiHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

}