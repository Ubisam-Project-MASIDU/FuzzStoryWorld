/*
 * - Name : Movement.cs
 * - Writer : 이윤교
 * - Content : 헨젤과그레텔 Epi4 _ 게임오브젝트 이동 스크립트
 * 
 * - HISTORY
 * 2021-08-05 : 초기 개발
 * 2021-08-06 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mgo_Gratel : 그레텔 게임오브젝트
 * mgo_Hansel : 헨젤 게임오브젝트
 * mv3_GratelPos : 그레텔 이동할 목표위치 
 * mv3_HanselPos : 헨젤 이동할 목표위치 
 * mgo_Dad : 아버지 게임오브젝트
 * mgo_Mom : 어머니 게임오브젝트
 * mv3_DadPos : 아버지 이동할 목표위치 
 * mv3_MomPos : 어머니 이동할 목표위치 
 * mgo_RockRight : 오른쪽 돌 게임오브젝트
 * mgo_RockMid : 가운데 돌 게임오브젝트
 * mgo_RockLeft : 왼쪽 돌 게임오브젝트
 * mv3_RockRightPosBefore : 오른쪽 돌 떨어지기 전 이동할 목표위치 
 * mv3_RockMidPosBefore : 가운데 돌 떨어지기 전 이동할 목표위치 
 * mv3_RockLeftPosBefore : 왼쪽 돌 떨어지기 전 이동할 목표위치 
 * mv3_RockRightPosAfter : 오른쪽 돌 떨어지기 후 이동할 목표위치 
 * mv3_RockMidPosAfter : 가운데 돌 떨어지기 후 이동할 목표위치 
 * mv3_RockLeftPosAfter : 왼쪽 돌 떨어지기 후 이동할 목표위치 
 *
 * <Function>
 * ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity) : go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 //Epi4에서 나오는 게임오브젝트 이동 스크립트
public class Movement : MonoBehaviour
{
    //헨젤과 그레텔 이동에 필요한 변수들
    private GameObject mgo_Gratel;
    private GameObject mgo_Hansel;
    private Vector3 mv3_GratelPos;
    private Vector3 mv3_HanselPos;
    
    //아버지와 어머니 이동에 필요한 변수들
    private GameObject mgo_Dad;
    private GameObject mgo_Mom;
    private Vector3 mv3_DadPos;
    private Vector3 mv3_MomPos;
    
    //조약돌 이동에 필요한 변수들
    private GameObject mgo_RockRight;
    private GameObject mgo_RockMid;
    private GameObject mgo_RockLeft;
    private Vector3 mv3_RockRightPosBefore;
    private Vector3 mv3_RockMidPosBefore;
    private Vector3 mv3_RockLeftPosBefore;
    private Vector3 mv3_RockRightPosAfter;
    private Vector3 mv3_RockMidPosAfter;
    private Vector3 mv3_RockLeftPosAfter;

    void Start(){
        mgo_Gratel = GameObject.Find("Gratel");
        mgo_Hansel = GameObject.Find("Hansel");
        mv3_GratelPos = new Vector3(-1.5f,6.8f,-6.0f);           // 그레텔 이동할 목표위치 
        mv3_HanselPos = new Vector3(0.4f,7.0f,-6.0f);

        mgo_Dad = GameObject.Find("Dad");
        mgo_Mom = GameObject.Find("Mom");
        mv3_DadPos = new Vector3(-13.0f,7.5f,-6.0f);
        mv3_MomPos = new Vector3(-12.0f,7.5f,-6.0f);

        mgo_RockRight = GameObject.Find("rockright");
        mgo_RockMid = GameObject.Find("rockmid");
        mgo_RockLeft = GameObject.Find("rockleft");
        
        mv3_RockRightPosBefore = new Vector3(0.4f,7.0f,-6.0f);
        mv3_RockMidPosBefore = new Vector3(0.4f,6.0f,-6.0f);
        mv3_RockLeftPosBefore = new Vector3(0.4f,6.0f,-6.0f);
        mv3_RockRightPosAfter = new Vector3(9.0f,6.0f,-6.0f);
        mv3_RockMidPosAfter = new Vector3(6.0f,6.0f,-6.0f);
        mv3_RockLeftPosAfter = new Vector3(3.0f,6.0f,-6.0f);
    }

    void Update(){
        ChangePosition(mgo_Gratel,mv3_GratelPos,0.05f);                         // 그레텔 이동
        ChangePosition(mgo_Hansel,mv3_HanselPos,0.05f);                         // 헨젤 이동

        ChangePosition(mgo_Dad,mv3_DadPos,0.1f);                                // 아버지 이동
        ChangePosition(mgo_Mom,mv3_MomPos,0.1f);                                // 어머니 이동

        ChangePosition(mgo_RockRight,mv3_RockRightPosBefore,0.05f);             // 첫번째 돌 이동
        ChangePosition(mgo_RockMid,mv3_RockMidPosBefore,0.05f);                 // 두번째 돌 이동
        ChangePosition(mgo_RockLeft,mv3_RockLeftPosBefore,0.05f);               // 세번째 돌 이동

        if(mgo_Hansel.transform.position.x <= 8) {
            ChangePosition(mgo_RockRight,mv3_RockRightPosAfter,0.05f);          // 첫번째 돌 떨어뜨리기
            if(mgo_Hansel.transform.position.x <= 5) {
                ChangePosition(mgo_RockMid,mv3_RockMidPosAfter,0.05f);          // 두번째 돌 떨어뜨리기
                if(mgo_Hansel.transform.position.x <= 2) {
                    ChangePosition(mgo_RockLeft,mv3_RockLeftPosAfter,0.05f);    // 세번째 돌 떨어뜨리기    
                }
            }
        }   
    }

    // goObject가  v3Pos위치로 fVelocity 속력으로 이동하는 함수 
    void ChangePosition(GameObject goObject, Vector3 v3Pos, float fVelocity){
        goObject.transform.position = Vector3.MoveTowards(goObject.transform.position,v3Pos,fVelocity);
    }
}
