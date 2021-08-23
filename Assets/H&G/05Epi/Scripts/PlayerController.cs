/*
 * - Name : PlayerController.cs
 * - Writer : 이윤교
 * - Content : 플레이어가 점프하고 달리고 조약돌을 먹는 것을 조정하는 스크립트
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 주석처리
 * 2021-08-23 : 코드 획일화
 *
 * <Variable>
 * mb_isJump           플레이어가 점프하고 있는 상태인지 체크하는 변수
 * mb_isTop            일정 높이에 도달한 상태인지 체크하는 변수
 * mf_jumpHeight       플레이어가 올라가는 높이 변수
 * mf_jumpSpeed        플레이어가 올라가는 속도 변수
 * mn_cntRock          조약돌 몇개 먹었는지 세는 변수
 * mn_totalRockNum     게임 시작 시 주어지는 조약돌 총 갯수 저장하는 변수
 * mv2_startPosition    처음 위치 저장 변수
 * animator         플레이어애개 저장되어있는 애니메이터를 저장하는 변수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    bool mb_isJump = false; 
    bool mb_isTop = false;
    public float mf_jumpHeight = 0;
    public float mf_jumpSpeed = 0;
    int mn_cntRock = 0;
    private int mn_totalRockNum;
    Vector2 mv2_startPosition;
    Animator animator;
    GameObject SoundManager;
    void Start(){
        mn_totalRockNum = UnityEngine.Random.Range(3,8);   // 게임시작할 때 플레이어가 주어야하는 조약돌의 갯수를 랜덤으로 배정해줌
        Debug.Log(mn_totalRockNum + "번 도전!");
        mv2_startPosition = transform.position;             // 스크립트가 실행될 때 오브젝트의 현재위치로 초기화
        animator = GetComponent<Animator>();            // 플레이어애개 추가 되어있는 애니메이터 컴포넌트를 가져옴
        SoundManager = GameObject.Find("SoundManager");
    }

    void Update(){
        // 게임 시작 버튼을 누르면
        if(GameManager.instance.mb_isPlay){
            animator.SetBool("Run",true); // 애니메이터의 Run 파라미트를 참으로 변경 -> 플레이어가 Run 모션 재생
        }else{
            animator.SetBool("Run",false); // 애니메이터의 Run 파라미트를 거짓으로 변경 -> 플레이어가 Idle 모션 재생
        }

        // 게임 시작 버튼을 누른 후 화면을 누르면 플레이어 점프 시키기
        // 화면 터치 여부 : GetMouseButtonDown(0) 함수 사용
        if(Input.GetMouseButtonDown(0) && GameManager.instance.mb_isPlay){ 
            mb_isJump = true; //점프동작 실행
        }// 플레이어가 mv2_startPosition 낮은 위치에 오면
        else if(transform.position.y <= mv2_startPosition.y){ 
            mb_isJump = false;
            mb_isTop = false;
            transform.position = mv2_startPosition; // 현재 위치를 mv2_startPosition 다시 초기화
        }

        // GetMouseButtonDown(0) 조건문 안에 플레이어가 점프하는 코드를 바로 적지 않는 이유는 GetMouseButtonDown(0)함수는 버튼이 다운될 때 한번만 실행 되기 때문에 버튼이 눌린 순간만 올라가고 멈춰버림.
        // 점프 변수가 참일 때 플레이어 위치 위로 올리기
        if(mb_isJump){ 
            // 일정 높이에 아직 도달하지 않으면
            if(transform.position.y <= mf_jumpHeight - 0.1f && !mb_isTop){ 
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, mf_jumpHeight), mf_jumpSpeed * Time.deltaTime);
            }// 일정 높이에 도달한 상태이면 isTop 변수를 참으로 변경하고 더이상 Lerp함수가 작동하지 않게 함.
            else{ 
                mb_isTop = true;
            }
            
            // 일정 높이에 도달한 상태이면 
            if(transform.position.y > mv2_startPosition.y && mb_isTop){ 
                transform.position = Vector2.MoveTowards(transform.position,mv2_startPosition,mf_jumpSpeed * Time.deltaTime); //플레이어를 mv2_startPosition로 옮기기 (위에서 아래로)
            }
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D cCollidObj){   
        if(cCollidObj.CompareTag("Item")){              // 플레이어가 조약돌과 충돌하면 (갖게 되면)
            SoundManager.GetComponent<SoundManager>().playSound("Collision");
            // Deative Item
            mn_cntRock += 1;                               // 플레이어가 갖게 된 조약돌 갯수 +1
            Debug.Log(mn_cntRock + "번째 돌 먹기 성공!");
            cCollidObj.gameObject.SetActive(false);     // 갖게 된 조약돌 비활성화

        }
        if(mn_cntRock >= mn_totalRockNum ){                   // 플레이어가 mn_totalRockNum 개의 조약돌을 다 갖게되면
            GameManager.instance.GameOver();            // 게임 끝
        }
    }

}
