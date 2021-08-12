using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LangSelector : MonoBehaviour {
    private Ray mr_CheckMousePosByRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckMousePosHitObj;            // 레이져를 쏜 곳에 오브젝트가 있다면 이 hit 클래스 변수에 담긴다.
    private GameObject mgo_VMController;
    // Update is called once per frame
    void Update() {
        mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj)) {
             if(Input.GetMouseButtonDown(0)) {
                 switch (mrch_CheckMousePosHitObj.collider.name) {
                     case "KRImage": 
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        mgo_VMController.SetActive(true);
                        mgo_VMController.GetComponent<VMController>().SetCountry(VMController.Country.KR);
                        break;
                    case "ENImage": 
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        mgo_VMController.SetActive(true);
                        mgo_VMController.GetComponent<VMController>().SetCountry(VMController.Country.EN);
                        break;
                    case "JPImage": 
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        mgo_VMController.SetActive(true);
                        mgo_VMController.GetComponent<VMController>().SetCountry(VMController.Country.JP);
                        break;
                    case "CNImage": 
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        mgo_VMController.SetActive(true);
                        mgo_VMController.GetComponent<VMController>().SetCountry(VMController.Country.CN);
                        break;
                 }
             }
         }
        
        if (mgo_VMController != null) {
            if (mgo_VMController.GetComponent<VMController>().mb_CheckLanguageReady) {
                SceneManager.LoadScene("0_03Starting");
            }
        }
    }
}
