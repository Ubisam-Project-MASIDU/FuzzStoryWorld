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
    private Rigidbody mr_StandGround;
    private int mn_MaskingCharacters;
    private CharacterController mCharCon_HAGMoveController;
    private Status HAGStatus;
    
    void Start() {
        mgo_PointingTarget = GameObject.Find("PointingTarget").gameObject;
        mani_HAGAnimator = GetComponent<Animator>();
        mr_StandGround = GetComponent<Rigidbody>();
        mn_MaskingCharacters = (1 << LayerMask.NameToLayer("Platform"));
        mCharCon_HAGMoveController = GetComponent<CharacterController>();
        HAGStatus = GameObject.Find("GameController").GetComponent<Scene12Controller>().HAGStatus;
    }

    void FixedUpdate() {
        if (mb_SetPos) {
            // 이동하고자하는 좌표 값과 현재 내 위치의 차이를 구한다.
            float f_CheckDistance = Vector3.Distance(transform.position, mv3_TargetPos);
            float f_LimitDistance = 4f;
            float f_FlipCharacter = transform.position.x - mv3_TargetPos.x;
            
            if (f_CheckDistance > f_LimitDistance) {
                if (f_FlipCharacter > 0) {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
                } else {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
                }


                transform.position = Vector3.MoveTowards(transform.position, mv3_TargetPos, HAGStatus.WalkSpeed * Time.deltaTime);
                mb_DestroyOnce = false;
                // mani_HAGAnimator.SetBool("isWalking", true);
            } else if (!mb_DestroyOnce && f_CheckDistance <= f_LimitDistance) {
                Destroy(mgo_PointingTarget.transform.GetChild(0).gameObject);
                mb_DestroyOnce = true;
                mb_SetPos = false;
                // mani_HAGAnimator.SetBool("isWalking", false);
            }
        }
    }
    void Update() {
        // walking mouse clicked position...
        
        if (Input.GetMouseButtonDown(0)) {
            mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj, Mathf.Infinity, mn_MaskingCharacters)) {
                if (mgo_PointingTarget.transform.childCount != 0) {
                    Destroy(mgo_PointingTarget.transform.GetChild(0).gameObject);
                }
                Instantiate(mgo_MovementMark, mrch_CheckMousePosHitObj.point + new Vector3(0, 0.5f, 0), mgo_MovementMark.transform.rotation, mgo_PointingTarget.transform);
                mv3_TargetPos = mrch_CheckMousePosHitObj.point;
                mb_SetPos = true;
            }
        }
        
    }

    private float f_ComputeDistance(Vector3 v3Current, Vector3 v3Target) {
        return Mathf.Sqrt(Mathf.Pow(v3Current.x - v3Target.x, 2) + Mathf.Pow(v3Current.y - v3Target.y, 2) + Mathf.Pow(v3Current.z - v3Target.z, 2));
    }
    public void pickup(GameObject item) {
        setEquip(item, true);
    }
    void setEquip(GameObject item, bool isEquip) {
        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();

        foreach(Collider itemCollider in itemColliders) {
            itemCollider.enabled = !isEquip;
        }
        itemRigidbody.isKinematic = isEquip;
    }
}
