using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeNextScean : MonoBehaviour
{
    public GameObject mgo_HAG;

    void Update() {
        if(mgo_HAG.transform.position.x > 210) {
            GameObject go_UI = GameObject.Find("UI");
            go_UI.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    public void OnclickButton() {
        ChangeNextScene();
    }

    void ChangeNextScene() {
        SceneManager.LoadScene("1_13H&G");
    }

}
