/*
 * - Name : HAGMove.cs
 * - Writer : 최대준, 이병권
 * 
 * - Content : 
 *  헨젤과 그레텔이 움직임을 표현하는 스크립트 클래스이다.
 *  1) 아이들이 걸어다닐 때 소리 
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
    public Vector3 mv3_TargetPos;
    public bool mb_SetPos = false;
    private bool mb_DestroyOnce = false;
    private bool mb_DontWalk = false;
    private bool mb_HAGHit = false;
    public bool mb_SetWinWalk = false;
    // bool mb_Walk4 = false;
    GameObject mg_SoundManager;

    public bool DamagingHAG {
        get {
            return mb_HAGHit;
        }
    }
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
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
        HAGStatus = GameObject.Find("GameController").GetComponent<Scene12Controller>().HAGStatus;
    }

    void FixedUpdate() {
        if (mb_SetPos && !mb_DontWalk) {
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
                
                // if(mb_Walk4 == false){
                
                //     mg_SoundManager.GetComponent<SoundManager>().playSound("Walk4");     // 게임 끝 버튼 효과음 재생
                
                // }
                // mb_Walk4 = true;

                mb_DestroyOnce = false;
                // mani_HAGAnimator.SetBool("isWalking", true);
            } else if (!mb_DestroyOnce && f_CheckDistance <= f_LimitDistance) {
                Destroy(mgo_PointingTarget.transform.GetChild(0).gameObject);
                mb_DestroyOnce = true;
                mb_SetPos = false;
                // mani_HAGAnimator.SetBool("isWalking", false);
            }
        } else if (mb_DontWalk) {
            mb_SetPos = false;
        }
    }
    void Update() {
        // walking mouse clicked position...
        if (!mb_SetWinWalk) {
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

    public void HAGHit() {
        StartCoroutine(Damaging());
        mg_SoundManager.GetComponent<SoundManager>().playSound("Attack2");     // 게임 끝 버튼 효과음 재생

    }

    IEnumerator Damaging() {
        Color c_HanselTempColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        Color c_GretelTempColor = transform.GetChild(1).GetComponent<SpriteRenderer>().color;
        mb_HAGHit = true;
        mb_DontWalk = true;
        for (int i = 40; i >= 0; i--) {
            if (i % 2 == 0) {
                c_HanselTempColor.a = 0.5f;
                c_GretelTempColor.a = 0.5f;
            } else {
                c_HanselTempColor.a = 1f;
                c_GretelTempColor.a = 1f;
            }
            if (i == 30) {
                mb_DontWalk = false;
            } 
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = c_HanselTempColor;
            transform.GetChild(1).GetComponent<SpriteRenderer>().color = c_GretelTempColor;
            yield return null;
        }
        mb_HAGHit = false;

        c_HanselTempColor.a = 1f;
        c_GretelTempColor.a = 1f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = c_HanselTempColor;
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = c_GretelTempColor;
        yield return null;
    }
}
