/*
 * - Name : CaptionControl.cs
 * - Writer : �����
 * 
 * - Content : �ڸ��� ��Ʈ���ؼ�, ������ �°� �ڸ��� ����ϴ� ��ũ��Ʈ
 *
 * - History
 * 1) 2021-08-24 : �ʱ� ����
 * 2) 2021-08-26 : �ڵ� ����
 * 3) 2021-08-30 : �ּ� �ޱ� & ������ ȹ��ȭ
 * 
 * - Variable 
 * mn_LangIndex                                     ���� ������� ������ ��� ������ ���� �ε���  
 * mn_VoiceIndex                                    ���� ������� ������ index�� �˷���
 * mg_CaptionPanel                                  �ڸ��� ��µǴ� �г�UI ����
 * mt_CaptionText                                   �� ���� �ڸ��� �ٲٱ� ���� �ؽ�Ʈ ����
 * mvm_VoiceManager                                 �����̼��� ���� ����
 * mb_playOne                                       ù��° �����̼��� ���� ������ ���� flag
 * mb_playTwo                                       �ι�° �����̼��� ���� ������ ���� flag
 * 
 * - Function
 * v_GotoDoor()                                     ���� Ŭ���ؼ� ���� ������ �׷����� �ٴٸ����ְ� �ϴ� �Լ�
 * v_TutorialText()                                 �� Ŭ�� �̺�Ʈ ���ø� �����ֱ� ���� Ʃ�丮�� �ؽ�Ʈ�� �ִϸ��̼��� Ȱ��ȭ���ִ� �Լ�
 * v_ChangeNextScene()                              ���� ������ �Ѿ�� ���� �Լ�
 * v_ChangeNextSceneWhenSkipGame()                  ������ ��ŵ�Ǵ°�� ���������� �Ѿ�� ���� �Լ�
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionControl : MonoBehaviour
{
    private VoiceManager mvm_VoiceManager;
    public int mn_LangIndex = 9;
    private GameObject mg_CaptionPanel;
    public GameObject mt_CaptionText;
    public int mn_VoiceIndex = 99;
    private string ms_TextTemp;
    private GameObject OnButton;
    private GameObject OffButton;

    void Start(){
        OnButton = GameObject.Find("On");
        OffButton = GameObject.Find("Off");
        mt_CaptionText = GameObject.Find("Caption");
        mvm_VoiceManager = GameObject.FindObjectOfType<VoiceManager>();
        mg_CaptionPanel = GameObject.Find("CaptionPanel");
        mn_LangIndex = ((int)mvm_VoiceManager.country);
        ms_TextTemp = mvm_VoiceManager.mlva_LanguageVoices[mn_LangIndex].mvifl_setVoiceInfoList[mn_VoiceIndex].words;
        ShowCaption();
    }

    public void ShowCaption(){
        if (mn_LangIndex == 0){ //�ѱ��� ���� -> �ڸ� ���ֱ�
            this.gameObject.SetActive(false);
            OnButton.SetActive(false);
            OffButton.SetActive(false);
        }
        else{
            mt_CaptionText.GetComponent<Text>().text = ms_TextTemp;
        }
    }
}
