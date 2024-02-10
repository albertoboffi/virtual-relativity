using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMWelcomeMessageMonoBehaviour : MonoBehaviour{
    
    private AudioSource audio;

    void Start(){
        
        this.audio = GetComponent<AudioSource>();

        StartCoroutine(waiter());

    }

    IEnumerator waiter(){

        yield return new WaitForSeconds(2);

        this.audio.Play();

    }
    
}
