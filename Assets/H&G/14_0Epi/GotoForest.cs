/*
 * - Name : DoorClickEvent.cs
 * - Writer : 유희수
 * 
 * - Content : 마녀 집을 벗어나 숲으로 가는 스크립트를 통한 스토리 진행
 *
 * - History
 * 1) 2021-08-27 : 초기 개발
 * 2) 2021-08-30 : 코드 획일화 및 주석 처리
 * 
 * - Variable 
 * mg_Hansel                                        헨젤 오브젝트 연결을 위한 변수
 * mg_Gretel                                        그레텔 오브젝트 연결을 위한 변수
 * mg_Witch                                         마녀 오브젝트 연결을 위한 변수

 * mvm_VoiceManager                                 나레이션을 위한 변수
 * mb_PlayFirstVoice                                첫번째 나레이션의 실행 유무를 위한 flag
 * mv3_HanselPos                                    헨젤의 목적지 
 * mv3_GretelPos                                    그레텔의 목적지
 * 
 * - Function
 * v_ChangeNextScene()                              다음 씬으로 넘어가기 위한 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoForest : MonoBehaviour
{
    //오브젝트 연결
    private GameObject mg_Hansel;
    private GameObject mg_Gretel;
    private GameObject mg_Witch;
    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;
    private Vector3 mv3_HanselPos = new Vector3(90, -4f, -6);
    private Vector3 mv3_GretelPos = new Vector3(88, -4f, -6);
    void Start(){
        mg_Hansel = GameObject.Find("hansel");
        mg_Gretel = GameObject.Find("gretel");
        mg_Witch = GameObject.Find("witch");
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        // 음성출력이 안됐다면
        if (!mb_PlayFirstVoice){
            // 22번째 음성 출력
            mvm_VoiceManager.playVoice(22);
            mb_PlayFirstVoice = true;
        }
    }
    void Update(){
        // 헨젤과 그레텔을 목적지로 이동시켜준다
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_HanselPos, 0.04f);
        mg_Gretel.transform.position = Vector3.MoveTowards(mg_Gretel.transform.position, mv3_GretelPos, 0.04f);
        // 마녀는 헨젤과 그레텔보다 느리게 이동시킨다
        mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(15, -2.47f, 0), 0.02f);

        // 헨젤과 그레텔이 목적지에 도착하면 다음씬으로 이동시킨다
        if(mg_Hansel.transform.position == mv3_HanselPos && mb_PlayFirstVoice && mvm_VoiceManager.isPlaying() == false){
            Invoke("v_ChangeNextScene", 1f);
        }
    }
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_14H&G");
    }
}
