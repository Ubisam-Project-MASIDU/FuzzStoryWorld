/*
 * - Name : ResetButton.cs
 * - Writer : 김명현 
 * - Content :
 * 리셋버튼을 관리하는 스크립트
 *
 * - History
 * 1) 2021-08-20 : 리셋버튼 누를경우 아이템들이 모두삭제되고 새로 생성되게 작성
 *
 * - Variable 
 * mg_GameDirector                      게임 디렉터 오브젝트에 접근하기 위한 변수
 * 
 * - Function   
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 리셋버튼을 관리하는 스크립트
public class ResetButton : MonoBehaviour
{
    GameObject mg_GameDirector;

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");
    }

    private void OnMouseDown()
    {
        if(mg_GameDirector.GetComponent<MainScript>().b_ReturnDragFlag() == true && mg_GameDirector.GetComponent<MainScript>().b_ReturnExchangeFlag() == false)
        {
            Debug.Log("리셋버튼 클릭");
            mg_GameDirector.GetComponent<ManageItem>().v_DestroyAllObjects();
            mg_GameDirector.GetComponent<ManageItemArray>().v_InitItemArray();
        }
      
    }

}
