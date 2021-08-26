using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour{
    public void PlayClickSound(){
        GameObject SoundManager = GameObject.Find("SoundManager");
        SoundManager.GetComponent<SoundManager>().playSound("Click");
    }
}
