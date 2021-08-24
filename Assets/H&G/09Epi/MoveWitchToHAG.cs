/*
 * - Name : MoveHansel.class
 * - Writer : 유희수
 * - Content : 헨젤과그레텔 Epi3 - 스토리 진행 후, 미니게임 시작해주는 스크립트
 *  
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-17 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mg_Hansel                    헨젤 오브젝트 연결을 위한 변수
 * mv3_TargetPoint              헨젤을 이동시킬 목표 지점
 * mg_PopUp                     미니게임 시작을 위한 팝업창
 *  
 * <Function>
 * v_NextScene                  다음 씬으로 넘겨주는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveWitchToHAG : MonoBehaviour
{
    private GameObject mg_Witch;
    private Vector3 mv3_TargetPoint;
    //public GameObject mg_PopUp;

    void Start()
    {
        mv3_TargetPoint = new Vector3(7.2f, 5.8f, -9f);                                                       //헨젤을 이동시킬 목표지점 설정
        mg_Witch = GameObject.Find("witch");                                                                    //변수에 오브젝트 연결
        //mg_PopUp.SetActive(false);                                                                                //팝업창 비활성화
    }

    void Update()
    {
        mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_TargetPoint, 0.08f); //현재 오브젝트가 mv3_TargetPoint위치로 0.07f의 속력으로 가는 함수
        Debug.Log("첫번째 스크립트");
        //Invoke("v_NextScene", 5f);
    }

    public void v_NextScene()
    {
        //mg_PopUp.SetActive(true);
        SceneManager.LoadScene("1_03H&G_Game");
    }
}