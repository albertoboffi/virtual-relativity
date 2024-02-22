using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MMControllerMonoBehaviour : MonoBehaviour{

    public GameObject startMenu; // first step of the UI
    public List<GameObject> previews; // second step of the UI

    public GameObject nycTeleportButton;
    public GameObject seaTeleportButton;

    private static bool firstTime = true;

    private void showPreview(GameObject preview){

        preview.SetActive(true);

    }

    public void play(){

        Destroy(startMenu); // hides the first step of the UI

        foreach(GameObject preview in this.previews){ // shows the second step of the UI

            this.showPreview(preview);

        }

    }

    private void setLoading(GameObject button_obj){

        Button button = button_obj.GetComponent<Button>();

        button.interactable = false; // disable the button

        TextMeshProUGUI button_text = button.GetComponentInChildren<TextMeshProUGUI>();
        button_text.text = "Loading...";

    }

    public void teleportToNYC(){

        this.setLoading(this.nycTeleportButton);

        SceneManager.LoadSceneAsync("SpaceContraction_NYC");

    }

    public void teleportToSea(){

        this.setLoading(this.seaTeleportButton);

        SceneManager.LoadSceneAsync("TimeDilation_Sea");

    }

    void Start(){

        if (MMControllerMonoBehaviour.firstTime){

            MMControllerMonoBehaviour.firstTime = false;

        }

        else{

            this.play();

        }

    }
    
}