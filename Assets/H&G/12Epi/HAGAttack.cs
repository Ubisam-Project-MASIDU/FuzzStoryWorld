/*
 * - Name : HAGAttack.cs
 * - Writer : 이예은
 * 
 * - Content :
 * 헨젤과 그레텔이 마녀를 공격하는 것을 정의한 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-13 : 코드 구현중. 
 * 2) 2021-08-17 : 개발 수정
 * 3) 2021-08-18 : 코드 추가
 * 4) 2021-08-30 : 코드 획일화 및 주석 처리
 * 
 * - Variable 
 * mr_CheckRay                                     마우스가 클릭된 곳을 카메라에서부터 레이저를 쏘아 감지하기 위한 Ray
 * mrch_CheckHit                                   레이저가 쏜 곳에 오브젝트가 있는지 확인                                   
 * mv3_TargetPos                                   BonePrefab이 생성되는 장소
 * mb_SetPos                                       위치를 확인하기 위한 bool 변수 
 * mgo_witch                                       마녀 게임 오브젝트 
 * mt_BonePos                                      BonePrefab이 생성되는 장소
 * mt_ HAG                                         헨젤과 그레텔 위치 변수                               
 * ms12c_CharacterInfo                             Scene12Controller 스크립트 속 변수                                    
 * mgo_BonePrefab                                  뼈 프리팹 게임 오브젝트
 * mgo_IntantBone                                  복제된 뼈 게임 오브젝트
 * mb_CheckBone                                    뼈가 생성됐는지 확인
 * mb_DelayThrowing                                뼈를 던졌는지 확인
 * mg_SoundManager                                 음성 출력 변수 
 *
 * - Function
 * void OnTriggerEnter(Collider other)             마녀와 뼈 충돌 감지 함수
 * void HitWitch()                                 헨젤과 그레텔 데미지 감소 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HAGAttack : MonoBehaviour {
    // 마녀를 클릭하는데 필요한 변수
    private Ray mr_CheckRay;                     
    private RaycastHit mrch_CheckHit; 
              
    // 뼈를 생성하는데 필요한 변수
    private Vector3 mv3_TargetPos;
    private bool mb_SetPos = false;
    private bool mb_CheckBone = true;
    public bool mb_DelayThrowing = false;
    public GameObject mgo_witch;
    public Transform mt_BonePos;
    public Transform mt_HAG;
    private Scene12Controller ms12c_CharacterInfo;
    public GameObject mgo_BonePrefab;
    private GameObject mgo_IntantBone;

    // 헨젤과 그레텔, 마녀의 상태를 나타내는 변수
    private Status mst_HAGStatus;
    private Status mst_WitchStatus;

    // 음성 출력 변수 
    GameObject mg_SoundManager;                                             

    // 초기화
    void Start() {
        mg_SoundManager = GameObject.Find("SoundManager");                   // 사운드 매니저 게임오브젝트 연결
        ms12c_CharacterInfo = GameObject.Find("GameController").GetComponent<Scene12Controller>();
    }

    void FixedUpdate() {
        if (mb_SetPos) {
            // 던지려는 좌표 값과 현재 내 위치의 차이를 구한다.
            float f_CheckDistance = Vector3.Distance(transform.position, mv3_TargetPos);
                Debug.Log(f_CheckDistance);
            // 만약 거리가 8f보다 크다면
            // 목표 지점으로 게임오브젝트를 던져라 
            if (f_CheckDistance > 8f) {
                transform.position = Vector3.Slerp(transform.position, mv3_TargetPos, 5f * Time.deltaTime);
            } 
        }
    }
    void Update() {
        // 클릭한 오브젝트가 마녀라면
        // TargetPos를 클릭된 위치로 변경한다.                
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
            // 만약 뼈가 없다면
            // 뼈를 복제시킨다.
            // 복제된 뼈에게 값들을 할당시켜준다.
            if(!mb_CheckBone) {
                Debug.Log("뼈없음");
                mgo_IntantBone = Instantiate(mgo_BonePrefab, mt_BonePos.position, mt_BonePos.rotation, mt_HAG) as GameObject;
                mgo_IntantBone.GetComponent<HAGAttack>().mt_BonePos = mt_BonePos;
                mgo_IntantBone.GetComponent<HAGAttack>().mt_HAG = mt_HAG;
                mgo_IntantBone.GetComponent<HAGAttack>().mgo_BonePrefab = mgo_BonePrefab;
                mgo_IntantBone.GetComponent<HAGAttack>().mb_DelayThrowing = true;
                
                mb_CheckBone = true;
            }  
        }
    }           
    // 충돌 감지 함수
    void OnTriggerEnter(Collider other) {
        // 만약 충돌한 오브젝트가 마녀라면
        // 이 게임 오브젝트(뼈 프리팹)를 없앤다.
        if (other.gameObject.name.Equals("witch") && mb_SetPos) {
            Destroy(this.gameObject);
            mb_CheckBone = false;
            mb_SetPos = false;
            HitWitch();             
        }
    }
    
    // 헨젤과 그레텔이 마녀에게 공격받았을 때 헨젤과 그레텔의 체력 게이지를 감소시키는 함수
    void HitWitch() {
        ms12c_CharacterInfo.WitchHP -= ms12c_CharacterInfo.HAGStatus.AttackDamage + 3f;  
    }
} 
