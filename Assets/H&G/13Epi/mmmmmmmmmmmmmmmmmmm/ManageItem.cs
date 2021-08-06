/*
 * - Name : ManageItem.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 아이템들을 생성하고 삭제하는 함수들 작성
 * 아이템들이 모두 정지상태인지 실시간으로 확인하고 이를 전달할수 있다.
 * 
 * - History
 * 1) 2021-08-05 : 아이템들을 생성하는 함수 작성
 * 2) 2021-08-06 : 아이템들을 삭제하는 함수 작성, 모두 정지상태인지 확인하는 함수 작성
 *  
 * - Variable 
 * mg_Item1Orange                                   오브젝트 연결을 위한 변수 -> 프리팹(아이템1) 연결을 위한 변수
 * mg_Item2Red                                      오브젝트 연결을 위한 변수 -> 프리팹(아이템2) 연결을 위한 변수
 * mg_Item3Purple                                   오브젝트 연결을 위한 변수 -> 프리팹(아이템3) 연결을 위한 변수
 * mg_Item4Blue                                     오브젝트 연결을 위한 변수 -> 프리팹(아이템4) 연결을 위한 변수
 * mg_Item5Green                                    오브젝트 연결을 위한 변수 -> 프리팹(아이템5) 연결을 위한 변수
 * mg_Item6Yellow                                   오브젝트 연결을 위한 변수 -> 프리팹(아이템6) 연결을 위한 변수
 * mg_Item7Star                                     오브젝트 연결을 위한 변수 -> 프리팹(아이템7) 연결을 위한 변수
 * mg_Col1                                          오브젝트 연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
 * mg_Col2                                          오브젝트 연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수 
 * mg_Col3                                          오브젝트 연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수 
 * mg_Col4                                          오브젝트 연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수 
 * mg_Col5                                          오브젝트 연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수 
 * mg_Col6                                          오브젝트 연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수 
 * mg_Col7                                          오브젝트 연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수 
 * mg_GenItem                                       오브젝트 관리를 위한 변수 -> 생성한 오브젝트 속성을 변경하기 위한 변수
 * mg_DeletedObject                                 오브젝트 관리를 위한 변수 -> 삭제할 오브젝트 속성을 변경하기 위한 변수
 * mb_IsStopFlag                                    Flag 값 -> 모든 아이템들이 정지된 상태인지 확인하기위한 Flag
 * 
 * - Function
 * v_GenItem(int nItemNumber, int nColNumber)         아이템을 생성해주는 함수
 * v_DestroyObject(int nColNumber, int nChildNumber)  아이템을 삭제해주는 함수
 * v_IsStop()                                       모든 아이템들이 정지상태인지 확인해주는 함수, 각 세로줄에 아이템이 6개면 정지상태로 간주한다.
 * b_ReturnIsStopFlag()                             모든 아이템들이 정지상태인지를 저장해둔 Flag값을 반환해준다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템들을 생성하고 삭제하고 모두 정지상태인지 관리하는 스크립트
public class ManageItem : MonoBehaviour
{
    #region 변수 선언부
    // 아이템 프리팹 연결을 위한 변수
    public GameObject mg_Item1Orange;                                               // 연결을 위한 변수 -> 프리팹(아이템1) 연결을 위한 변수
    public GameObject mg_Item2Red;                                                  // 연결을 위한 변수 -> 프리팹(아이템2) 연결을 위한 변수
    public GameObject mg_Item3Purple;                                               // 연결을 위한 변수 -> 프리팹(아이템3) 연결을 위한 변수
    public GameObject mg_Item4Blue;                                                 // 연결을 위한 변수 -> 프리팹(아이템4) 연결을 위한 변수
    public GameObject mg_Item5Green;                                                // 연결을 위한 변수 -> 프리팹(아이템5) 연결을 위한 변수
    public GameObject mg_Item6Yellow;                                               // 연결을 위한 변수 -> 프리팹(아이템6) 연결을 위한 변수
    public GameObject mg_Item7Star;                                                 // 연결을 위한 변수 -> 프리팹(아이템7) 연결을 위한 변수

    // 세로 줄 관리를 위한 변수
    GameObject mg_Col1;                                                             // 연결을 위한 변수 -> 1번째 세로줄 관리를 위한 변수
    GameObject mg_Col2;                                                             // 연결을 위한 변수 -> 2번째 세로줄 관리를 위한 변수 
    GameObject mg_Col3;                                                             // 연결을 위한 변수 -> 3번째 세로줄 관리를 위한 변수 
    GameObject mg_Col4;                                                             // 연결을 위한 변수 -> 4번째 세로줄 관리를 위한 변수 
    GameObject mg_Col5;                                                             // 연결을 위한 변수 -> 5번째 세로줄 관리를 위한 변수 
    GameObject mg_Col6;                                                             // 연결을 위한 변수 -> 6번째 세로줄 관리를 위한 변수 
    GameObject mg_Col7;                                                             // 연결을 위한 변수 -> 7번째 세로줄 관리를 위한 변수 

    // 오브젝트 관리를 위한 변수
    GameObject mg_GenItem;                                                          // 오브젝트 관리를 위한 변수 -> 생성한 오브젝트 속성을 변경하기 위한 변수
    GameObject mg_DeletedObject;                                                    // 오브젝트 관리를 위한 변수 -> 삭제할 오브젝트 속성을 변경하기 위한 변수

    // Flag 값 
    bool mb_IsStopFlag = false;                                                     // Flag 값 -> 모든 아이템들이 정지된 상태인지 확인하기위한 Flag
    #endregion

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
        v_IsStop();                                                                       // 매 프레임마다 모든 아이템들이 정지상테인지 확인
    }

    #region 함수 선언부
    /// <summary>
    /// 아이템을 생성해주는 함수
    /// </summary>
    /// <param name="nItemNumber">입력받은 숫자를 토대로 랜덤아이템으로 설정해준다.</param>
    /// <param name="nColNumber">아이템을 생성할 세로 줄 번호를 입력해준다.</param>
    public void v_GenItem(int nItemNumber, int nColNumber)
    {
        // 전달받은 숫자를 토대로 아이템을 생성해준다.
        if (nItemNumber == 1)
            mg_GenItem = Instantiate(mg_Item1Orange) as GameObject;
        else if (nItemNumber == 2)
            mg_GenItem = Instantiate(mg_Item2Red) as GameObject;
        else if (nItemNumber == 3)
            mg_GenItem = Instantiate(mg_Item3Purple) as GameObject;
        else if (nItemNumber == 4)
            mg_GenItem = Instantiate(mg_Item4Blue) as GameObject;
        else if (nItemNumber == 5)
            mg_GenItem = Instantiate(mg_Item5Green) as GameObject;
        else if (nItemNumber == 6)
            mg_GenItem = Instantiate(mg_Item6Yellow) as GameObject;
        else if (nItemNumber == 7)
            mg_GenItem = Instantiate(mg_Item7Star) as GameObject;

        // 위에서 생성한 오브젝트를 입렫받은 세로 줄 번호의 자식오브젝트로 이동시키고 세로 줄에 맞는 위치로 이동시킨다.
        if (nColNumber == 1)
        {
            mg_GenItem.transform.SetParent(mg_Col1.transform);
            mg_GenItem.transform.position = new Vector3(-6, 8, 0);
        }
        else if (nColNumber == 2)
        {
            mg_GenItem.transform.SetParent(mg_Col2.transform);
            mg_GenItem.transform.position = new Vector3(-4, 8, 0);
        }
        else if (nColNumber == 3)
        {
            mg_GenItem.transform.SetParent(mg_Col3.transform);
            mg_GenItem.transform.position = new Vector3(-2, 8, 0);
        }
        else if (nColNumber == 4)
        {
            mg_GenItem.transform.SetParent(mg_Col4.transform);
            mg_GenItem.transform.position = new Vector3(0, 8, 0);
        }
        else if (nColNumber == 5)
        {
            mg_GenItem.transform.SetParent(mg_Col5.transform);
            mg_GenItem.transform.position = new Vector3(2, 8, 0);
        }
        else if (nColNumber == 6)
        {
            mg_GenItem.transform.SetParent(mg_Col6.transform);
            mg_GenItem.transform.position = new Vector3(4, 8, 0);
        }
        else if (nColNumber == 7)
        {
            mg_GenItem.transform.SetParent(mg_Col7.transform);
            mg_GenItem.transform.position = new Vector3(6, 8, 0);
        }
    }

    /// <summary>
    /// 아이템을 삭제해주는 함수
    /// </summary>
    /// <param name="nColNumber">삭제할 오브젝트의 '열 +1' 을 입력해준다.</param>
    /// <param name="nChildNumber">삭제할 오브젝트의 '행'을 입력해준다.</param>
    public void v_DestroyObject(int nColNumber, int nChildNumber)
    {
        // 모든 아이템들이 정지상태일때 작동한다.
        if (mb_IsStopFlag == true)
        {
            if(nColNumber == 1)
                mg_DeletedObject = mg_Col1.transform.GetChild(5 - nChildNumber).gameObject;
            else if(nColNumber == 2)
                mg_DeletedObject = mg_Col2.transform.GetChild(5 - nChildNumber).gameObject;
            else if (nColNumber == 3)
                mg_DeletedObject = mg_Col3.transform.GetChild(5 - nChildNumber).gameObject;
            else if (nColNumber == 4)
                mg_DeletedObject = mg_Col4.transform.GetChild(5 - nChildNumber).gameObject;
            else if (nColNumber == 5)
                mg_DeletedObject = mg_Col5.transform.GetChild(5 - nChildNumber).gameObject;
            else if (nColNumber == 6)
                mg_DeletedObject = mg_Col6.transform.GetChild(5 - nChildNumber).gameObject;
            else if (nColNumber == 7)
                mg_DeletedObject = mg_Col7.transform.GetChild(5 - nChildNumber).gameObject;

            //Debug.Log("nColNumber : " + nColNumber + " nChildNumber : " + nChildNumber);
            if (mg_DeletedObject.gameObject != null)
                Destroy(mg_DeletedObject.gameObject, 1.5f);
            mg_DeletedObject = null;
        }
    }

    /// <summary>
    /// 모든 아이템들이 정지상태인지 확인해주는 함수, 각 세로줄에 아이템이 6개면 정지상태로 간주한다.
    /// </summary>
    public void v_IsStop()
    {
        if (mg_Col1.transform.childCount == 6 && mg_Col2.transform.childCount == 6 && mg_Col3.transform.childCount == 6 && mg_Col4.transform.childCount == 6 && mg_Col5.transform.childCount == 6 && mg_Col6.transform.childCount == 6 && mg_Col7.transform.childCount == 6)
            mb_IsStopFlag = true;
        else
            mb_IsStopFlag = false;
    }

    /// <summary>
    /// 모든 아이템들이 정지상태인지를 저장해둔 Flag값을 반환해준다.
    /// </summary>
    /// <returns>true면 정지상태, Flase면 움직이는 상태</returns>
    public bool b_ReturnIsStopFlag()
    {
        return mb_IsStopFlag;
    }
    #endregion
}
