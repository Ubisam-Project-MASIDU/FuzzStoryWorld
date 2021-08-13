/*
 * - Name : MoveWitch.class
 * - Writer : 이예은
 * 
 * - Content :
 *  게임오브젝트를 이동시키는 함수 작성
 *  게임오브젝트가 다른 게임오브젝트를 따라가게 하는 함수 작성
 *
 * - HISTORY
 * 2021-08-12 : 초기 개발
 * 2021-08-13 : 개발 수정
 * 2021-08-13 : 코드 획일화 및 주석처리
 *
 * - Variable 
 * mgo_HanselGretel                             헨젤과 그레텔 게임오브젝트
 * mani_Witch                                   마녀 애니메이션
 * spriteRenderer                               이미지 상태 변경 컴포넌트
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWitch : MonoBehaviour
{
    public GameObject mgo_HanselGretel;
    SpriteRenderer spriteRenderer;
    Animator mani_Witch;
    void Awake()
    {
        mani_Witch = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {     
        if(Mathf.Abs(mgo_HanselGretel.transform.position.x - transform.position.x) < 1.0) {
            mani_Witch.SetBool("Walking", false);
        } else {
            mani_Witch.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, mgo_HanselGretel.transform.position, 2f * Time.deltaTime);
        }
        if(mgo_HanselGretel.transform.position.x - transform.position.x < 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }
}
    