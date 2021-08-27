/*
 * - Name : TurnPage.cs
 * - Writer : 이병권
 * - Content : 11씬에서 모든 행동이 끝나면 12로 넘어가는 스크립트
 *
 * - Content : 뼈다귀가 다 사라졌을 때 다음 페이지로 넘어감
 *            
 * - HISTORY (수정 기록) 
 * 1) 2021-08-03- 초기 개발
 * 2) 2021-08-11 : 오류 수정
 * 3) 2021-08-12 : 주석 작성 
 * 4) 2021-08-27 : Voice Manager 수정
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnPage : MonoBehaviour
{
   int num = 2;                                                    // 케릭터의 수 2으로 저장하기
    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayOnce = false;
    public int mn_PlayVoiceIndex;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
    }
    void Update(){
        if (!mb_PlayOnce) {
            mvm_VoiceManager.playVoice(mn_PlayVoiceIndex);
            mb_PlayOnce = true;
        }

        if(num<=0){
            Invoke("v_NextSceneLoad", 1.0f);                     // 0이 되면 다음 페이지로 넘어감
        }
    }
    public void Delete(){
        num--;
    }
        //다음 씬으로 넘어가는 함수
    void v_NextSceneLoad() {
        SceneManager.LoadScene("1_12H&G");
    }
}
