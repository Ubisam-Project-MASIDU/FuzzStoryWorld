/*
 * - Name : GotoForest.cs
 * - Writer : 유희수
 * 
 * - Content : 헨젤과 그레텔이 마녀집에서 벗어나 숲속으로 뛰어가는 스토리 진행
 *
 * - History
 * 1) 2021-08-27 : 코드 초기 작성
 * 2) 2021-08-30 : 주석 작성 및 획일화
 * 
 * - Variable 
 * mg_Hansel                                        헨젤 오브젝트 연결
 * mg_Gretel                                        그레텔 오브젝트 연결
 * mg_Witch                                         마녀 오브젝트 연결
 * mvm_VoiceManager                                 VoiceManager 연결
 * mb_PlayFirstVoice                                음성 출력 여부를 판단하기 위한 flag
 * mv3_HanselPos                                    헨젤의 목표지점
 * mv3_GretelPos                                    그레텔의 목표지점
 * 
 * - Function
 * v_ChangeNextScene()                              다음씬으로 넘어가는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoForest : MonoBehaviour{
    private GameObject mg_Hansel;
    private GameObject mg_Gretel;
    private GameObject mg_Witch;
    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;
    private Vector3 mv3_HanselPos = new Vector3(90, -4f, -6);
    private Vector3 mv3_GretelPos = new Vector3(88, -4f, -6);
    GameObject mg_SoundManager;
    bool mb_Runing = false;

    void Start(){
        // 오브젝트 연결
        mg_Hansel = GameObject.Find("hansel");
        mg_Gretel = GameObject.Find("gretel");
        mg_Witch = GameObject.Find("witch");
        // 사운드 매니저 게임오브젝트 연결
        mg_SoundManager = GameObject.Find("SoundManager");                 
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        // 음성 출력 전이라면
        if (!mb_PlayFirstVoice){
            // 22번째 인덱스 출력
            mvm_VoiceManager.playVoice(22);
            mb_PlayFirstVoice = true;
        }
    }
    void Update(){
        // 헨젤과 그레텔을 목표 위치로 이동
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_HanselPos, 7f * Time.deltaTime);
        mg_Gretel.transform.position = Vector3.MoveTowards(mg_Gretel.transform.position, mv3_GretelPos, 7f * Time.deltaTime);
        // 헨젤과 그레텔보다 느리게 이동
        mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(15, -2.47f, 0), 3f * Time.deltaTime);
        // 게임 끝 버튼 효과음 재생
        if (mb_Runing == false){
            //mg_SoundManager.GetComponent<SoundManager>().playSound("Runing"); 
        }
        mb_Runing = true;

        // 헨젤과 그레텔이 목표지점에 도달했다면 다음 씬으로 넘어감
        if(mg_Hansel.transform.position == mv3_HanselPos && mb_PlayFirstVoice && mvm_VoiceManager.isPlaying() == false){
            Invoke("v_ChangeNextScene", 1f);
        }
    }
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_14H&G");
    }
}
