/*
 * - Name : TurnPage.cs
 * - Writer : 이병권
 * 
 * - Content : 
 * 뼈다기가 다 사라졌을 때 다음 페이지로 넘어감
 *            
 * -수정 기록-
 * 
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
