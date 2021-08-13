/*
 * - Name : HAGMove.cs
 * - Writer : 최대준
 * 
 * - Content : 
 *  헨젤과 그레텔이 움직임을 표현하는 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-13 : 코드 구현중. 
 * 2) 2021-08-13 : 주석 작성.
 *  
 * - Variable 
 *
 * - Function
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAGMove : MonoBehaviour {

    private Ray mr_CheckMousePosByRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckMousePosHitObj;            // 레이져를 쏜 곳에 오브젝트가 
    public GameObject mgo_MovementMark;
    private Vector3 mv3_TargetPos;
    private bool mb_SetPos = false;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (mb_SetPos) {
            transform.position = Vector3.MoveTowards(transform.position, mv3_TargetPos, 1f * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0)) {
            mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj, Mathf.Infinity)) {
                if (transform.childCount != 0) {
                    Destroy(transform.GetChild(0).gameObject);
                }
                Instantiate(mgo_MovementMark, mrch_CheckMousePosHitObj.point, mgo_MovementMark.transform.rotation, transform);
                mv3_TargetPos = mrch_CheckMousePosHitObj.point;
                mb_SetPos = true;
            }
        }
        
    }
}
