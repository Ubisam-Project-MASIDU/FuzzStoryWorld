/*
 * - Name : TurnPage.cs
 * - Writer : 이병권
 * - Content : 11씬에서 모든 행동이 끝나면 12로 넘어가는 스크립트
 *
 * - Content : 뼈다기가 다 사라졌을 때 다음 페이지로 넘어감
 *            
 * - HISTORY (수정 기록) 
 * 1) 2021-08-03- 초기 개발
 * 2) 2021-08-11 : 오류 수정
 * 3) 2021-08-12 : 주석 작성 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnPage : MonoBehaviour
{
   int num = 2;                                                    // 케릭터의 수 2으로 저장하기

    void Update(){

        if(num<=0){
            SceneManager.LoadScene("1_12H&G");                     // 0이 되면 다음 페이지로 넘어감
        }
    }
    public void Delete(){
        num--;
    }
}
