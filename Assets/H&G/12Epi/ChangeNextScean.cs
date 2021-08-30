/*
 * - Name : ChangeNextScean.cs
 * - Writer : 이예은, 이병권
 * 
 * - Content :
 *  헨젤과 그레텔이 보물섬에 가까워지면 다음 게임창이 뜬다. 
 *  start창을 누르면 다음 게임으로 넘어간다.
 *
 * - HISTORY
 * 1) 2021-08-12 : 초기 개발
 * 2) 2021-08-13 : 개발 수정
 * 3) 2021-08-24 : 게임건너뛰기 분기점 지정 (김명현)
 * 4) 2021-08-26 : 빵을 먹으면 소리가 나게 한다(이병권)
 * 5) 2021-08-30 : 주석 수정
 *
 * - Variable 
 * mgo_HAG                                     헨젤과 그레텔 게임 오브젝트
 * 
 * <Function>
 * void OnclickButton()                        버튼을 클릭하면 다음씬으로 넘어가는 함수
 * void ChangeNextScene()                      다음 씬으로 넘어가는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Epi12에서 나오는 다음씬으로 넘어가는 스크립트
public class ChangeNextScean : MonoBehaviour
{
    //  없애기 위해 필요한 변수들
    public GameObject mgo_HAG;

    // 헨젤과 그레텔이 보물섬에 가까워지면
    // minigame창이 뜬다.
    void Update() {
        if(mgo_HAG.transform.position.x > 210) {
            GameObject go_UI = GameObject.Find("UI");
            go_UI.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
    // 버튼을 클릭하면 다음 씬으로 넘어간다.
    public void OnclickButton() {
        ChangeNextScene();
    }
    // epi13으로 넘어가는 함수
    void ChangeNextScene() {
        SceneManager.LoadScene("1_13H&G");
    }

}
