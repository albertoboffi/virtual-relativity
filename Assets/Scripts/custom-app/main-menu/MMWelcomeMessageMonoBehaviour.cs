using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMWelcomeMessageMonoBehaviour : MonoBehaviour{
    
    private AudioSource audio;

    private static bool firstTime = true;

    void Start(){
        
        this.audio = GetComponent<AudioSource>();

        if (MMWelcomeMessageMonoBehaviour.firstTime){

            StartCoroutine(waiter());

            MMWelcomeMessageMonoBehaviour.firstTime = false;

        }

    }

    IEnumerator waiter(){

        yield return new WaitForSeconds(2);

        this.audio.Play();

    }
    
}
