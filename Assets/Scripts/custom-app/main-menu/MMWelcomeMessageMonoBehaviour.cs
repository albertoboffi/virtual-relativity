using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMWelcomeMessageMonoBehaviour : MonoBehaviour{
    
    private AudioSource audio;

    private static bool firstTime = true;

    private bool active;

    void Start(){
        
        this.audio = GetComponent<AudioSource>();

        this.active = true;

        if (MMWelcomeMessageMonoBehaviour.firstTime){

            StartCoroutine(waiter());

            MMWelcomeMessageMonoBehaviour.firstTime = false;

        }

    }

    IEnumerator waiter(){

        yield return new WaitForSeconds(2);

        if (this.active){

            this.audio.Play();

        }

    }

    // If the user clicks play before the audio starts, I don't want the audio to be played

    public void cancel(){

        this.active = false;

    }
    
}
