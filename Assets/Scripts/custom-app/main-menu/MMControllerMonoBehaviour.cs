using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMControllerMonoBehaviour : MonoBehaviour{

    public GameObject startMenu;

    public void play(){

        Destroy(startMenu);

    }
    
}