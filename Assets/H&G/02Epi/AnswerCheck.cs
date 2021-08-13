/*
 * - Name : AnswerCheck.class
 * - Writer : 유희수
 * - Content : 헨젤과그레텔 Epi2 미니게임 - 몇개의 퍼즐조각이 맞춰졌는지 세고, 모두 맞춰지면 다음씬으로 이동하는 스크립트
 *  
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-12 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mn_count                     퍼즐이 몇개 맞춰졌는지 확인을 위한 변수
 * 
 * <Function>
 * v_CountAnswer()              퍼즐을 맞출때마다 개수 변수를 더해주는 함수
 * v_changeNextScene()          다음씬으로 넘어가는 함수
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerCheck : MonoBehaviour
{
    public int mn_count;
    
    void Start(){
        mn_count = 0;           //퍼즐 개수 변수 0으로 초기화
    }

    //퍼즐을 맞출때마다 개수 변수를 더해주는 함수
    //퍼즐이 모두 맞춰지는지 개수로 확인하고, 다 맞춰지면 다음 씬으로 이동
    public void v_CountAnswer(){
        mn_count++;            //개수 하나씩 더해준다
        Debug.Log(mn_count);
        if (mn_count == 9){    
            Invoke("v_changeNextScene", 2f);
        }
    }

    //다음 씬으로 이동하는 함수
    public void v_changeNextScene()
    {
        SceneManager.LoadScene("1_03H&G");
    }
}