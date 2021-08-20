/*
 * - Name : ManageItemArray.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 아이템 배치값을 관리하는 스크립트
 * 
 * - History
 * 1) 2021-08-20 : 알고리즘 전면 수정
 * 
 * - Variable 
 * ma2_ItemArray                                // 아이템 배치값을 저장해두는 2차원 배열 
 * ms_TextArray                                 // 아이템 배치값을 저장해두는 String
 * 
 * - Function   
 * v_InitItemArray()                            // 처음 아이템 관리 배열을 생성해주는 함수
 * v_ShowItemArray()                            // 아이템 관리 배열 값을 출력해주는 함수
 * b_InspectArrayIsPop()                        // 아이템 배열에 아이템이 3개이상 모여 터질것이 있는지 검사하는 함수
 * v_PopItemInArray()                           // 배열에 3개이상 모인 아이템 10이상의 숫자로 모두 변경해준다.
 * v_RearrangeArray()                           // 터진 아이템들을 모두 위로 올리고 빈자리 새로운 아이템으로 채운다.
 * n_ReturnArrayValue(int ni, int nj)           // 원하는 위치의 원소값 반환
 * v_ReplaceWithLeftValue(int ni, int nj)       // 왼쪽 값과 값 변경
 * v_ReplaceWithRightValue(int ni, int nj)      // 오른쪽 값과 값 변경
 * v_ReplaceWithTopValue(int ni, int nj)        // 윗쪽 값과 값 변경
 * v_ReplaceWithBottomValue(int ni, int nj)     // 아랫쪽 값과 값 변경
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 배치값을 관리하는 스크립트
public class ManageItemArray : MonoBehaviour
{
    int[,] ma2_ItemArray = new int[6, 7];                                   // 아이템 배치값을 저장해두는 2차원 배열 
    string ms_TextArray;                                                    // 아이템 배치값을 저장해두는 String

    // Start is called before the first frame update
    void Start()
    {
        v_InitItemArray();
        v_ShowItemArray();
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
                ma2_ItemArray[i, j] = Random.Range(1, 8);                       // 아이템 범위 지정 (초기값:8)
            }
        }
    }

    /// <summary>
    /// 아이템 관리 배열 값을 출력해주는 함수
    /// </summary>
    public void v_ShowItemArray()
    {
        ms_TextArray = "아이템 배치표\n";
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                ms_TextArray = ms_TextArray + ma2_ItemArray[i, j] + "\t";
            }
            ms_TextArray += "\n";
        }
        Debug.Log(ms_TextArray);
    }

    /// <summary>
    ///  아이템 배열에 아이템이 3개이상 모여 터질것이 있는지 검사하는 함수
    /// </summary>
    /// <returns>터질것이 있는경우 True반환</returns>
    public bool b_InspectArrayIsPop()
    {
        bool b_ColBreakFlag = false;
        bool b_RowBreakFlag = false;
        int n_Rowdistance;
        int n_ColDistance;
        int n_cursor;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                n_Rowdistance = 1;
                n_ColDistance = 1;
                n_cursor = ma2_ItemArray[i, j];
                b_RowBreakFlag = false;
                b_ColBreakFlag = false;
                for (int k = j + 1; k < 7; k++)
                {
                    if (b_RowBreakFlag == false)
                    {
                        // 가로로 확인
                        switch (n_cursor)
                        {
                            case 1:
                                if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                    return true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                {
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("트루 반환 i : " + i + ", j : " + j);
                                        return true;
                                    }
                                    else
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && n_Rowdistance >= 3))
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
                    if (b_ColBreakFlag == false)
                    {
                        switch (n_cursor)
                        {
                            case 1:
                                if (ma2_ItemArray[k, j] != 1 && ma2_ItemArray[k, j] != 11)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && n_ColDistance >= 3))
                                {
                                    return true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                {
                                    if (n_ColDistance >= 3)
                                        return true;
                                    else
                                    {
                                        b_ColBreakFlag = true;
                                        break;
                                    }
                                }
                                else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && n_ColDistance >= 3))
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

    /// <summary>
    /// 배열에 3개이상 모인 아이템 10이상의 숫자로 모두 변경해준다.
    /// </summary>
    public void v_PopItemInArray()
    {
        bool b_ColBreakFlag = false;
        bool b_RowBreakFlag = false;
        int n_Rowdistance;
        int n_ColDistance;
        int n_cursor;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                n_Rowdistance = 1;
                n_ColDistance = 1;
                n_cursor = ma2_ItemArray[i, j];
                b_RowBreakFlag = false;
                b_ColBreakFlag = false;
                // 가로로 확인
                for (int k = j + 1; k < 7; k++)
                {
                    // 가로로 확인
                    if (b_RowBreakFlag == false)
                    {
                        switch (n_cursor)
                        {
                            case 1:
                                if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 11;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 11;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 11:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 1 || ma2_ItemArray[i, j - 1] == 11)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 1 && ma2_ItemArray[i, k] != 11)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 11;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 1 || ma2_ItemArray[i, k] == 11) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 11;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 12;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 12;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 12:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 1 || ma2_ItemArray[i, j - 1] == 11)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 2 && ma2_ItemArray[i, k] != 12)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 12;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 2 || ma2_ItemArray[i, k] == 12) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 12;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 13;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 13;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 13:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 3 || ma2_ItemArray[i, j - 1] == 13)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 3 && ma2_ItemArray[i, k] != 13)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 13;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 3 || ma2_ItemArray[i, k] == 13) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 13;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 14;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 14;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 14:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 4 || ma2_ItemArray[i, j - 1] == 14)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 4 && ma2_ItemArray[i, k] != 14)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 14;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 4 || ma2_ItemArray[i, k] == 14) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 14;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 15;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 15;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 15:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 5 || ma2_ItemArray[i, j - 1] == 15)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 5 && ma2_ItemArray[i, k] != 15)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 15;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 5 || ma2_ItemArray[i, k] == 15) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 15;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 16;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 16;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 16:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 6 || ma2_ItemArray[i, j - 1] == 16)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 6 && ma2_ItemArray[i, k] != 16)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 16;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 6 || ma2_ItemArray[i, k] == 16) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 16;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 17;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 17;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                            case 17:
                                if (j != 0)
                                {
                                    if (ma2_ItemArray[i, j - 1] == 7 || ma2_ItemArray[i, j - 1] == 17)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[i, k] != 7 && ma2_ItemArray[i, k] != 17)
                                {
                                    b_RowBreakFlag = true;
                                    if (n_Rowdistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_Rowdistance : " + n_Rowdistance);

                                        for (int n = 0; n < n_Rowdistance; n++)
                                        {
                                            ma2_ItemArray[i, j + n] = 17;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17)
                                {
                                    n_Rowdistance++;
                                }

                                if (((ma2_ItemArray[i, k] == 7 || ma2_ItemArray[i, k] == 17) && k == 6 && n_Rowdistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_Rowdistance : " + n_Rowdistance);

                                    for (int n = 0; n < n_Rowdistance; n++)
                                    {
                                        ma2_ItemArray[i, j + n] = 17;
                                    }
                                    b_RowBreakFlag = true;
                                }
                                break;
                        }
                    }
                }
                //세로로 확인
                for (int k = i + 1; k < 6; k++)
                {
                    if (b_ColBreakFlag == false)
                    {
                        switch (n_cursor)
                        {
                            case 1:
                                if (ma2_ItemArray[k, j] != 1 && ma2_ItemArray[k, j] != 11)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 11;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 11;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 11:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 1 || ma2_ItemArray[i, k] == 11)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 1 && ma2_ItemArray[k, j] != 11)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 11;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 1 || ma2_ItemArray[k, j] == 11) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 1 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 11;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 2:
                                if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 12;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 12;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 12:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 2 || ma2_ItemArray[i, k] == 12)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 2 && ma2_ItemArray[k, j] != 12)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 12;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 2 || ma2_ItemArray[k, j] == 12) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 2 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 12;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 3:
                                if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 13;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 13;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 13:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 3 || ma2_ItemArray[i, k] == 13)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 3 && ma2_ItemArray[k, j] != 13)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 13;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 3 || ma2_ItemArray[k, j] == 13) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 3 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 13;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 4:
                                if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 14;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 14;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 14:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 4 || ma2_ItemArray[i, k] == 14)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 4 && ma2_ItemArray[k, j] != 14)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 14;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 4 || ma2_ItemArray[k, j] == 14) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 4 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 14;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 5:
                                if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 15;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 15;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 15:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 5 || ma2_ItemArray[i, k] == 15)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 5 && ma2_ItemArray[k, j] != 15)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 15;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 5 || ma2_ItemArray[k, j] == 15) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 5 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 15;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 6:
                                if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 16;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 16;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 16:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 6 || ma2_ItemArray[i, k] == 16)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 6 && ma2_ItemArray[k, j] != 16)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 16;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 6 || ma2_ItemArray[k, j] == 16) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 6 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 16;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 7:
                                if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 17;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 17;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                            case 17:
                                if (i != 0)
                                {
                                    if (ma2_ItemArray[i - 1, k] == 7 || ma2_ItemArray[i, k] == 17)
                                    {
                                        b_RowBreakFlag = true;
                                        break;
                                    }
                                }
                                if (ma2_ItemArray[k, j] != 7 && ma2_ItemArray[k, j] != 17)
                                {
                                    b_ColBreakFlag = true;
                                    if (n_ColDistance >= 3)
                                    {
                                        Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_ColDistance : " + n_ColDistance);

                                        for (int n = 0; n < n_ColDistance; n++)
                                        {
                                            ma2_ItemArray[i + n, j] = 17;
                                        }
                                    }
                                    break;
                                }
                                else if (ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17)
                                {
                                    n_ColDistance++;
                                }

                                if (((ma2_ItemArray[k, j] == 7 || ma2_ItemArray[k, j] == 17) && k == 5 && n_ColDistance >= 3))
                                {
                                    Debug.Log("i : " + i + " j : " + j + " n_cursor : 7 n_ColDistance : " + n_ColDistance);

                                    for (int n = 0; n < n_ColDistance; n++)
                                    {
                                        ma2_ItemArray[i + n, j] = 17;
                                    }
                                    b_ColBreakFlag = true;
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 터진 아이템들을 모두 위로 올리고 빈자리 새로운 아이템으로 채운다.
    /// </summary>
    public void v_RearrangeArray()
    {
        // 터진 아이템들(10이상의 숫자들) 모두 99로 변경하고 맨 위로 보낸다.
        for (int i = 5; i > -1; i--)
        {
            for (int j = 0; j < 7; j++)
            {
                if (ma2_ItemArray[i, j] > 10)
                {
                    if (i == 0)
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
        // 빈공간(99)를 모두 새로운 아이템들로 채운다.
        for (int i = 5; i > -1; i--)
        {
            for (int j = 0; j < 7; j++)
            {
                if (ma2_ItemArray[i, j] == 99)
                {
                    ma2_ItemArray[i, j] = Random.Range(1, 8);                   // 아이템 범위 지정 (초기값:8)
                }
            }
        }
    }
    
    /// <summary>
    /// 원하는 위치의 원소값 반환
    /// </summary>
    /// <param name="ni">배열의 i값</param>
    /// <param name="nj">배열의 j값</param>
    /// <returns></returns>
    public int n_ReturnArrayValue(int ni, int nj)
    {
        return ma2_ItemArray[ni, nj];
    }

    /// <summary>
    /// 왼쪽값과 값 변경
    /// </summary>
    /// <param name="ni">원소의 x값</param>
    /// <param name="nj">원소의 y값</param>
    public void v_ReplaceWithLeftValue(int ni, int nj)
    {
        int ntemp = ma2_ItemArray[ni, nj];
        if (nj == 0)
            Debug.Log("맨 왼쪽값은 바꿀 왼쪽 값이 없습니다.");
        else
        {
            ma2_ItemArray[ni, nj] = ma2_ItemArray[ni, nj - 1];
            ma2_ItemArray[ni, nj - 1] = ntemp;
        }
    }

    /// <summary>
    /// 오른쪽값과 값 변경
    /// </summary>
    /// <param name="ni">원소의 x값</param>
    /// <param name="nj">원소의 y값</param>
    public void v_ReplaceWithRightValue(int ni, int nj)
    {
        int ntemp = ma2_ItemArray[ni, nj];
        if (nj == 6)
            Debug.Log("맨 오른쪽값은 바꿀 오른쪽 값이 없습니다.");
        else
        {
            ma2_ItemArray[ni, nj] = ma2_ItemArray[ni, nj + 1];
            ma2_ItemArray[ni, nj + 1] = ntemp;
        }
    }

    /// <summary>
    /// 윗쪽값과 값 변경
    /// </summary>
    /// <param name="ni">원소의 x값</param>
    /// <param name="nj">원소의 y값</param>
    public void v_ReplaceWithTopValue(int ni, int nj)
    {
        int ntemp = ma2_ItemArray[ni, nj];
        if (ni == 0)
            Debug.Log("맨 윗쪽값은 바꿀 윗쪽 값이 없습니다.");
        else
        {
            ma2_ItemArray[ni, nj] = ma2_ItemArray[ni - 1, nj];
            ma2_ItemArray[ni - 1, nj] = ntemp;
        }
    }

    /// <summary>
    /// 아랫쪽값과 값 변경
    /// </summary>
    /// <param name="ni">원소의 x값</param>
    /// <param name="nj">원소의 y값</param>
    public void v_ReplaceWithBottomValue(int ni, int nj)
    {
        int ntemp = ma2_ItemArray[ni, nj];
        if (ni == 6)
            Debug.Log("맨 아랫쪽값은 바꿀 아랫쪽 값이 없습니다.");
        else
        {
            ma2_ItemArray[ni, nj] = ma2_ItemArray[ni + 1, nj];
            ma2_ItemArray[ni + 1, nj] = ntemp;
        }
    }
    #endregion
}