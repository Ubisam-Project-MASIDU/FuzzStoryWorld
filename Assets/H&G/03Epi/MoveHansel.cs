/*
 * - Name : MoveHansel.class
 * - Writer : �����
 * - Content : �������׷��� Epi3 - ���丮 ���� ��, �̴ϰ��� �������ִ� ��ũ��Ʈ
 *  
 * - HISTORY
 * 2021-08-10 : �ʱ� ����
 * 2021-08-17 : �ڵ� ȹ��ȭ �� �ּ�ó��
 *
 * <Variable>
 * mg_Hansel                    ���� ������Ʈ ������ ���� ����
 * mv3_TargetPoint              ������ �̵���ų ��ǥ ����
 * mg_PopUp                     �̴ϰ��� ������ ���� �˾�â
 *  
 * <Function>
 * v_NextScene                  ���� ������ �Ѱ��ִ� �Լ�
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveHansel : MonoBehaviour{
    private GameObject mg_Hansel;
    public Vector3 mv3_TargetPoint;
    public GameObject mg_PopUp;
    public VoiceManager mvm_VoiceManager;

    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mvm_VoiceManager.playVoice(15);

        mv3_TargetPoint = new Vector3(-2.7f, -0.8f, -2.5f);                                                       //������ �̵���ų ��ǥ���� ����
        mg_Hansel = GameObject.Find("Hansel");                                                                    //������ ������Ʈ ����
        mg_PopUp.SetActive(false);                                                                                //�˾�â ��Ȱ��ȭ
    }
    
    void Update(){
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_TargetPoint, 0.07f); //���� ������Ʈ�� mv3_TargetPoint��ġ�� 0.07f�� �ӷ����� ���� �Լ�
        Invoke("popup", 5f);
    }

    void popup()
    {
        mg_PopUp.SetActive(true);
    }
    public void v_NextScene(){
        SceneManager.LoadScene("1_03H&G_Game");
    }
}
