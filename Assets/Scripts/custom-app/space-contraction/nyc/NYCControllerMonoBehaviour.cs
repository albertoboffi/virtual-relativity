using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NYCControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public Slider bulletTimeSlider;

    public TextMeshProUGUI lightIndicator;
    public TextMeshProUGUI timeIndicator;

    private UIHandler uiHandler;

    void Start(){

        // CONSTRUCTOR

        this.uiHandler = new UIHandler(NYC.World);

        this.uiHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f);

        this.uiHandler.bulletTimeInit(this.bulletTimeSlider, this.timeIndicator);


    }

    public void setSpeedLight(){

        this.uiHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void setBulletTime(){

        this.uiHandler.setBulletTime(this.bulletTimeSlider, this.timeIndicator);

    }

    public void goHome(){

        NYC.World.reset();
        SceneManager.LoadScene("MainMenu");

    }

}