/*
 * - Name : ManageItem.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 아이템들을 생성하고 삭제하는 함수들 작성
 * 
 * - History
 * 1) 2021-08-24 : 게임건너뛰기 기능 구현
 *  
 * - Variable 
 * mg_Item1Orange                                       오브젝트 연결을 위한 변수 -> 프리팹(아이템1) 연결을 위한 변수
 * 
 * - Function
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToSkipTheGame : MonoBehaviour
{
    GameObject mg_CheckEffect;
    public Sprite ms_CheckImage;

    // Start is called before the first frame update
    void Start()
    {
        mg_CheckEffect = GameObject.Find("CheckEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("네모박스 클릭");
        if (mg_CheckEffect.GetComponent<SpriteRenderer>().sprite == null)
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = ms_CheckImage;
        else
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = null;
    }
}
