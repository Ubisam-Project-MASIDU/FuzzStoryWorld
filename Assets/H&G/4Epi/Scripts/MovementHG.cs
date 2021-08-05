using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHG : MonoBehaviour
{
    private GameObject Gratel;
    private GameObject Hansel;

    private GameObject Dad;
    private GameObject Mom;

    private Vector3 GratelPos;
    private Vector3 HanselPos;

    private Vector3 DadPos;
    private Vector3 MomPos;

    private GameObject RockRight;
    private GameObject RockMid;
    private GameObject RockLeft;

    private Vector3 RockRightPosBefore;
    private Vector3 RockMidPosBefore;
    private Vector3 RockLeftPosBefore;

    private Vector3 RockRightPosAfter;
    private Vector3 RockMidPosAfter;
    private Vector3 RockLeftPosAfter;


    void Start(){
        Gratel = GameObject.Find("Gratel");
        Hansel = GameObject.Find("Hansel");

        Dad = GameObject.Find("Dad");
        Mom = GameObject.Find("Mom");

        GratelPos = new Vector3(0.0f,-6.1f,20.0f);
        HanselPos = new Vector3(1.0f,-5.9f,20.0f);

        DadPos = new Vector3(-5.0f,-6.1f,20.0f);
        MomPos = new Vector3(-5.0f,-5.9f,20.0f);

        RockRight = GameObject.Find("rockright");
        RockMid = GameObject.Find("rockmid");
        RockLeft = GameObject.Find("rockleft");

        RockRightPosBefore = new Vector3(2.0f,-6.6f,20.0f);
        RockMidPosBefore = new Vector3(2.0f,-6.6f,20.0f);
        RockLeftPosBefore = new Vector3(1.0f,-6.6f,20.0f);

        RockRightPosAfter = new Vector3(4.0f,-6.8f,20.0f);
        RockMidPosAfter = new Vector3(3.0f,-6.8f,20.0f);
        RockLeftPosAfter = new Vector3(2.0f,-6.8f,20.0f);

    }

    void Update(){
        Dad.transform.position = Vector3.MoveTowards(Dad.transform.position,DadPos,0.5f);
        Mom.transform.position = Vector3.MoveTowards(Mom.transform.position,MomPos,0.5f);

        Gratel.transform.position = Vector3.MoveTowards(Gratel.transform.position, GratelPos, 0.05f);
        Hansel.transform.position = Vector3.MoveTowards(Hansel.transform.position, HanselPos, 0.05f);

        RockRight.transform.position = Vector3.MoveTowards(RockRight.transform.position, RockRightPosBefore, 0.05f);
        RockMid.transform.position = Vector3.MoveTowards(RockMid.transform.position, RockMidPosBefore, 0.05f);
        RockLeft.transform.position = Vector3.MoveTowards(RockLeft.transform.position, RockLeftPosBefore, 0.05f);
        if(Hansel.transform.position.x <= 3) {
            RockRight.transform.position = Vector3.MoveTowards(RockRight.transform.position,RockRightPosAfter,0.1f);
            if(Hansel.transform.position.x <= 2) {
                RockMid.transform.position = Vector3.MoveTowards(RockMid.transform.position,RockMidPosAfter,0.1f);
                if(Hansel.transform.position.x <= 1.6) {
                    RockLeft.transform.position = Vector3.MoveTowards(RockLeft.transform.position,RockLeftPosAfter,0.1f);
                }
            }
        }   
    }
}
