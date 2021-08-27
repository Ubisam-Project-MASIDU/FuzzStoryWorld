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
public class HAGAttack : MonoBehaviour {
    private Ray mr_CheckRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckHit;            // 레이져를 쏜 곳에 오브젝트가 
    private GameObject mgo_Target;
    private Vector3 mv3_TargetPos;
    private bool mb_SetPos = false;
    public GameObject mgo_witch;
    public Transform BonePos;
    public Transform HAG;
    private Status mst_WitchStatus;
    private Scene12Controller ms12c_CharacterInfo;
    private Status mst_HAGStatus;
    public GameObject mgo_BonePrefab;
    private GameObject mgo_IntantBone;
    private bool mb_CheckBone = true;
    public bool mb_DelayThrowing = false;

    GameObject mg_SoundManager;

    void Start() {
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
        ms12c_CharacterInfo = GameObject.Find("GameController").GetComponent<Scene12Controller>();
    }
    void FixedUpdate() {
        if (mb_SetPos) {
            // 던지려는 좌표 값과 현재 내 위치의 차이를 구한다.
            float f_CheckDistance = Vector3.Distance(transform.position, mv3_TargetPos);
                Debug.Log(f_CheckDistance);

            if (f_CheckDistance > 8f) {
                transform.position = Vector3.Slerp(transform.position, mv3_TargetPos, 5f * Time.deltaTime);
            } 
        }
    }
    void Update() {
        if (mb_DelayThrowing) {
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
            if(!mb_CheckBone) {
                Debug.Log("뼈없음");
                Invoke("Create", 5f);
                mgo_IntantBone = Instantiate(mgo_BonePrefab, BonePos.position, BonePos.rotation, HAG) as GameObject;
                mgo_IntantBone.GetComponent<HAGAttack>().BonePos = BonePos;
                mgo_IntantBone.GetComponent<HAGAttack>().HAG = HAG;
                mgo_IntantBone.GetComponent<HAGAttack>().mgo_BonePrefab = mgo_BonePrefab;
                
                mb_CheckBone = true;
            }  
        }
    }          
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("witch") && mb_SetPos) {
            Destroy(this.gameObject);
            mb_CheckBone = false;
            mb_SetPos = false;
            mgo_IntantBone.GetComponent<HAGAttack>().mb_DelayThrowing = true; //error
            HitWitch();             
        }
    }
    
    void HitWitch() {
        ms12c_CharacterInfo.WitchHP -= ms12c_CharacterInfo.HAGStatus.AttackDamage + 3f;  
    }
} 
