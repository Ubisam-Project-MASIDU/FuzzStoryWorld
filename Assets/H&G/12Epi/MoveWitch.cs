  /*
 * - Name : MoveWitch.class
 * - Writer : 이예은
 * 
 * - Content :
 *  게임오브젝트를 이동시키는 함수 작성
 *  게임오브젝트가 다른 게임오브젝트를 추적 하는 함수 작성
 *
 * - HISTORY
 * 2021-08-12 : 초기 개발
 * 2021-08-13 : 개발 수정
 * 2021-08-13 : 코드 획일화 및 주석처리
 *
 * - Variable 
 * mgo_HanselGretel                             헨젤과 그레텔 게임오브젝트
 * mani_Witch                                   마녀 애니메이션
 * spr_InvertWitch                              이미지 상태 변경 컴포넌트
 * mb_StartRangeAttack                          RangeAttack 확인 논리형 변수
 * mg_SoundManage                               음성 출력 변수                              
 *
 * - Function
 * void OnTriggerEnter(Collider collision)      충돌 감지 함수
 * void OnDamaged(Vector3 targetPos)            데미지를 입었을 때 함수
 * void OffDamaged()                            데미지가 끝났을 때 함수 
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
// Epi12에서 나오는 목표 게임오브젝트 추적 스크립트
public class MoveWitch : MonoBehaviour
{
    // 목표 오브젝트를 따라가기 위해 필요한 변수들
    public GameObject mgo_HanselGretel;
    private bool mb_StartRangeAttack = false;
    // 나레이션을 위한 변수들
    GameObject mg_SoundManager;
    public bool isRangeAttacking {
        get {
            return mb_StartRangeAttack;
        }
        set {
            mb_StartRangeAttack = value;
        }
    }
    // publlic이 private의 get set이 됨. get 값 가져오기 set 값 설정하기
    Animator mani_Witch = null;
    SpriteRenderer spr_InvertWitch;
    Rigidbody rigid;
    // 초기화
    void Start(){
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }
    void Awake()
    {
        mani_Witch = GetComponent<Animator>();
        spr_InvertWitch = GetComponent<SpriteRenderer>();
    }
    void Update()
    { 
        // 게임 오브젝트가 헨젤과 그레텔에 가까워지면
        // 마녀가 걷는걸 멈춘다.
        // 그렇지 않다면 헨젤과 그레텔을 쫓는다. 
        if (!mb_StartRangeAttack) {
            if(Mathf.Abs(mgo_HanselGretel.transform.position.x - transform.position.x) < 1.0) {     
                if (mani_Witch != null) {
                    mani_Witch.SetBool("Walking", false);
                }      

            } else {
                if (mani_Witch != null) {
                    mani_Witch.SetBool("Walking", true);
                }
                transform.position = Vector3.MoveTowards(transform.position, mgo_HanselGretel.transform.position, 4f * Time.deltaTime);
            }
            
            // 게임 오브젝트가 헨젤과 그레텔보다 앞에 있다면
            // 좌우반전한다.
            // 그렇지 않다면 바뀌지 않는다.
            if(mgo_HanselGretel.transform.position.x - transform.position.x < 0) {
                spr_InvertWitch.flipX = true;
            } else {
                spr_InvertWitch.flipX = false;
            }
        } else {
            if (mani_Witch != null) {
                mani_Witch.SetBool("Walking", false);
            }
        }
    }
    // 마녀와 뼈가 충돌하면
    // 마녀가 데미지를 입는다.
    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.tag == "bone") {
            mg_SoundManager.GetComponent<SoundManager>().playSound("HitbyB");   // 뻐다귀를 맞았을 때 
            OnDamaged(collision.transform.position);            
        }
    }
    // 마녀가 공격받으면 색이 투명해진다.
    void OnDamaged(Vector3 targetPos) {
        gameObject.layer = 15;
        spr_InvertWitch.color = new Color(1, 1, 1, 0.4f);
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(dirc, 7, 7), ForceMode.Impulse);
        Invoke("OffDamaged", 0.7f);
    }
    // 다시 원래 색으로 돌아간다.
    void OffDamaged() {
        gameObject.layer = 11;
        spr_InvertWitch.color = new Color(1, 1, 1, 1);
    }
}
