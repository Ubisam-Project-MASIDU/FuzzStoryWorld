/*
 * - Name : LangSelector.cs
 * - Writer : 최대준, 이병권
 * 
 * - Content :
 * 다양한 언어를 선택하는 화면에서의 표현을 구현하였다.
 * 다양한 언어를 선택하였을 때 화면에서 소리가 나게 구현했다.
 *
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 * 3) 2021-08-24 : 코드 구현 및 주석 작성
 * 
 * - Variable 
 * mr_CheckMousePosByRay        마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray이다.
 * mrch_CheckMousePosHitObj     레이져를 쏜 곳에 오브젝트가 있다면 이 hit 클래스 변수에 담긴다.                                               
 * mgo_VMController             언어가 선택되면 이 변수에 VM들 중에 선택된 언어가 로드된다.                                           
 * 
 * - Function
 * Update()                     클릭 이벤트가 발생되면, 레이져를 쏜 후에 그곳에 오브젝트가 있다면, 어떤 오브젝트인지를 switch문으로 판별하여 그에 따른 언어를 로드하게 되어 있다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 언어 선택 화면에서 선택시 판별, 로드하는 역할을 해주는 스크립트 클래스이다.
public class LangSelector : MonoBehaviour {
    private Ray mr_CheckMousePosByRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckMousePosHitObj;            // 레이져를 쏜 곳에 오브젝트가 있다면 이 hit 클래스 변수에 담긴다.
    private GameObject mgo_VMController;
    GameObject mg_SoundManager;
    public int mn_CountryIndex;
    
    // 클릭 이벤트 ( Input.GetMouseButtonDown(0))가 발생되면, 마우스 위치에 어떤 녀석이 있는지 판별한 후에, 음성 로드를 시작하게 하였다.
    void Start(){
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }
    void Update() {
        mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj)) {
             if(Input.GetMouseButtonDown(0)) {
                 switch (mrch_CheckMousePosHitObj.collider.name) {
                     case "KRImage":
                        mn_CountryIndex = 0;
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        DontDestroyOnLoad(mgo_VMController);
                        mgo_VMController.GetComponent<VoiceManager>().country = VoiceManager.Country.KR; 
                        mg_SoundManager.GetComponent<SoundManager>().playSound("Flag");                  // 국기를 눌렀을 때 효과음 재생
                        SceneManager.LoadScene("0_03Starting");
                        break;
                    case "ENImage":
                        mn_CountryIndex = 1;
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        DontDestroyOnLoad(mgo_VMController);
                        mgo_VMController.GetComponent<VoiceManager>().country = VoiceManager.Country.EN;
                        mg_SoundManager.GetComponent<SoundManager>().playSound("Flag");
                        SceneManager.LoadScene("0_03Starting");
                        break;
                    case "JPImage":
                        mn_CountryIndex = 2;
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        DontDestroyOnLoad(mgo_VMController);
                        mgo_VMController.GetComponent<VoiceManager>().country = VoiceManager.Country.JP;
                        mg_SoundManager.GetComponent<SoundManager>().playSound("Flag");
                        SceneManager.LoadScene("0_03Starting");
                        break;
                    case "CNImage":
                        mn_CountryIndex = 3;
                        mgo_VMController = transform.GetChild(0).gameObject;
                        transform.DetachChildren();
                        DontDestroyOnLoad(mgo_VMController);
                        mgo_VMController.GetComponent<VoiceManager>().country = VoiceManager.Country.CN;
                        mg_SoundManager.GetComponent<SoundManager>().playSound("Flag");
                        SceneManager.LoadScene("0_03Starting");
                        break;
                 }
             }
         }
    }
}
