/*
 * - Name : Start_Epi8_Game.class
 * - Writer : 이윤교
 * - Content : 헨젤과그레텔 Epi8 _ Epi8 미니게임 시작 스크립트
 * 
 * - HISTORY
 * 2021-08-09 : 초기 개발 및 코드 획일화, 주석처리
 * 2021-08-06 : 코드 획일화 및 주석처리
 * 2021-08-20 : 헨젤과 그레텔 이동 코드 수정
 *
 * <Variable>
 * mgo_Gratel : 그레텔 게임오브젝트
 * mgo_Hansel : 헨젤 게임오브젝트
 * mgo_Target : 문 위치 게임오브젝트
 * mv3_HanselPosition : 헨젤 목표 위치 벡터화
 * mv3_GratelPosition : 그레텔 목표 위치 벡터화
 * <Function>
 * ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity) : go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
 * NextScene() : 다음씬으로 이동.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Start_Epi8_Game : MonoBehaviour
{
    //헨젤과 그레텔 이동에 필요한 변수들
    private GameObject mgo_Gratel;
    private GameObject mgo_Hansel;
    private Vector3 mv3_HanselPosition;
    private Vector3 mv3_GratelPosition;
    void Start(){
        mgo_Gratel = GameObject.Find("Gratel");
        mgo_Hansel = GameObject.Find("Hansel");

        mv3_HanselPosition = GameObject.Find("HanselPos").transform.position;                // 헨젤 목표 위치 
        mv3_GratelPosition = GameObject.Find("GratelPos").transform.position;                // 그레텔 목표 위치 
    }

    // Update is called once per frame
    void Update(){   
        ChangePosition(mgo_Hansel,mv3_HanselPosition,1.0f);                                  // 헨젤 이동
        ChangePosition(mgo_Gratel,mv3_GratelPosition,1.0f);                                  // 그레텔 이동
    }

    //go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
    void ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity){
        go_Object.transform.position = Vector3.MoveTowards(go_Object.transform.position,v3_Pos,f_Velocity * Time.deltaTime);
    }
}
