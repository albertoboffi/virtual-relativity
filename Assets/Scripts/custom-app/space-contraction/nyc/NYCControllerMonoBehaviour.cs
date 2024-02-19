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

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(NYC.World);

        this.eventHandler.speedLightInit(this.speedLightSlider, this.lightIndicator, 0.4f, 35.0f);

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider, this.timeIndicator);


    }

    public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider, this.timeIndicator);

    }

    public void goHome(){

        NYC.World.reset();
        SceneManager.LoadScene("MainMenu");

    }

}