/*
 * - Name : ManageArray.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 정답배열을 관리해주는 스크립트이자 메인 스크립트이다.
 * 
 * - History
 * 1) 2021-08-05 : 아이템들을 생성하는 함수 작성
 * 2) 2021-08-06 : 아이템들을 삭제하는 함수 작성, 모두 정지상태인지 확인하는 함수 작성
 *  
 * - Variable 
 * mg_GameDirector                                  오브젝트 연결을 위한 변수 -> 게임디렉터 오브젝트 내 다른 속성에 접근할때 사용한다.
 * ma2_ItemArray                                    아이템 배치값을 저장해두는 2차원 배열 
 * ms_TextArray                                     아이템 배치값을 저장해두는 String
 * 
 * 
 * 
 * - Function
 * v_GenItem(int ItemNumber, int ColNumber)         아이템을 생성해주는 함수
 * v_DestroyObject(int ColNumber, int ChildNumber)  아이템을 삭제해주는 함수
 * v_IsStop()                                       모든 아이템들이 정지상태인지 확인해주는 함수, 각 세로줄에 아이템이 6개면 정지상태로 간주한다.
 * b_ReturnIsStopFlag()                             모든 아이템들이 정지상태인지를 저장해둔 Flag값을 반환해준다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 정답배열을 관리해주는 스크립트이자 메인 스크립트이다.
public class ManageArray : MonoBehaviour
{
    GameObject mg_GameDirector;                                             // 오브젝트 연결을 위한 변수 -> 게임디렉터 오브젝트 내 다른 속성에 접근할때 사용한다.
    int[,] ma2_ItemArray = new int[6,7];                                    // 아이템 배치값을 저장해두는 2차원 배열 
    string ms_TextArray = "아이템 배치표\n";                                // 아이템 배치값을 저장해두는 String
    float mf_delta = 0;                                                     // 흐른 시간을 저장해두는 변수
    int mn_i = 5;                                                           // 

    int cursor;
    int distance;





    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");

        InitItemArray();
        ShowItemArray();

    }

    // Update is called once per frame
    void Update()
    {
        // 초기 아이템 7x6 생성
        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > 1)
        {
            for (int j = 0; j < 7; j++)
            {
                if (mn_i >= 0)
                {
                    mg_GameDirector.GetComponent<ManageItem>().v_GenItem(ma2_ItemArray[mn_i, j], (j + 1));
                }
            }
            this.mf_delta = 0;
            mn_i--;
        }


        //터지는거 확인
        if (mg_GameDirector.GetComponent<ManageItem>().b_ReturnIsStopFlag() == true)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    distance = 1;
                    cursor = ma2_ItemArray[i, j];
                    //가로로 확인
                    for (int k = j + 1; k < 7; k++)
                    {
                        if(cursor == 9)
                        {
                            break;
                        }
                        else if (cursor != ma2_ItemArray[i, k] && distance < 3)
                        {
                            break;
                        }
                        else if (cursor == ma2_ItemArray[i, k] && k <= 6)
                        {
                            distance++;
                        }
                        if (cursor == ma2_ItemArray[i, k] && k == 6 && distance >= 3|| cursor != ma2_ItemArray[i, k] && distance >= 3)
                        {
                            Debug.Log("i : " + i + " j : " + j + " cursor : " + cursor + " distance : " + distance);
                            
                            
                            for (int n = 0; n < distance; n++)
                            {
                                ma2_ItemArray[i, j+n] = 9;
                                mg_GameDirector.GetComponent<ManageItem>().v_DestroyObject(j+n+1, i);
                            }
                            
                            break;
                        }
                    }
                }
            }
            ShowItemArray();
        }



    }

    public void InitItemArray()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                ma2_ItemArray[i, j] = Random.Range(1, 5);           //아이템 범위 지정 (초기값:8)
            }
        }
    }

    public void ShowItemArray()
    {
        ms_TextArray = "아이템 배치표\n";
        for (int i=0; i<6; i++)
        {
            for (int j=0; j<7; j++)
            {
                ms_TextArray = ms_TextArray + ma2_ItemArray[i, j] + " ";
            }
            ms_TextArray += "\n";
        }
        Debug.Log(ms_TextArray);
    }

}
