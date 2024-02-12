using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SeaControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public TextMeshProUGUI lightIndicator;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(Sea.World);

        this.eventHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f);

    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void goHome(){

        SceneManager.LoadScene("MainMenu");

    }

}