using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonsStickSound : MonoBehaviour {

    public AudioClip Givebone2Witch;

    AudioSource audioSource;

    void Awake(){
        this.audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(string action){
        switch(action){
            case "GIVE":
            audioSource.clip =  Givebone2Witch;
            break;
        }
        audioSource.Play();
    }

}
