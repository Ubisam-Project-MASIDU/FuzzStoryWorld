using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour{
    GameObject SoundManager;
    void Start(){
        SoundManager = GameObject.Find("SoundManager");
    }
    public void First(){
        SceneManager.LoadScene("0_01LanguageSelect");
    }
    public void Second(){
        //Support.SetActive(true);
    }
    public void Third(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Fourth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Fifth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Sixth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Seventh(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Eighth(){
        //SceneManager.LoadScene("New Scene");
    }



}
