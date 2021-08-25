using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour{
    //private bool mb_checkClick = false;
    void Update(){
        // if (Input.GetMouseButtonDown(0)){
        //     //mb_checkClick = true;
        //     Debug.Log("Click");
            
        // }
    }
    void OnMouseDown(){
        Debug.Log("Click");
    }
    // void OnTriggerEnter2D(Collider2D cCollidObj){
    //     if(cCollidObj.tag == "헨젤과그레텔"){
    //         SceneManager.LoadScene("0_01LanguageSelect");
    //     }
    // }
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
