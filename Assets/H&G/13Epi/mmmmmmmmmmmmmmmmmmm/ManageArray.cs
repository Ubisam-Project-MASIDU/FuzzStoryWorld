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
 * mf_delta                                         흐른 시간을 저장해두는 변수
 * mn_i                                             처음 아이템 생성을 위해 사용되는 변수
 * mn_cursor                                        값이 같은지 확인하기 위해 값을 저장해 두는 변수
 * mn_distance                                      아이템의 같은 값이 얼마나 있는지 저장해두는 변수
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
    int mn_i = 5;                                                           // 처음 아이템 생성을 위해 사용되는 변수
    int mn_cursor;                                                          // 값이 같은지 확인하기 위해 값을 저장해 두는 변수
    int mn_distance;                                                        // 아이템의 같은 값이 얼마나 있는지 저장해두는 변수
    int mn_ColDistance;
    bool mb_RowBreakFlag = false;
    bool mb_ColBreakFlag = false;
    bool mb_InitGenItemFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");                  // 오브젝트 연결

        InitItemArray();                                                    // 아이템 관리 배열 생성
        ShowItemArray();                                                    // 생성된 아이템 관리배열을 로그에 출력
    }

    // Update is called once per frame
    void Update()
    {
        // 초기 아이템 7x6 생성
        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > 1 && mb_InitGenItemFlag == false)
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
            if (mn_i == -1)
                mb_InitGenItemFlag = true;
        }


        //터지는거 확인
        if (mg_GameDirector.GetComponent<ManageItem>().b_ReturnIsStopFlag() == true)                // 움직이지 않는 상태인지 확인하고 실행
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    mn_distance = 1;
                    mn_ColDistance = 1;
                    mn_cursor = ma2_ItemArray[i, j];
                    mb_RowBreakFlag = false;
                    mb_ColBreakFlag = false;
                    // 가로로 확인
                    for (int k = j + 1; k < 7; k++)
                    {
                        // 가로로 확인
                        if(mb_RowBreakFlag == false) {
                            switch (mn_cursor)
                            {
                                case 1:
                                    if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 1 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 1 || ma2_ItemArray[i, k] != 11) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 11;
                                        }
                                    }
                                    break;
                                case 2:
                                    if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 2 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 2 || ma2_ItemArray[i, k] != 12) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 12;
                                        }
                                    }
                                    break;
                                case 3:
                                    if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 3 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 3 || ma2_ItemArray[i, k] != 13) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 13;
                                        }
                                    }
                                    break;
                                case 4:
                                    if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 4 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 4 || ma2_ItemArray[i, k] != 14) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 14;
                                        }
                                    }
                                    break;
                                case 5:
                                    if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 5 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 5 || ma2_ItemArray[i, k] != 15) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 15;
                                        }
                                    }
                                    break;
                                case 6:
                                    if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 6 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 6 || ma2_ItemArray[i, k] != 16) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 16;
                                        }
                                    }
                                    break;
                                case 7:
                                    if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                    {
                                        mn_distance++;
                                    }

                                    if ((ma2_ItemArray[i, k] == 7 && k == 6 && mn_distance >= 3) || ((ma2_ItemArray[i, k] != 7 || ma2_ItemArray[i, k] != 17) && mn_distance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_distance : " + mn_distance);

                                        for (int n = 0; n < mn_distance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 17;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    //세로로 확인
                    for (int k = i + 1; k < 6; k++)
                    {
                        if (mb_ColBreakFlag == false)
                        {
                            switch (mn_cursor)
                            {
                                case 1:
                                    if (ma2_ItemArray[k, j] != 1 && ma2_ItemArray[k, j] != 11)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 1 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 1 || ma2_ItemArray[k, j] != 11 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 11;
                                        }
                                    }
                                    break;
                                case 2:
                                    if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 2 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 2 || ma2_ItemArray[k, j] != 12 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 12;
                                        }
                                    }
                                    break;
                                case 3:
                                    if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 3 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 3 || ma2_ItemArray[k, j] != 13 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 13;
                                        }
                                    }
                                    break;
                                case 4:
                                    if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 4 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 4 || ma2_ItemArray[k, j] != 14 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 14;
                                        }
                                    }
                                    break;
                                case 5:
                                    if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 5 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 5 || ma2_ItemArray[k, j] != 15 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 15;
                                        }
                                    }
                                    break;
                                case 6:
                                    if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 6 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 6 || ma2_ItemArray[k, j] != 16 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 16;
                                        }
                                    }
                                    break;
                                case 7:
                                    if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if ((ma2_ItemArray[k, j] == 7 && k == 5 && mn_ColDistance >= 3) || (ma2_ItemArray[k, j] != 7 || ma2_ItemArray[k, j] != 17 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 17;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            ShowItemArray();

            // 아이템 삭제
            for (int i=0; i<6; i++)
            {
                for (int j=0; j<7; j++)
                {
                    if(ma2_ItemArray[i,j] > 10)
                    {
                        mg_GameDirector.GetComponent<ManageItem>().v_DestroyObject(j + 1, i);
                    }
                }
            }
        }




        // 빈자리 배열 정리
        if(mg_GameDirector.GetComponent<ManageItem>().b_ReturnIsStopFlag() == false && mb_InitGenItemFlag == true)
        {
            // 숫자 값 맨 밑으로 내리고 빈자리 99로 채운다.
            for (int i = 5; i > -1; i--)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (ma2_ItemArray[i, j] > 10)
                    {
                        if (i==0)
                            ma2_ItemArray[i, j] = 99;

                        for (int k = i - 1; k > -1; k--)
                        {
                            if (ma2_ItemArray[k, j] < 10)
                            {
                                ma2_ItemArray[i, j] = ma2_ItemArray[k, j];
                                ma2_ItemArray[k, j] = 99;
                                break;
                            }
                            else if (k <= 0)
                            {
                                ma2_ItemArray[i, j] = 99;
                            }
                        }
                    }
                }
            }
            ShowItemArray();
            for (int i = 5; i > -1; i--)
            {
                if (this.mf_delta > 1)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (ma2_ItemArray[i, j] == 99)
                        {
                            ma2_ItemArray[i, j] = Random.Range(1, 5);
                            mg_GameDirector.GetComponent<ManageItem>().v_GenItem(ma2_ItemArray[i, j], (j + 1));
                            this.mf_delta = 0;
                        }
                    }
                }
            }
            ShowItemArray();
        }
    }

    #region 함수 선언부

    /// <summary>
    /// 처음 아이템 관리 배열을 생성해주는 함수
    /// </summary>
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

    /// <summary>
    /// 아이템 관리 배열을 출력해주는 함수
    /// </summary>
    public void ShowItemArray()
    {
        ms_TextArray = "아이템 배치표\n";
        for (int i=0; i<6; i++)
        {
            for (int j=0; j<7; j++)
            {
                ms_TextArray = ms_TextArray + ma2_ItemArray[i, j] + "\t";
            }
            ms_TextArray += "\n";
        }
        Debug.Log(ms_TextArray);
    }
    #endregion
}
