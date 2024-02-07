using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuControllerMonoBehaviour : MonoBehaviour{
    
    void Start(){}

    public void selectScene(){

        switch (this.gameObject.name){

            case "NYC_Scene_Controller":
            
                SceneManager.LoadScene("SpaceContraction_NYC");
                break;

            case "Sea_Scene_Controller":
            
                SceneManager.LoadScene("TimeDilation_Sea");
                break;

        }

    }

}
