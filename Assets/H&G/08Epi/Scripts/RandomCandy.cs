/*
 * - Name : RandomCandy.class
 * - Writer : 이윤교
 * - Content : 헨젤과그레텔 Epi8 미니게임 - 사탕(아이템)을 중복되지않게 랜덤으로 보여주는 스크립트
 * 
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-11 : 코드 획일화 및 주석처리
 * 2021-08-27 : Voice Manager 수정
 *
 * <Variable>
 * mg_RandomItem : RandomItem 오브젝트 연결을 위한 변수
 * mg_GameDirector : GameDirector 오브젝트 연결을 위한 변수
 * mspa_SpriteImage : 아이템 오브젝트 이미지 저장
 * mn_RandomValue : 랜덤 아이템 값 저장해두는 변수
 * mn_leftTime : 남은 아이템 개수 저장해두는 변수
 * mb_ItemFlag : 정답이 바뀌어야되는 타이밍을 알려주는 flag          
 * mb_CheckOncePlaying : 음성이 한번만 나오도록 제어하는 변수
 *
 * <Function>
 * n_n_ReturnAnswer() : 랜덤 아이템 정답 값을 반환해주는 함수
 * v_NextSceneLoad() : 다음 씬으로 넘어가게 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomCandy : MonoBehaviour{
    private GameObject mg_RandomItem;                                                                           // RandomItem 오브젝트 연결을 위한 변수          
    GameObject mg_GameDirector;                                                                                 // GameDirector 오브젝트 연결을 위한 변수                            
    public Sprite[] mspa_SpriteImage = new Sprite[3];                                                           // 아이템 오브젝트 이미지 저장                        
    int mn_RandomValue;                                                                                         // 랜덤 아이템 값 저장해두는 변수                                                    
    int mn_leftTime;                                                                                            // 남은 아이템 개수 저장해두는 변수                       
    bool mb_ItemFlag;                                                                                           // 정답이 바뀌어야되는 타이밍을 알려주는 flag                
    

    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayOnce = false;
    public int mn_PlayVoiceIndex;

    void Start(){
        this.mg_GameDirector = GameObject.Find("GameDirector");                                                 // 오브젝트 연결
        this.mg_RandomItem = GameObject.Find("RandomImage");
        mn_RandomValue = mg_GameDirector.GetComponent<CandyControl>().n_RandomItemValue();                      // 랜덤 값 저장
        this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];            // 해당 랜덤 값에 맞는 아이템 이미지 변경
        mb_ItemFlag = false;                                                                                    // Flag 값 False 로 초기화                                  
        
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
    }
    
    void Update(){
        if (!mb_PlayOnce) {
            mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
            mb_PlayOnce = true;
        }
        mb_ItemFlag = mg_GameDirector.GetComponent<CandyControl>().b_checkFlag();                               // 정답이 바뀌는 Flag값 실시간 업데이트
        if (mb_ItemFlag == true){                                                                               // Flag값이 바뀐경우
            mn_leftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();                      // 남은 아이템 개수 확인
            if(mn_leftTime != 0){                                                                               // 아직 아이템이 남았다면
                mn_RandomValue = mg_GameDirector.GetComponent<CandyControl>().n_RandomItemValue();              // 랜덤값 재할당
                this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];    // 랜덤값에 맞게 아이템 이미지 변경
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagFalse();                               // Flag값 False로 변경
            }
            else if(mn_leftTime == 0){                                                                          // 만약 남은 아이템개수가 0개라면 Clear                            
                Invoke("v_NextSceneLoad", 2.0f);                                                                  // 2초뒤 다음씬 넘어가는 함수 실행
            } 
        }
    }

    // 랜덤 아이템 정답 값을 반환해주는 함수
    public int n_ReturnAnswer(){                                                            
        return mn_RandomValue;
    }
    
    //다음 씬으로 넘어가는 함수
    void v_NextSceneLoad() {
        SceneManager.LoadScene("1_09H&G");
    }
}
