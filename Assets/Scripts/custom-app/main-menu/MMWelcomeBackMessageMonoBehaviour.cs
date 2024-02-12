using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMWelcomeBackMessageMonoBehaviour : MonoBehaviour{
    
    private AudioSource audio;

    private static bool firstTime = true;

    void Start(){
        
        this.audio = GetComponent<AudioSource>();

        if (MMWelcomeBackMessageMonoBehaviour.firstTime){

            MMWelcomeBackMessageMonoBehaviour.firstTime = false;

        }

        else{

            //StartCoroutine(waiter());
            this.audio.Play();

        }

    }

    IEnumerator waiter(){

        yield return new WaitForSeconds(1);

        this.audio.Play();

    }
    
}
