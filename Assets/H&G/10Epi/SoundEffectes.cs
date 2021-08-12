using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectes : MonoBehaviour
{
   public AudioClip audioAttack;

   public AudioClip audioDie;

   AudioSource audioSource;

   void Awake(){

       this.audioSource = GetComponent<AudioSource>();
   }
 
   public void PlaySound(string action) {
       switch(action) {
           case "ATTACK":
                audioSource.clip = audioAttack;
                break;
            case "DIE" :
                audioSource.clip =  audioDie;
                break;

        }
        audioSource.Play();
   }
   

}
