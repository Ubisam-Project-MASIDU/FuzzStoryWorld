/*
 * - Name : MatchPuzzles.class
 * - Writer : 유희수
 *          : 이병권
 * - Content : 헨젤과그레텔 Epi2 미니게임 - 각각의 퍼즐 조각이 맞는 위치에 들어갔는지 확인하고, 틀리면 제자리로 돌아가게 해주는 스크립트
 *                                           1) 퍼즐을 들었을 때 소리가 난다.
 *                                           2) 퍼즐을 맞쳤을 때 소리가 난다.
 *                                           3) 퍼즐을 틀렸을 때 소리가 난다. 
 * - HISTORY
 * 2021-08-11 : 초기 개발
 * 2021-08-12 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mgo_GameControl              "AnswerCheckEpi2" 스크립트 연결을 위한 변수
 * mv3_initPos;                 현재 위치 저장을 위한 변수
 *
 * <Function>
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchPuzzles : MonoBehaviour{
    private GameObject mgo_GameControl;                                                                             //AnswerCheckEpi2 스크립트 연결을 위한 변수
    Vector3 mv3_initPos;                                                                                            //현재 위치 저장을 위한 변수
    GameObject mg_SoundManager;
    void Start(){
        mv3_initPos = this.transform.position;                                                                      //현재 위치 저장 
        mg_SoundManager = GameObject.Find("SoundManager");          // 사운드 매니저 게임오브젝트 연결
        mgo_GameControl = GameObject.Find("GameControl");                                                           //오브젝트 연결     
    }

    void Update(){
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 8f * Time.deltaTime);   //현재 오브젝트가 mv3_initPos위치로 8f의 속력으로 가는 함수
    }

    //퍼즐조각이 맞는 위치로 가면 그 위치의 밑그림을 보여주고, 해당 퍼즐조각은 사라지게 해주는 함수
    //오브젝트들의 태그로 검사
    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetMouseButtonUp(0))
        {                                                                             //화면에서 마우스 클릭을 떼면
            if (col.tag == this.tag)
            {   
                mg_SoundManager.GetComponent<SoundManager>().playSound("Put");                                                           //충돌체의 태그와 현재 오브젝트(퍼즐조각)의 태그가 같다면
                col.gameObject.SetActive(false);                                                                    //충돌체 비활성화
                Destroy(this.gameObject);                                                                          //현재 오브젝트 없애기  
                mgo_GameControl.GetComponent<CheckAnswerEpi2>().v_CountAnswer();                                     //정답 개수를 올려주기 위한 함수 실행
            }
        }
    }
 
 
}
