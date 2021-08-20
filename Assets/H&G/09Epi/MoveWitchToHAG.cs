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

public class MoveWitchToHAG : MonoBehaviour
{
    private GameObject mg_Witch;
    private Vector3 mv3_TargetPoint;
    //public GameObject mg_PopUp;

    void Start()
    {
        mv3_TargetPoint = new Vector3(7.2f, 5.8f, -9f);                                                       //������ �̵���ų ��ǥ���� ����
        mg_Witch = GameObject.Find("witch");                                                                    //������ ������Ʈ ����
        //mg_PopUp.SetActive(false);                                                                                //�˾�â ��Ȱ��ȭ
    }

    void Update()
    {
        mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_TargetPoint, 0.08f); //���� ������Ʈ�� mv3_TargetPoint��ġ�� 0.07f�� �ӷ����� ���� �Լ�
        Debug.Log("ù��° ��ũ��Ʈ");
        //Invoke("v_NextScene", 5f);
    }

    public void v_NextScene()
    {
        //mg_PopUp.SetActive(true);
        SceneManager.LoadScene("1_03H&G_Game");
    }
}