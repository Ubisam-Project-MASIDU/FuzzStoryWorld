using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour{
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Click");
            SceneManager.LoadScene("0_01LanguageSelect");
        }
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnMouseDown(){
    //     Debug.Log("Click");
    //     SceneManager.LoadScene("0_01LanguageSelect");
    // }
}
