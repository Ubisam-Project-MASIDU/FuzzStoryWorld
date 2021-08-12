/*
 * - Name : KilltheMonster.cs
 * - Writer : 이병권
 * 
 * - Content : 
 * 쓰레기 몬스터 설정 스크립트
 * 몇번을 터치하여 죽게할 것인지 설정
 *            
 *            
 * -수정 기록-
 * 2021-08-10 : 제작 완료
 * 2021-08-11 : 주석 작성
 * 
 * - Variable 
 * T_Monster_HP : 쓰레기 몬스터 HP 설정 변수
*
 * -Function()
 * OnMouseDown() : 바이러스 클릭시 작동되는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTheMonster : MonoBehaviour {
    private int T_Monster_HP = 2;               // 세균의 채력 범위 설정
    GameObject ControlMonster;
    
    void Start(){
        ControlMonster = GameObject.Find("ControlMonster");
    }

    private void OnMouseDown() {   
        if (T_Monster_HP <= 0) {                  // 세균의 HP가 0보다 작으면 죽는경우 설정
            ControlMonster.GetComponent<ControlMonster>().Delete();
            GetComponent<SoundEffectes>().PlaySound("DIE");
            GetComponent<TrashMonsterMove>().enabled = false;
            Invoke("destroyTrash", 0.4f);
        }
        else {
            T_Monster_HP -= 1;                   // 세균을 터치하여 HP감소
            GetComponent<SoundEffectes>().PlaySound("ATTACK");
            Debug.Log("클릭");
        }
    }
    private void destroyTrash() {
        Destroy(gameObject);
    }
}