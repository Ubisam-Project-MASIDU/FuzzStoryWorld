using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayScene12 : MonoBehaviour {
    private Ray mr_CheckMousePosByRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckMousePosHitObj;            // 레이져를 쏜 곳에 오브젝트가 

    // Update is called once per frame
    public void OnClicked() {
        SceneManager.LoadScene("1_12H&G");
    }

    void OnTriggerEnter(Collider cCollider) {
        SceneManager.LoadScene("1_13H&G");
    }
}
