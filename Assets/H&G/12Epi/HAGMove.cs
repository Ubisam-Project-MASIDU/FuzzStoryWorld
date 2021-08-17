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
    private GameObject mgo_PointingTarget;
    private Vector3 mv3_TargetPos;
    private bool mb_SetPos = false;
    private bool mb_DestroyOnce = false;
    private Animator mani_HAGAnimator;
    
    void Start() {
        mgo_PointingTarget = GameObject.Find("PointingTarget").gameObject;
        mani_HAGAnimator = GetComponent<Animator>();
    }

    
    void Update() {
        // walking mouse clicked position...
        if (mb_SetPos) {
            float f_OperationResult = f_ComputeDistance(transform.position, mv3_TargetPos);
            float f_LimitDistance = 3f;
            float f_FlipCharacter = transform.position.x - mv3_TargetPos.x;

            if (f_OperationResult > f_LimitDistance) {
                if (f_FlipCharacter > 0) {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
                } else {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, mv3_TargetPos, 10f * Time.deltaTime);
                mb_DestroyOnce = false;
                // mani_HAGAnimator.SetBool("isWalking", true);
            } else if (!mb_DestroyOnce && f_OperationResult <= f_LimitDistance) {
                Destroy(mgo_PointingTarget.transform.GetChild(0).gameObject);
                mb_DestroyOnce = true;
                mb_SetPos = false;
                // mani_HAGAnimator.SetBool("isWalking", false);
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj, Mathf.Infinity)) {
                if (mgo_PointingTarget.transform.childCount != 0) {
                    Destroy(mgo_PointingTarget.transform.GetChild(0).gameObject);
                }
                Instantiate(mgo_MovementMark, mrch_CheckMousePosHitObj.point, mgo_MovementMark.transform.rotation, mgo_PointingTarget.transform);
                mv3_TargetPos = mrch_CheckMousePosHitObj.point;
                mb_SetPos = true;
            }
        }
        
    }

    private float f_ComputeDistance(Vector3 v3Current, Vector3 v3Target) {
        return Mathf.Sqrt(Mathf.Pow(v3Current.x - v3Target.x, 2) + Mathf.Pow(v3Current.y - v3Target.y, 2) + Mathf.Pow(v3Current.z - v3Target.z, 2));
    }
}
