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
 * 3) 2021-08-10 : 3개이상 모이면 터지게 설정, 아이템이 빈곳이 있으면 재생성되게 설정
 * 4) 2021-08-12 : 상하좌우 드래그시 3개이상 모이면 터지는 함수 작성
 * 
 * - Variable 
 * mg_GameDirector                                  오브젝트 연결을 위한 변수 -> 게임디렉터 오브젝트 내 다른 속성에 접근할때 사용한다.
 * ma2_ItemArray                                    아이템 배치값을 저장해두는 2차원 배열 
 * ms_TextArray                                     아이템 배치값을 저장해두는 String
 * mf_delta                                         흐른 시간을 저장해두는 변수
 * mn_i                                             처음 아이템 생성을 위해 사용되는 변수
 * mn_cursor                                        값이 같은지 확인하기 위해 값을 저장해 두는 변수
 * mn_Rowdistance                                   가로로 같은 아이템이 얼만큼 있는지 거리를 저장해두는 변수
 * mn_ColDistance                                   세로로 같은 아이템이 얼만큼 있는지 거리를 저장해두는 변수
 * mb_RowBreakFlag                                  가로로 중복아이템 검사중 다른 아이템이 나오는 경우 반복문을 빠져나오기 위한 Flag
 * mb_ColBreakFlag                                  세로로 중복아이템 검사중 다른 아이템이 나오는 경우 반복문을 빠져나오기 위한 Flag
 * mb_InitGenItemFlag                               처음 아이템 생성을 완료하였는지 확인하기 위한 Flag
 * mb_SwapFlag                                      아이템이 스왑행동이 가능한 상태인지 저장해두는 Flag
 * mb_FailToDragFlag                                스왑 행동이 실패하는 경우 확인을 위한 Flag
 * mb_DragFlag                                      아이템이 스왑행동이 가능한 상태인지 저장해두는 Flag
 * mn_j, mn_k                                       스왑할때 스왑하는 아이템의 행렬을 저장해두는 변수
 * mg_Col1                                          연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
 * mg_Col2                                          연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수
 * mg_Col3                                          연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수
 * mg_Col4                                          연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수
 * mg_Col5                                          연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수
 * mg_Col6                                          연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수
 * mg_Col7                                          연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수
 * mg_TempGameObject                                아이템 스왑시 해당 오브젝트에 접근하기위한 변수
 * 
 * 
 * 
 * - Function   
 * v_InitItemArray()                                처음 아이템 관리 배열을 생성해주는 함수
 * v_ShowItemArray()                                아이템 관리 배열을 출력해주는 함수
 * v_ChangeSwapFalgTrue()                           아이템 스왑 가능상태로 바꿔주는 함수
 * v_ChangeSwapFlagFalse()                          아이템 스왑 불가능상태로 바꿔주는 함수
 * b_RetrunSwapFlag()                               스왑 가능한 상태인지 확인해주는 Flag를 반환해주는 함
 * v_DragToUp(GameObject gItem)                     아이템을 위로 드래그하는 경우 작동하는 함수, 아이템을 위로 올리고 위의 아이템을 아래로 내린다.
 * v_DragToDown(GameObject gItem)                   아이템을 아래로 드래그하는 경우 작동하는 함수, 아이템을 아래로 내리고 아래의 아이템을 위로 올린다.
 * v_DragToRight(GameObject gItem)                  아이템을 오른쪽으로 드래그하는 경우 작동하는 함수, 아이템을 오른쪽으로 옮기고 오른쪽에 있던 아이템을 왼쪽으로 옮긴다.
 * v_DragToLeft(GameObject gItem)                   아이템을 왼쪽으로 드래그하는 경우 작동하는 함수, 아이템을 왼쪽으로 옮기고 왼쪽에 있던 아이템을 오른쪽으로 옮긴다.
 * v_ChangeFailToDragFlagFalse()                    아이템 스왑 실패하는 경우 Flag값 False로 변경
 * b_ReturnFailToDragFlag()                         아이템 스왑 실패했는지 관리하는 Flag값 반환
 * b_ReturnDragFlag()                               아이템 드래그 가능한 상태인지 Flag값 반환
 * v_ChangeDragFlagFalse()                          아이템 드래그 불가능한 상태로 변환
 * v_ChangeDragFlagTrue()                           아이템 드래그 가능한 상태로 변환
 * b_InspectArrayIsPop()                            아이템 배열에 아이템이 3개이상 모여 터질것이 있는지 검사하는 함수
 * 
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
    int mn_Rowdistance;                                                     // 가로로 같은 아이템이 얼만큼 있는지 거리를 저장해두는 변수
    int mn_ColDistance;                                                     // 세로로 같은 아이템이 얼만큼 있는지 거리를 저장해두는 변수
    bool mb_RowBreakFlag = false;                                           // 가로로 중복아이템 검사중 다른 아이템이 나오는 경우 반복문을 빠져나오기 위한 Flag
    bool mb_ColBreakFlag = false;                                           // 세로로 중복아이템 검사중 다른 아이템이 나오는 경우 반복문을 빠져나오기 위한 Flag
    bool mb_InitGenItemFlag = false;                                        // 처음 아이템 생성을 완료하였는지 확인하기 위한 Flag
    bool mb_SwapFlag = false;                                               // 아이템이 스왑행동이 가능한 상태인지 저장해두는 Flag
    bool mb_FailToDragFlag = false;                                         // 스왑 행동이 실패하는 경우 확인을 위한 Flag
    bool mb_DragFlag = false;                                               // 아이템이 스왑행동이 가능한 상태인지 저장해두는 Flag
    int mn_j, mn_k;                                                         // 스왑할때 스왑하는 아이템의 행렬을 저장해두는 변수

    GameObject mg_Col1;                                                     // 연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
    GameObject mg_Col2;                                                     // 연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수 
    GameObject mg_Col3;                                                     // 연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수 
    GameObject mg_Col4;                                                     // 연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수 
    GameObject mg_Col5;                                                     // 연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수 
    GameObject mg_Col6;                                                     // 연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수 
    GameObject mg_Col7;                                                     // 연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수 
    GameObject mg_TempGameObject;                                           // 아이템 스왑시 해당 오브젝트에 접근하기위한 변수

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 연결
        mg_GameDirector = GameObject.Find("GameDirector");
        mg_Col1 = GameObject.Find("Col1");
        mg_Col2 = GameObject.Find("Col2");
        mg_Col3 = GameObject.Find("Col3");
        mg_Col4 = GameObject.Find("Col4");
        mg_Col5 = GameObject.Find("Col5");
        mg_Col6 = GameObject.Find("Col6");
        mg_Col7 = GameObject.Find("Col7");

        v_InitItemArray();                                                    // 아이템 관리 배열 생성
        v_ShowItemArray();                                                    // 생성된 아이템 관리배열을 로그에 출력
    }

    // Update is called once per frame
    void Update()
    {
        // 초기 아이템 7x6 생성
        this.mf_delta += Time.deltaTime;
        if (this.mf_delta > 0.5f && mb_InitGenItemFlag == false)
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
            {
                mb_InitGenItemFlag = true;
                mb_DragFlag = true;
            }
        }

        //터지는거 확인
        if (mg_GameDirector.GetComponent<ManageItem>().b_ReturnIsStopFlag() == true)                // 움직이지 않는 상태인지 확인하고 실행
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    mn_Rowdistance = 1;
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
                                        if(mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 11;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 11;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 11:
                                    if (j != 0)
                                    {
                                        if(ma2_ItemArray[i, j - 1] == 1 || ma2_ItemArray[i, j - 1] == 11)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 11;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 11;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 2:
                                    if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 12;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 12;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 12:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 1 || ma2_ItemArray[i, j - 1] == 11)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 12;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 12;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 3:
                                    if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 13;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 13;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 13:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 3 || ma2_ItemArray[i, j - 1] == 13)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 13;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 13;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 4:
                                    if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 14;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 14;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 14:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 4 || ma2_ItemArray[i, j - 1] == 14)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 14;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 14;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 5:
                                    if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 15;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 15;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 15:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 5 || ma2_ItemArray[i, j - 1] == 15)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 15;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 15;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 6:
                                    if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 16;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 16;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 16:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 6 || ma2_ItemArray[i, j - 1] == 16)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 16;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 16;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 7:
                                    if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 17;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 17;
                                        }
                                        mb_RowBreakFlag = true;
                                    }
                                    break;
                                case 17:
                                    if (j != 0)
                                    {
                                        if (ma2_ItemArray[i, j - 1] == 7 || ma2_ItemArray[i, j - 1] == 17)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                    {
                                        mb_RowBreakFlag = true;
                                        if (mn_Rowdistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_Rowdistance : " + mn_Rowdistance);

                                            for (int n = 0; n < mn_Rowdistance; n++)
                                            {
                                                ma2_ItemArray[i, j + n] = 17;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                    {
                                        mn_Rowdistance++;
                                    }

                                    if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && mn_Rowdistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_Rowdistance : " + mn_Rowdistance);

                                        for (int n = 0; n < mn_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 17;
                                        }
                                        mb_RowBreakFlag = true;
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
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 11;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 11;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 11:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 1 || ma2_ItemArray[i, k] == 11)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 1 && ma2_ItemArray[k, j] != 11)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 11;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 1 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 11;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 2:
                                    if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 12;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 12;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 12:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 2 || ma2_ItemArray[i, k] == 12)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 12;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 2 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 12;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 3:
                                    if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 13;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 13;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 13:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 3 || ma2_ItemArray[i, k] == 13)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 13;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 3 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 13;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 4:
                                    if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 14;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 14;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 14:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 4 || ma2_ItemArray[i, k] == 14)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 14;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 4 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 14;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 5:
                                    if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 15;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 15;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 15:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 5 || ma2_ItemArray[i, k] == 15)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 15;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 5 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 15;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 6:
                                    if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 16;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 16;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 16:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 6 || ma2_ItemArray[i, k] == 16)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 16;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 6 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 16;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 7:
                                    if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 17;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 17;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                                case 17:
                                    if (i != 0)
                                    {
                                        if (ma2_ItemArray[i - 1, k] == 7 || ma2_ItemArray[i, k] == 17)
                                        {
                                            mb_RowBreakFlag = true;
                                            break;
                                        }
                                    }
                                    if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                    {
                                        mb_ColBreakFlag = true;
                                        if (mn_ColDistance >= 3)
                                        {
                                            Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_ColDistance : " + mn_ColDistance);

                                            for (int n = 0; n < mn_ColDistance; n++)
                                            {
                                                ma2_ItemArray[i + n, j] = 17;
                                            }
                                        }
                                        break;
                                    }
                                    else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                    {
                                        mn_ColDistance++;
                                    }

                                    if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && mn_ColDistance >= 3))
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " mn_cursor : 7 mn_ColDistance : " + mn_ColDistance);

                                        for (int n = 0; n < mn_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 17;
                                        }
                                        mb_ColBreakFlag = true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            v_ShowItemArray();

            // 아이템 삭제
            for (int i=0; i<6; i++)
            {
                for (int j=0; j<7; j++)
                {
                    if(ma2_ItemArray[i,j] > 10)
                    {
                        mb_DragFlag = false;
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
            v_ShowItemArray();
            // 빈 공간 새로운 아이템으로 채움
            for (int i = 5; i > -1; i--)
            {
                if (this.mf_delta > 0.5f)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (ma2_ItemArray[i, j] == 99)
                        {
                            ma2_ItemArray[i, j] = Random.Range(1, 8);
                            mg_GameDirector.GetComponent<ManageItem>().v_GenItem(ma2_ItemArray[i, j], (j + 1));
                            this.mf_delta = 0;
                        }
                    }
                }
            }
            mb_DragFlag = true;
            v_ShowItemArray();
        }

        if (mg_GameDirector.GetComponent<ManageItem>().b_ReturnIsStopFlag() == true)
            mb_SwapFlag = true;
        else
            mb_SwapFlag = false;
    }

    #region 함수 선언부

    /// <summary>
    /// 처음 아이템 관리 배열을 생성해주는 함수
    /// </summary>
    public void v_InitItemArray()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                ma2_ItemArray[i, j] = Random.Range(1, 8);           //아이템 범위 지정 (초기값:8)
            }
        }
    }

    /// <summary>
    /// 아이템 관리 배열을 출력해주는 함수
    /// </summary>
    public void v_ShowItemArray()
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

    /// <summary>
    /// 아이템 스왑 가능상태로 바꿔주는 함수
    /// </summary>
    public void v_ChangeSwapFalgTrue()
    {
        mb_SwapFlag = true;
    }

    /// <summary>
    /// 아이템 스왑 불가능상태로 바꿔주는 함수
    /// </summary>
    public void v_ChangeSwapFlagFalse()
    {
        mb_SwapFlag = false;
    }

    /// <summary>
    /// 스왑 가능한 상태인지 확인해주는 Flag를 반환해주는 함수
    /// </summary>
    /// <returns>드래그 가능한 상태인지 Flag값 반환</returns>
    public bool b_RetrunSwapFlag()
    {
        return mb_SwapFlag;
    }

    /// <summary>
    /// 아이템을 위로 드래그하는 경우 작동하는 함수, 아이템을 위로 올리고 위의 아이템을 아래로 내린다.
    /// </summary>
    /// <param name="gItem">위로 올리는 아이템 객체</param>
    public void v_DragToUp(GameObject gItem)
    {
        v_ChangeSwapFalgTrue();
        int ItemPositionX = (int)gItem.transform.position.x;
        int ItemPositionY = (int)gItem.transform.position.y;
        //Debug.Log("x : " + ItemPositionX + " y : " + ItemPositionY);

        switch (ItemPositionX)
        {
            case -6:
                mn_k = 0;
                break;
            case -4:
                mn_k = 1;
                break;
            case -2:
                mn_k = 2;
                break;
            case 0:
                mn_k = 3;
                break;
            case 2:
                mn_k = 4;
                break;
            case 4:
                mn_k = 5;
                break;
            case 6:
                mn_k = 6;
                break;
        }
        switch (ItemPositionY)
        {
            case 5:
                mn_j = 0;
                break;
            case 3:
                mn_j = 1;
                break;
            case 1:
                mn_j = 2;
                break;
            case 0:
                mn_j = 3;
                break;
            case -1:
                mn_j = 4;
                break;
            case -3:
                mn_j = 5;
                break;
        }
        Debug.Log("바꿀아이템 좌표 : j : " + mn_j + " k : " + mn_k);
        if (mn_j == 0)
        {
            Debug.Log("맨 위 아이템은 위로 드래그 불가능");
            mb_FailToDragFlag = true;
            return;
        }
        else
        {
            // 위치 이동
            gItem.transform.position = new Vector2(gItem.transform.position.x, gItem.transform.position.y + 2);
            // Child 순서 변경
            gItem.transform.SetSiblingIndex(gItem.transform.GetSiblingIndex() + 1);

            // 배열 이동
            int temp = ma2_ItemArray[mn_j, mn_k];
            ma2_ItemArray[mn_j, mn_k] = ma2_ItemArray[mn_j - 1, mn_k];
            ma2_ItemArray[mn_j - 1, mn_k] = temp;
        }

    }

    /// <summary>
    /// 아이템을 아래로 드래그하는 경우 작동하는 함수, 아이템을 아래로 내리고 아래의 아이템을 위로 올린다.
    /// </summary>
    /// <param name="gItem">옮기는 객체</param>
    public void v_DragToDown(GameObject gItem)
    {
        v_ChangeSwapFalgTrue();
        int ItemPositionX = (int)gItem.transform.position.x;
        int ItemPositionY = (int)gItem.transform.position.y;
        //Debug.Log("x : " + ItemPositionX + " y : " + ItemPositionY);

        switch (ItemPositionX)
        {
            case -6:
                mn_k = 0;
                break;
            case -4:
                mn_k = 1;
                break;
            case -2:
                mn_k = 2;
                break;
            case 0:
                mn_k = 3;
                break;
            case 2:
                mn_k = 4;
                break;
            case 4:
                mn_k = 5;
                break;
            case 6:
                mn_k = 6;
                break;
        }
        switch (ItemPositionY)
        {
            case 5:
                mn_j = 0;
                break;
            case 3:
                mn_j = 1;
                break;
            case 1:
                mn_j = 2;
                break;
            case 0:
                mn_j = 3;
                break;
            case -1:
                mn_j = 4;
                break;
            case -3:
                mn_j = 5;
                break;
        }
        Debug.Log("바꿀아이템 좌표 : j : " + mn_j + " k : " + mn_k);
        if (mn_j == 5)
        {
            Debug.Log("맨 아래 아이템은 아래로 드래그 불가능");
            mb_FailToDragFlag = true;
            return;
        }
        else
        {
            // 위치 이동
            gItem.transform.position = new Vector2(gItem.transform.position.x, gItem.transform.position.y - 2);
            // Child 순서 변경
            gItem.transform.SetSiblingIndex(gItem.transform.GetSiblingIndex() - 1);

            // 배열 이동
            int temp = ma2_ItemArray[mn_j, mn_k];
            ma2_ItemArray[mn_j, mn_k] = ma2_ItemArray[mn_j + 1, mn_k];
            ma2_ItemArray[mn_j + 1, mn_k] = temp;
        }

    }

    /// <summary>
    /// 아이템을 오른쪽으로 드래그하는 경우 작동하는 함수, 아이템을 오른쪽으로 옮기고 오른쪽에 있던 아이템을 왼쪽으로 옮긴다.
    /// </summary>
    /// <param name="gItem">옮기는 객체</param>
    public void v_DragToRight(GameObject gItem)
    {
        v_ChangeSwapFalgTrue();
        int ItemPositionX = (int)gItem.transform.position.x;
        int ItemPositionY = (int)gItem.transform.position.y;
        int n_Index = gItem.transform.GetSiblingIndex();
        //Debug.Log("x : " + ItemPositionX + " y : " + ItemPositionY);

        switch (ItemPositionX)
        {
            case -6:
                mn_k = 0;
                break;
            case -4:
                mn_k = 1;
                break;
            case -2:
                mn_k = 2;
                break;
            case 0:
                mn_k = 3;
                break;
            case 2:
                mn_k = 4;
                break;
            case 4:
                mn_k = 5;
                break;
            case 6:
                mn_k = 6;
                break;
        }
        switch (ItemPositionY)
        {
            case 5:
                mn_j = 0;
                break;
            case 3:
                mn_j = 1;
                break;
            case 1:
                mn_j = 2;
                break;
            case 0:
                mn_j = 3;
                break;
            case -1:
                mn_j = 4;
                break;
            case -3:
                mn_j = 5;
                break;
        }
        Debug.Log("바꿀아이템 좌표 : j : " + mn_j + " k : " + mn_k);
        if (mn_k == 6)
        {
            Debug.Log("맨 오른쪽 아이템은 오른쪽으로 드래그 불가능");
            mb_FailToDragFlag = true;
            return;
        }
        else
        {
            // 위치 이동
            gItem.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
            // Child 순서 변경
            switch (gItem.transform.parent.name)
            {
                case "Col1":                   
                    mg_TempGameObject = mg_Col2.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col2.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col1.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
                case "Col2":
                    mg_TempGameObject = mg_Col3.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col3.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col2.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
                case "Col3":
                    mg_TempGameObject = mg_Col4.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col4.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col3.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
                case "Col4":
                    mg_TempGameObject = mg_Col5.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col5.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col4.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
                case "Col5":
                    mg_TempGameObject = mg_Col6.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col6.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col5.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
                case "Col6":
                    mg_TempGameObject = mg_Col7.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col7.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col6.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
                    break;
            }
            //gItem.transform.SetSiblingIndex(gItem.transform.GetSiblingIndex() - 1);

            // 배열 이동
            int temp = ma2_ItemArray[mn_j, mn_k];
            ma2_ItemArray[mn_j, mn_k] = ma2_ItemArray[mn_j, mn_k + 1];
            ma2_ItemArray[mn_j, mn_k + 1] = temp;
        }

    }

    /// <summary>
    /// 아이템을 왼쪽으로 드래그하는 경우 작동하는 함수, 아이템을 왼쪽으로 옮기고 왼쪽에 있던 아이템을 오른쪽으로 옮긴다.
    /// </summary>
    /// <param name="gItem">옮기는 아이템</param>
    public void v_DragToLeft(GameObject gItem)
    {
        v_ChangeSwapFalgTrue();
        int ItemPositionX = (int)gItem.transform.position.x;
        int ItemPositionY = (int)gItem.transform.position.y;
        int n_Index = gItem.transform.GetSiblingIndex();
        //Debug.Log("x : " + ItemPositionX + " y : " + ItemPositionY);

        switch (ItemPositionX)
        {
            case -6:
                mn_k = 0;
                break;
            case -4:
                mn_k = 1;
                break;
            case -2:
                mn_k = 2;
                break;
            case 0:
                mn_k = 3;
                break;
            case 2:
                mn_k = 4;
                break;
            case 4:
                mn_k = 5;
                break;
            case 6:
                mn_k = 6;
                break;
        }
        switch (ItemPositionY)
        {
            case 5:
                mn_j = 0;
                break;
            case 3:
                mn_j = 1;
                break;
            case 1:
                mn_j = 2;
                break;
            case 0:
                mn_j = 3;
                break;
            case -1:
                mn_j = 4;
                break;
            case -3:
                mn_j = 5;
                break;
        }
        Debug.Log("바꿀아이템 좌표 : j : " + mn_j + " k : " + mn_k);
        if (mn_k == 0)
        {
            Debug.Log("맨 왼쪽 아이템은 왼쪽으로 드래그 불가능");
            mb_FailToDragFlag = true;
            return;
        }
        else
        {
            // 위치 이동
            gItem.transform.position = new Vector2(gItem.transform.position.x - 2, gItem.transform.position.y);
            // Child 순서 변경
            switch (gItem.transform.parent.name)
            {
                case "Col2":
                    mg_TempGameObject = mg_Col1.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col1.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col2.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
                case "Col3":
                    mg_TempGameObject = mg_Col2.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col2.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col3.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
                case "Col4":
                    mg_TempGameObject = mg_Col3.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col3.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col4.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
                case "Col5":
                    mg_TempGameObject = mg_Col4.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col4.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col5.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
                case "Col6":
                    mg_TempGameObject = mg_Col5.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col5.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col6.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
                case "Col7":
                    mg_TempGameObject = mg_Col6.transform.GetChild(n_Index).gameObject;
                    gItem.transform.SetParent(mg_Col6.transform);
                    gItem.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.SetParent(mg_Col7.transform);
                    mg_TempGameObject.transform.SetSiblingIndex(n_Index);
                    mg_TempGameObject.transform.position = new Vector2(gItem.transform.position.x + 2, gItem.transform.position.y);
                    break;
            }
            //gItem.transform.SetSiblingIndex(gItem.transform.GetSiblingIndex() - 1);

            // 배열 이동
            int temp = ma2_ItemArray[mn_j, mn_k];
            ma2_ItemArray[mn_j, mn_k] = ma2_ItemArray[mn_j, mn_k - 1];
            ma2_ItemArray[mn_j, mn_k - 1] = temp;
        }

    }

    /// <summary>
    /// 아이템 스왑 실패하는 경우 Flag값 False로 변경
    /// </summary>
    public void v_ChangeFailToDragFlagFalse()
    {
        mb_FailToDragFlag = false;
    }

    /// <summary>
    /// 아이템 스왑이 실패한 상황인지 전달해주는 함수
    /// </summary>
    /// <returns></returns>
    public bool b_ReturnFailToDragFlag()
    {
        return mb_FailToDragFlag;
    }

    /// <summary>
    /// 드래그가 가능한 상태인지 Flag값 반환
    /// </summary>
    /// <returns></returns>
    public bool b_ReturnDragFlag()
    {
        return mb_DragFlag;
    }

    /// <summary>
    /// 드래그 불가능한 상태로 변경
    /// </summary>
    public void v_ChangeDragFlagFalse()
    {
        mb_DragFlag = false;
    }

    /// <summary>
    /// 드래그 가능한 상태로 변경
    /// </summary>
    public void v_ChangeDragFlagTrue()
    {
        mb_DragFlag = true;
    }

    /// <summary>
    ///  아이템 배열에 아이템이 3개이상 모여 터질것이 있는지 검사하는 함수
    /// </summary>
    /// <returns>터질것이 있는경우 True반환</returns>
    public bool b_InspectArrayIsPop()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                mn_Rowdistance = 1;
                mn_ColDistance = 1;
                mn_cursor = ma2_ItemArray[i, j];
                mb_RowBreakFlag = false;
                mb_ColBreakFlag = false;
                for (int k = j + 1; k < 7; k++)
                {
                    if(mb_RowBreakFlag == false)
                    {
                        // 가로로 확인
                        switch (mn_cursor)
                        {
                            case 1:
                                if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                {
                                    if (mn_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        mb_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                {
                                    mn_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && mn_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
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
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                {
                                    if (mn_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        mb_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                {
                                    mn_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && mn_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                        }
                    }
                }
            }
        }
        return false;
    }
    #endregion
}
