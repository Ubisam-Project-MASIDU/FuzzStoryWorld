/*
 * - Name : ResetButton.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 보물을 점수에따라 점점 증가시키는 스크립트
 * 
 * - History
 * 1) 2021-08-20 : 점수에 따라 점점 보물이 증가되게 설정
 * 
 * - Variable 
 * mg_GameDirector                      게임 디렉터 오브젝트에 접근하기 위한 변수
 * 
 * - Function   
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 보물을 점수에따라 점점 증가시키는 스크립트
public class Treasure : MonoBehaviour
{
    GameObject mg_GameDirector;

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 700)
        {
            this.transform.localScale = new Vector3(5.5f, 5.5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 600)
        {
            this.transform.localScale = new Vector3(5f, 5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 500)
        {
            this.transform.localScale = new Vector3(4.5f, 4.5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 400)
        {
            this.transform.localScale = new Vector3(4f, 4f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 300)
        {
            this.transform.localScale = new Vector3(3f, 3f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 200)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 100)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
