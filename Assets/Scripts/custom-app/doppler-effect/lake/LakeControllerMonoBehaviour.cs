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

    private UIHandler uiHandler;

    void Start(){

        // CONSTRUCTOR

        this.uiHandler = new UIHandler(Lake.World);

        this.uiHandler.DopEffSpeedLightInit(this.speedLightSlider, this.lightIndicator, 0.5f, 35.0f, 35.0f, 500f, 500f);

        this.uiHandler.bulletTimeInit(this.bulletTimeSlider, this.timeIndicator);

    }

     public void setSpeedLight(){

        this.uiHandler.setSpeedLight(this.speedLightSlider, this.lightIndicator);

    }

    public void setBulletTime(){

        this.uiHandler.setBulletTime(this.bulletTimeSlider, this.timeIndicator);

    }

    public void toggleDopplerEffect(){

        this.uiHandler.toggleDopplerEffect();

    }

    public void goHome(){

        Lake.World.reset();
        SceneManager.LoadScene("MainMenu");

    }

}