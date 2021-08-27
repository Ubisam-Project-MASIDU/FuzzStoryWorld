/*
 * - Name : Treasure.cs
 * - Writer : 김명현, 이병권
 * 
 * - Content :
 * 보물을 점수에따라 점점 증가시키는 스크립트
 * 1) 골드가 모으면 소리가 난다
 *
 * - History
 * 1) 2021-08-20 : 점수에 따라 점점 보물이 증가되게 설정
 * 2) 2021-08-27 : 점수가 모으면 골드가 생기고 그러면 소리가 난다
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
    bool mb_Gold1 = false;

    bool mb_Gold2 = false;

    bool mb_Gold3 = false;

    bool mb_Gold4 = false;

    bool mb_Gold5 = false;
    bool mb_Gold6 = false;
    bool mb_Gold7 = false;
    GameObject mg_GameDirector;

    GameObject mg_SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");
        mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
    }

    // Update is called once per frame
    void Update()
    {
        if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 700)
        {
            this.transform.localScale = new Vector3(5.5f, 5.5f, 1);
            if(mb_Gold1 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold1");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold1 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 600)
        {
            this.transform.localScale = new Vector3(5f, 5f, 1);
            if(mb_Gold2 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold2");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold2 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 500)
        {
            this.transform.localScale = new Vector3(4.5f, 4.5f, 1);
            if(mb_Gold3 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold3");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold3 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 400)
        {
            this.transform.localScale = new Vector3(4f, 4f, 1);
            if(mb_Gold4 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold4");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold4 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 300)
        {
            this.transform.localScale = new Vector3(3f, 3f, 1);
            if(mb_Gold5 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold5");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold5 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 200)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1);
            if(mb_Gold6 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold6");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold6 = true;
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 100)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1);
            if(mb_Gold7 == false){
                 mg_SoundManager.GetComponent<SoundManager>().playSound("Gold7");     // 게임 끝 버튼 효과음 재생
            }
            mb_Gold7 = true;
        }
    }
}
