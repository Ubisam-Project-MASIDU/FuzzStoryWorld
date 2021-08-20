/*
 * - Name : MainScript.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 게임이 진행됨에 있어 메인 스크립트이다.
 * 
 * - History
 * 1) 2021-08-20 : 알고리즘 전면 수정
 * 
 * - Variable 
 * mf_delta                                         진행시간 측정을 위한 변수                                
 * mb_InitGenItemFlag                               초기 아이템 생성 확인을 위한 Flag값
 * mb_DestroyFlag                                   아이템 파괴 구현시 반복을 피하기 위한 Flag값
 * mb_DragFlag                                      아이템 드래그 가능한 상태인지 확인하기 위한 Flag값
 * mb_IsExchangeNowFlag                             아이템 스왑 중인지 확인하기 위한 Flag값
 * mn_i                                             아이템 생성시 행을 값을 저장해두는 변수
 * mg_Col1                                          연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
 * mg_Col2                                          연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수
 * mg_Col3                                          연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수
 * mg_Col4                                          연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수
 * mg_Col5                                          연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수
 * mg_Col6                                          연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수
 * mg_Col7                                          연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수
 * 
 * - Function   
 * b_ReturnDragFlag()                               드래그 가능한 상태인지 Flag값 반환
 * v_ChangeDragFlagFalse()                          드래그 Flag값 False로 변환
 * v_ChangeExchangeFlagTrue()                       아이템 교체중인지 나타내는 Flag값 True로 변환
 * v_ChangeExchangeFlagFalse()                      아이템 교체중인지 나타내는 Flag값 False로 변환
 * b_ReturnExchangeFlag()                           아이템이 교체중인지 나타내는 Flag값 반환
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    // 변수 선언부
    float mf_delta = 0;                                                     // 진행시간 측정을 위한 변수                         
    bool mb_InitGenItemFlag = false;                                        // 초기 아이템 생성 확인을 위한 Flag값
    bool mb_DestroyFlag = false;                                            // 아이템 파괴 구현시 반복을 피하기 위한 Flag값
    bool mb_DragFlag = false;                                               // 아이템 드래그 가능한 상태인지 확인하기 위한 Flag값
    bool mb_IsExchangeNowFlag = false;                                      // 아이템 스왑 중인지 확인하기 위한 Flag값
    int mn_i = 5;                                                           // 아이템 생성시 행을 값을 저장해두는 변수
    GameObject mg_Col1;                                                     // 연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
    GameObject mg_Col2;                                                     // 연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수 
    GameObject mg_Col3;                                                     // 연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수 
    GameObject mg_Col4;                                                     // 연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수 
    GameObject mg_Col5;                                                     // 연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수 
    GameObject mg_Col6;                                                     // 연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수 
    GameObject mg_Col7;                                                     // 연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수 

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 연결
        mg_Col1 = GameObject.Find("Col1");
        mg_Col2 = GameObject.Find("Col2");
        mg_Col3 = GameObject.Find("Col3");
        mg_Col4 = GameObject.Find("Col4");
        mg_Col5 = GameObject.Find("Col5");
        mg_Col6 = GameObject.Find("Col6");
        mg_Col7 = GameObject.Find("Col7");
    }

    // Update is called once per frame
    void Update()
    {
        // 시간측정
        this.mf_delta += Time.deltaTime;

        if (mf_delta > 0.5f)
        {
            // 초기 아이템들(7x6) 생성
            if (mb_InitGenItemFlag == false)
            {
                Debug.Log("초기 아이템들 생성");
                for (int j = 0; j < 7; j++)
                {
                    if (mn_i >= 0)
                    {
                        GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                    }
                }
                mn_i--;
                if (mn_i == -1)
                {
                    mb_InitGenItemFlag = true;
                }
                mf_delta = 0;
            }
            // 3개이상 모인 아이템이 있는지 검사
            else if (GetComponent<ManageItemArray>().b_InspectArrayIsPop() && mg_Col1.transform.childCount == 6 && mg_Col2.transform.childCount == 6 
                && mg_Col3.transform.childCount == 6 && mg_Col4.transform.childCount == 6 && mg_Col5.transform.childCount == 6 
                && mg_Col6.transform.childCount == 6 && mg_Col7.transform.childCount == 6 && mf_delta >= 1)
            {
                mb_DragFlag = false;
                Debug.Log("3개이상 모인 아이템이 있는지 검사");
                GetComponent<ManageItemArray>().v_PopItemInArray();
                GetComponent<ManageItemArray>().v_ShowItemArray();
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if(GetComponent<ManageItemArray>().n_ReturnArrayValue(i, j) > 10)
                        {
                            GetComponent<ManageItem>().v_DestroyObject(j + 1, i);
                        }
                    }
                }
                // 빈자리 새로운 아이템으로 채움
                GetComponent<ManageItemArray>().v_RearrangeArray();
                mf_delta = 0;
            }
            // 아이템 재생성
            else if(mg_Col1.transform.childCount != 6 || mg_Col2.transform.childCount != 6 || mg_Col3.transform.childCount != 6 
                || mg_Col4.transform.childCount != 6 || mg_Col5.transform.childCount != 6 || mg_Col6.transform.childCount != 6 
                || mg_Col7.transform.childCount != 6)
            {
                mb_DragFlag = false;
                Debug.Log("아이템 재생성");
                GetComponent<ManageItemArray>().v_ShowItemArray();
                // 시간 감소를 위하여 적절한 행부터 아이템 재생성
                if (mb_DestroyFlag == false)
                {
                    if (mg_Col1.transform.childCount >= 5 && mg_Col2.transform.childCount >= 5 && mg_Col3.transform.childCount >= 5
                && mg_Col4.transform.childCount >= 5 && mg_Col5.transform.childCount >= 5 && mg_Col6.transform.childCount >= 5
                && mg_Col7.transform.childCount >= 5)
                        mn_i = 0;
                    else if (mg_Col1.transform.childCount >= 4 && mg_Col2.transform.childCount >= 4 && mg_Col3.transform.childCount >= 4
                && mg_Col4.transform.childCount >= 4 && mg_Col5.transform.childCount >= 4 && mg_Col6.transform.childCount >= 4
                && mg_Col7.transform.childCount >= 4)
                        mn_i = 1;
                    else if (mg_Col1.transform.childCount >= 3 && mg_Col2.transform.childCount >= 3 && mg_Col3.transform.childCount >= 3
                && mg_Col4.transform.childCount >= 3 && mg_Col5.transform.childCount >= 3 && mg_Col6.transform.childCount >= 3
                && mg_Col7.transform.childCount >= 3)
                        mn_i = 2;
                    else if (mg_Col1.transform.childCount >= 2 && mg_Col2.transform.childCount >= 2 && mg_Col3.transform.childCount >= 2
                && mg_Col4.transform.childCount >= 2 && mg_Col5.transform.childCount >= 2 && mg_Col6.transform.childCount >= 2
                && mg_Col7.transform.childCount >= 2)
                        mn_i = 3;
                    else if (mg_Col1.transform.childCount >= 3 && mg_Col2.transform.childCount >= 1 && mg_Col3.transform.childCount >= 1
                && mg_Col4.transform.childCount >= 1 && mg_Col5.transform.childCount >= 1 && mg_Col6.transform.childCount >= 1
                && mg_Col7.transform.childCount >= 1)
                        mn_i = 4;
                    else
                        mn_i = 5;
                }
                mb_DestroyFlag = true;
                // 아이템 재생성
                for (int j=0; j<7; j++)
                {
                    switch (j)
                    {
                        case 0:
                            if (mg_Col1.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col1.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col1.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col1.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col1.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col1.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 1:
                            if (mg_Col2.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col2.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col2.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col2.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col2.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col2.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 2:
                            if (mg_Col3.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col3.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col3.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col3.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col3.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col3.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 3:
                            if (mg_Col4.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col4.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col4.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col4.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col4.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col4.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 4:
                            if (mg_Col5.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col5.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col5.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col5.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col5.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col5.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 5:
                            if (mg_Col6.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col6.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col6.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col6.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col6.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col6.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                        case 6:
                            if (mg_Col7.transform.childCount == 0 && mn_i == 5)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col7.transform.childCount == 1 && mn_i == 4)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col7.transform.childCount == 2 && mn_i == 3)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col7.transform.childCount == 3 && mn_i == 2)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col7.transform.childCount == 4 && mn_i == 1)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            else if (mg_Col7.transform.childCount == 5 && mn_i == 0)
                                GetComponent<ManageItem>().v_GenItem(GetComponent<ManageItemArray>().n_ReturnArrayValue(mn_i, j), (j + 1));
                            break;
                    }
                }
                mn_i--;
                if (mn_i == -1)
                    mb_DestroyFlag = false;
                mf_delta = 0;
            }
            // 대기 상태
            else if(GetComponent<ManageItemArray>().b_InspectArrayIsPop() == false)
            {
                Debug.Log("대기상태");
                if(mb_IsExchangeNowFlag == false)
                    mb_DragFlag = true;
            }
        }
    }

    /// <summary>
    /// 드래그 가능한 상태인지 Flag값 반환
    /// </summary>
    /// <returns>True면 아이템 드래그 가능</returns>
    public bool b_ReturnDragFlag()
    {
        return mb_DragFlag;
    }

    /// <summary>
    /// 드래그 Flag값 False로 변환
    /// </summary>
    public void v_ChangeDragFlagFalse()
    {
        mb_DragFlag = false;
    }

    /// <summary>
    /// 아이템 교체중인지 나타내는 Flag값 True로 변환
    /// </summary>
    public void v_ChangeExchangeFlagTrue()
    {
        mb_IsExchangeNowFlag = true;
    }

    /// <summary>
    /// 아이템 교체중인지 나타내는 Flag값 False로 변환
    /// </summary>
    public void v_ChangeExchangeFlagFalse()
    {
        mb_IsExchangeNowFlag = false;
    }

    /// <summary>
    /// 아이템이 교체중인지 나타내는 Flag값 반환
    /// </summary>
    /// <returns>True면 아이템 교체중</returns>
    public bool b_ReturnExchangeFlag()
    {
        return mb_IsExchangeNowFlag;
    }
}
