/*
 * - Name : Score.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 점수 산정을 위한 스크립트
 * 
 * - History
 * 1) 2021-08-13 : 블록이 터질때 점수가 산정되게 설정
 * 
 * - Variable 
 * mg_Score                                         점수를 출력해주는 오브젝트 연결을 위한 변수
 * md_score                                         점수를 저장해두는 변수    
 * 
 * 
 * - Function
 * v_IncreaseScore                                  점수를 올려주는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수를 계산하고 출력해주는 스크립트
public class Score : MonoBehaviour
{
    GameObject mg_Score;

    double md_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        mg_Score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        mg_Score.GetComponent<Text>().text = "점수 : " + md_score;
    }

    public void v_IncreaseScore()
    {
        md_score = md_score + 1;
    }
}
