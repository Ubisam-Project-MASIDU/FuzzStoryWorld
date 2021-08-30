/*
 * - Name : DoorClickEvent.cs
 * - Writer : �����
 * 
 * - Content : ���� ���� ��� ������ ���� ��ũ��Ʈ�� ���� ���丮 ����
 *
 * - History
 * 1) 2021-08-27 : �ʱ� ����
 * 2) 2021-08-30 : �ڵ� ȹ��ȭ �� �ּ� ó��
 * 
 * - Variable 
 * mg_Hansel                                        ���� ������Ʈ ������ ���� ����
 * mg_Gretel                                        �׷��� ������Ʈ ������ ���� ����
 * mg_Witch                                         ���� ������Ʈ ������ ���� ����

 * mvm_VoiceManager                                 �����̼��� ���� ����
 * mb_PlayFirstVoice                                ù��° �����̼��� ���� ������ ���� flag
 * mv3_HanselPos                                    ������ ������ 
 * mv3_GretelPos                                    �׷����� ������
 * 
 * - Function
 * v_ChangeNextScene()                              ���� ������ �Ѿ�� ���� �Լ�
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoForest : MonoBehaviour
{
    //������Ʈ ����
    private GameObject mg_Hansel;
    private GameObject mg_Gretel;
    private GameObject mg_Witch;
    private VoiceManager mvm_VoiceManager;
    private bool mb_PlayFirstVoice = false;
    private Vector3 mv3_HanselPos = new Vector3(90, -4f, -6);
    private Vector3 mv3_GretelPos = new Vector3(88, -4f, -6);
    GameObject mg_SoundManager;

    bool mb_Runing = false;

    bool mb_Runing1 = false;

    bool mb_Runing2 = false;
    void Start(){
        mg_Hansel = GameObject.Find("hansel");
        mg_Gretel = GameObject.Find("gretel");
        mg_Witch = GameObject.Find("witch");
         mg_SoundManager = GameObject.Find("SoundManager");                 // 사운드 매니저 게임오브젝트 연결
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        // ��������� �ȵƴٸ�
        if (!mb_PlayFirstVoice){
            // 22��° ���� ���
            mvm_VoiceManager.playVoice(22);
            mb_PlayFirstVoice = true;
        }
    }
    void Update(){
        // ������ �׷����� �������� �̵������ش�
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_HanselPos, 0.04f);

        if(mb_Runing == false){
            mg_SoundManager.GetComponent<SoundManager>().playSound("Runing");     // 게임 끝 버튼 효과음 재생
        }
        mb_Runing = true;
        
        mg_Gretel.transform.position = Vector3.MoveTowards(mg_Gretel.transform.position, mv3_GretelPos, 0.04f);
        
        if(mb_Runing1 == false){
            mg_SoundManager.GetComponent<SoundManager>().playSound("Runing1");     // 게임 끝 버튼 효과음 재생
        }
        mb_Runing1 = true;

        mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(15, -2.47f, 0), 0.02f);

        if(mb_Runing2 == false){
            mg_SoundManager.GetComponent<SoundManager>().playSound("Runing2");     // 게임 끝 버튼 효과음 재생
        }
        mb_Runing2 = true;

        // ������ �׷����� �������� �����ϸ� ���������� �̵���Ų��
        if(mg_Hansel.transform.position == mv3_HanselPos && mb_PlayFirstVoice && mvm_VoiceManager.isPlaying() == false){
            Invoke("v_ChangeNextScene", 1f);
        }
    }
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_14H&G");
    }
}
