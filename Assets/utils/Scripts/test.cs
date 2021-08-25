using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test : MonoBehaviour
{
    //private VoiceManager mvm_VoiceManager;

    //void Start() {
    //mvm_VoiceManager = FindObjectOfType<VoiceManager>();
    //}
    public void OnclickButton() {
        switch (this.gameObject.name) {
            case "Button": 
                Debug.Log("클릭");
                break;

        }       
    }
}
