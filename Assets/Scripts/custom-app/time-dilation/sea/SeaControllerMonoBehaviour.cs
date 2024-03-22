using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SeaControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public TextMeshProUGUI lightIndicator;

    private UIHandler uiHandler;

    void Start(){

        // CONSTRUCTOR

        this.uiHandler = new UIHandler(Sea.World);

        this.uiHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f);

    }

    public void setSpeedLight(){

        this.uiHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void goHome(){

        Sea.World.reset();
        SceneManager.LoadScene("MainMenu");

    }

}