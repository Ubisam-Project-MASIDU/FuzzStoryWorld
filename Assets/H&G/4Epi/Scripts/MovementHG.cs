using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHG : MonoBehaviour
{
    private GameObject Gratel;
    private GameObject Hansel;
    private GameObject targetPosition;
    private Vector3 GratelPos;
    private Vector3 HanselPos;
    IEnumerator GratelMove;
    IEnumerator HanselMove;
    void Start(){
        Gratel = GameObject.Find("Gratel");
        Hansel = GameObject.Find("Hansel");
        
        GratelPos = new Vector3(1.0f,-6.1f,20.0f);
        HanselPos = new Vector3(2.0f,-5.9f,20.0f);
    }

    void Update(){
        Gratel.transform.position = Vector3.MoveTowards(Gratel.transform.position, GratelPos, 0.05f);
        Hansel.transform.position = Vector3.MoveTowards(Hansel.transform.position, HanselPos, 0.05f);
    }
}
