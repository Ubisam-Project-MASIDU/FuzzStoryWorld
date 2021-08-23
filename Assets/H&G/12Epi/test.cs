/*
 * - Name : HAGAttack.cs
 * - Writer : 이예은
 * 
 * - Content :
 * 헨젤과 그레텔이 마녀를 공격하는 것을 정의한 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-13 : 코드 구현중. 
 * 2) 2021-08-13 : 주석 작성.
 *  
 * - Variable 
 * 
 *
 * - Function
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class test : MonoBehaviour
{
    private Ray mr_CheckRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckHit;            // 레이져를 쏜 곳에 오브젝트가 
    private GameObject mgo_Target;
    private Vector3 mv3_TargetPos;
    private bool mb_SetPos = false;         //클릭(true)하면 날라감, 날라가는 도중에 클릭해도 뼈에 영향 없음
    private bool mb_DestroyOnce = false;
    public GameObject mgo_witch;
    public Transform BonePos;
    public Transform HAG;
    public GameObject BonePrefab;
    private bool mb_CheckBone = true;   // 뼈 유무

    void Start() {
    }
    void FixedUpdate() {
        if (mb_SetPos) {
            // 던지려는 좌표 값과 현재 내 위치의 차이를 구한다.
            float f_CheckDistance = Vector3.Distance(transform.position, mv3_TargetPos);
              //  Debug.Log(f_CheckDistance);
            if (f_CheckDistance > 2f) {
                transform.position = Vector3.Slerp(transform.position, mv3_TargetPos, 5f * Time.deltaTime);
                mb_DestroyOnce = false;
                Debug.Log("던짐");
            } 
            else if (!mb_DestroyOnce && f_CheckDistance < 2f) {
                Debug.Log("가까움");
                mb_DestroyOnce = true;
                mb_SetPos = false;
             }
        }
    }
    void Update() {
        if (Input.GetMouseButtonDown(0) && !mb_SetPos) {
            mr_CheckRay = Camera.main.ScreenPointToRay(Input.mousePosition);           
            if (Physics.Raycast(mr_CheckRay, out mrch_CheckHit)) {
                if (mrch_CheckHit.transform.gameObject.name == "witch" && mb_CheckBone) {
                    Debug.Log("뼈있음");                    
                    mv3_TargetPos = mrch_CheckHit.transform.position;
                    mb_SetPos = true;
                    mb_CheckBone = false;
                    }                 
                }
            }
        }          
    void OnTriggerStay(Collider other) {
        if (other.gameObject.name.Equals("witch") && mb_SetPos) {
            Destroy(this.gameObject);
            mb_DestroyOnce = true;
            GameObject intantBone = Instantiate(BonePrefab, BonePos.position, BonePos.rotation, HAG) as GameObject;
            mb_CheckBone = true;
            mb_SetPos = true;
        }
    }
}
