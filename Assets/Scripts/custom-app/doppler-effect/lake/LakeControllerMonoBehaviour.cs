using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LakeControllerMonoBehaviour : MonoBehaviour{

    public Slider speedLightSlider;
    public Slider bulletTimeSlider;

    public TextMeshProUGUI lightIndicator;
    public TextMeshProUGUI timeIndicator;

    private EventHandler eventHandler;

    void Start(){

        // CONSTRUCTOR

        this.eventHandler = new EventHandler(Lake.World);

        this.eventHandler.DopEffSpeedLightInit(this.speedLightSlider, this.lightIndicator, 0.5f, 35.0f, 35.0f, 513f, 513f);

        this.eventHandler.bulletTimeInit(this.bulletTimeSlider, this.timeIndicator);

    }

     public void setSpeedLight(){

        this.eventHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void setBulletTime(){

        this.eventHandler.setBulletTime(this.bulletTimeSlider, this.timeIndicator);

    }

    public void toggleDopplerEffect(){

        this.eventHandler.toggleDopplerEffect();

    }

    public void goHome(){

        Lake.World.reset();
        SceneManager.LoadScene("MainMenu");

    }

}