/*
 * - Name : ControlMonster.cs
 * - Writer : 이병권
 * 
 * - Content : 쓰레기 몬스터가 다 죽었을 때 씬 10에서 다음 11씬으로 넘어가는 스크립트
 *            
 * - HISTORY (수정 기록)
 * 2021-08-03- 초기 개발
 * 2021-08-11 : 오류 수정
 * 2021-08-12 : 주석 작성
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMonster : MonoBehaviour {
    int num = 6;                                                    // 케릭터의 수 6으로 저하기

    void Update(){

        if(num==0){
            SceneManager.LoadScene("1_11H&G");                     // 0이 되면 다음 페이지로 넘어감
        }
    }
    public void Delete(){
        num--;
    }
}
