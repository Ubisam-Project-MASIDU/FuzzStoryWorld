/*
 * - Name : Start_Epi8_Game.class
 * - Writer : 이윤교
 * - Content : 헨젤과그레텔 Epi8 _ Epi8 미니게임 시작 스크립트
 * 
 * - HISTORY
 * 2021-08-09 : 초기 개발 및 코드 획일화, 주석처리
 * 2021-08-06 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mgo_Gratel : 그레텔 게임오브젝트
 * mgo_Hansel : 헨젤 게임오브젝트
 * mgo_Target : 문 위치 게임오브젝트
 * mv3_Position : 문 위치 벡터화
 * <Function>
 * ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity) : go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Epi8_Game : MonoBehaviour
{
    //헨젤과 그레텔 이동에 필요한 변수들
    private GameObject mgo_Gratel;
    private GameObject mgo_Hansel;
    private GameObject mgo_Target;
    private Vector3 mv3_Position;

    VoiceManager vm;

    // Start is called before the first frame update
    void Start()
    {
        mgo_Gratel = GameObject.Find("Gratel");
        mgo_Hansel = GameObject.Find("Hansel");
        mgo_Target = GameObject.Find("Target");
        mv3_Position = mgo_Target.transform.position;                               //문 위치 벡터화

        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (vm.mb_checkSceneReady){                                                 //tts 사용전 작업이 다 준비되면
            ChangePosition(mgo_Gratel,mv3_Position,0.05f);                                  //그레텔 이동
            ChangePosition(mgo_Hansel,mv3_Position,0.05f);                                  //헨젤 이동
        
        }
    }

    //go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
    void ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity){
        go_Object.transform.position = Vector3.MoveTowards(go_Object.transform.position,v3_Pos,f_Velocity);
    }
}
