using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomCandy : MonoBehaviour
{
    private GameObject mg_RandomItem; 
    GameObject mg_GameDirector;                                                                             // GameDirector 오브젝트 연결을 위한 변수
    public Sprite[] mspa_SpriteImage = new Sprite[3]; 
    int mn_RandomValue;                                                                                     // 랜덤 아이템 값 저장해두는 변수
    int mn_leftTime;                                                                                        // 남은 아이템 개수 저장해두는 변수
    bool mb_ItemFlag;                                                                                       // 정답이 바뀌어야되는 타이밍을 알려주는 flag
    private bool mb_checkShow;
    
    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");                                             // 오브젝트 연결
        this.mg_RandomItem = GameObject.Find("RandomImage");
        mn_RandomValue = mg_GameDirector.GetComponent<CandyControl>().n_RandomItemValue();            // 랜덤 값 저장
        this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];        // 해당 랜덤 값에 맞는 아이템 이미지 변경
        mb_ItemFlag = false; 
    }
    void Update(){
        mb_ItemFlag = mg_GameDirector.GetComponent<CandyControl>().b_checkFlag();                         // 정답이 바뀌는 Flag값 실시간 업데이트
        if (mb_ItemFlag == true){                                                                           // Flag값이 바뀐경우
            mn_leftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();                // 남은 아이템 개수 확인
            if(mn_leftTime != 0){                                                                           // 아직 아이템이 남았다면
                mn_RandomValue = mg_GameDirector.GetComponent<CandyControl>().n_RandomItemValue();    // 랜덤값 재할당
                this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];// 랜덤값에 맞게 아이템 이미지 변경
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagFalse();                         // Flag값 False로 변경
            }
            else if(mn_leftTime == 0){                                                                      // 만약 남은 아이템개수가 0개라면 Clear                            
                SceneManager.LoadScene("1_09H&G");
            } 
        }
    }

    // 랜덤 아이템 정답 값을 반환해주는 함수
    public int n_ReturnAnswer(){                                                            
        return mn_RandomValue; //int 정답 값
    }
}
