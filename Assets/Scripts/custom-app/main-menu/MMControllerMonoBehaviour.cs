using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMControllerMonoBehaviour : MonoBehaviour{

    public GameObject startMenu; // first step of the UI
    public List<GameObject> previews; // second step of the UI

    private void showPreview(GameObject preview){

        preview.SetActive(true);

    }

    public void play(){

        Destroy(startMenu); // hides the first step of the UI

        foreach(GameObject preview in previews){ // shows the second step of the UI

            this.showPreview(preview);

        }

    }

    public void teleportToNYC(){

        SceneManager.LoadScene("SpaceContraction_NYC");

    }

    public void teleportToSea(){

        SceneManager.LoadScene("TimeDilation_Sea");

    }
    
}