/*
 * - Name : ResetButton.cs
 * - Writer : �����
 * 
 * - Content :
 * ������ ���������� ���� ������Ű�� ��ũ��Ʈ
 * 
 * - History
 * 1) 2021-08-20 : ������ ���� ���� ������ �����ǰ� ����
 * 
 * - Variable 
 * mg_GameDirector                      ���� ���� ������Ʈ�� �����ϱ� ���� ����
 * 
 * - Function   
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���������� ���� ������Ű�� ��ũ��Ʈ
public class Treasure : MonoBehaviour
{
    GameObject mg_GameDirector;

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 700)
        {
            this.transform.localScale = new Vector3(5.5f, 5.5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 600)
        {
            this.transform.localScale = new Vector3(5f, 5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 500)
        {
            this.transform.localScale = new Vector3(4.5f, 4.5f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 400)
        {
            this.transform.localScale = new Vector3(4f, 4f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 300)
        {
            this.transform.localScale = new Vector3(3f, 3f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 200)
        {
            this.transform.localScale = new Vector3(2f, 2f, 1);
        }
        else if (mg_GameDirector.GetComponent<ControlUI>().d_ReturnScore() >= 100)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
