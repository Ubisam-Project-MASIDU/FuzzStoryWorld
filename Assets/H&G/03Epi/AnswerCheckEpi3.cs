/*
 * - Name : AnswerCheck.class
 * - Writer : �����
 * - Content : �������׷��� Epi2 �̴ϰ��� - ��� ���������� ���������� ����, ��� �������� ���������� �̵��ϴ� ��ũ��Ʈ
 *  
 * - HISTORY
 * 2021-08-10 : �ʱ� ����
 * 2021-08-12 : �ڵ� ȹ��ȭ �� �ּ�ó��
 *
 * <Variable>
 * mn_count                     ������ � ���������� Ȯ���� ���� ����
 * 
 * <Function>
 * v_CountAnswer()              ������ ���⶧���� ���� ������ �����ִ� �Լ�
 * v_changeNextScene()          ���������� �Ѿ�� �Լ�
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerCheckEpi3 : MonoBehaviour
{
    public int mn_count;
    public GameObject v_YouWinText;

    void Start(){
        mn_count = 0;           //���� ���� ���� 0���� �ʱ�ȭ
        v_YouWinText.SetActive(false);
    }

    //������ ���⶧���� ���� ������ �����ִ� �Լ�
    //������ ��� ���������� ������ Ȯ���ϰ�, �� �������� ���� ������ �̵�
    public void v_CountAnswer(){
        mn_count++;            //���� �ϳ��� �����ش�
        Debug.Log("1");
        if (mn_count == 3){
            Invoke("v_WinText", 1f);
            Invoke("v_changeNextScene", 3f);
        }
    }

    //���� ������ �̵��ϴ� �Լ�
    public void v_changeNextScene(){
        SceneManager.LoadScene("1_04H&G");
    }

    public void v_WinText(){
        v_YouWinText.SetActive(true);
    }
}