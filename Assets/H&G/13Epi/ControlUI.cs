﻿/*
 * - Name : Score.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 전체적인 UI를 총괄하는 스크립트
 * 스코어 계산 및 남은시간 UI를 조정해준다.
 * 
 * - History
 * 1) 2021-08-13 : 블록이 터질때 점수가 산정되게 설정
 * 2) 2021-08-17 : 시간이 모두 초과되고 점수가 0점보다 높으면 다음신으로 연결되게 설정
 * 3) 2021-08-20 : 블록이 터질때 시간증가 되는 함수 작성
 * 
 * - Variable
 * mg_WinImage                                      Win오브젝트 연결을 위한 변수
 * mg_Score                                         점수를 출력해주는 오브젝트 연결을 위한 변수  
 * mi_LeftTimeCircle                                남은 시간 이미지 연결을 위한 변수
 * md_score                                         점수를 저장해두는 변수 
 * mf_delta                                         시간흐름을 재기위한 변수
 * mb_EndGameFlag                                   게임이 끝났는지 확인하기 위한 Flag
 * 
 * - Function
 * v_IncreaseScore()                                점수를 올려주는 함수
 * v_NextScene()                                    다음씬으로 연결해주는 함수
 * v_IncreaseTime()                                 남은 시간을 증가시켜주는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 스코어 계산 및 남은시간 UI를 조정해준다
public class ControlUI : MonoBehaviour
{
    // 변수 선언부
    public GameObject mg_WinImage;
    GameObject mg_Score;
    Image mi_LeftTimeCircle;
    double md_score = 0;
    float mf_delta = 0;
    bool mb_EndGameFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        mg_Score = GameObject.Find("Score");
        mi_LeftTimeCircle = GameObject.Find("LeftTimeCircle").GetComponent<Image>();
        mi_LeftTimeCircle.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mg_Score.GetComponent<Text>().text = "점수 : " + md_score;

        // 1초마다 남은 시간 감소되게 설정
        this.mf_delta += Time.deltaTime;
        if(mf_delta >= 1)
        {
            mf_delta = 0;
            mi_LeftTimeCircle.fillAmount -= 0.01f;                                          // 90초간 게임 진행(0.01f)
        }

        // 만약 남은 시간이 없다면 엔딩 이미지를 띄워주고 다음씬으로 연결
        if (mi_LeftTimeCircle.fillAmount == 0 && mb_EndGameFlag == false)
        {
            mb_EndGameFlag = true;
            if (md_score > 0)
            {
                mg_WinImage = Instantiate(mg_WinImage) as GameObject;
                this.GetComponent<MainScript>().v_ChangeDragFlagFalse();
                Invoke("v_NextScene", 2);
            }
        }
        // 만약 남은시간이 100%를 초과하게되면 100%로 설정
        else if(mi_LeftTimeCircle.fillAmount >= 1)
        {
            mi_LeftTimeCircle.fillAmount = 1;
        }
    }

    /// <summary>
    /// 점수를 증가시켜주는 함수
    /// </summary>
    public void v_IncreaseScore()
    {
        md_score = md_score + 10;
    }

    /// <summary>
    /// 다음 씬으로 연결해주는 함수
    /// </summary>
    private void v_NextScene()
    {
        SceneManager.LoadScene("0_03Starting");
    }

    /// <summary>
    /// 남은 시간을 증가시켜주는 함수
    /// </summary>
    public void v_IncreaseTime()
    {
        mi_LeftTimeCircle.fillAmount += 0.005f;
    }
}
