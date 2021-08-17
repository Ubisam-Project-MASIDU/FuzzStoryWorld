/*
 * - Name : ControlMonster.cs
 * - Writer : 이병권
 * 
 * - Content : 
 * 쓰레기 몬스터가 다 죽었을 때 다음 페이지로 넘어감
 *            
 * -수정 기록-
 * 2021-08-11 : 제작 완료
 * 2021-08-12 : 주석 작성
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMonster : MonoBehaviour {
    int num = 6;                // 6개의 케릭터의 수를 정해주기

    void Update(){

        if(num<=0){
            SceneManager.LoadScene("1_11H&G");                     // 11 페이지로 넘어감
        }
    }
    public void Delete(){
        num--;
    }
}
