/*
 * - Name : CheckToSkipTheGame.cs
 * - Writer : 김명현
 * - Sounds : 이병권
 *
 * - Content : 게임을 시작할때 게임을 스킵할것인지 체크하는 기능 구현
 *             - 1) 체크하는 박스를 클릭하면 소리가 난다. 
 * 
 * - History
 * 1) 2021-08-24 : 게임건너뛰기 기능 구현
 * 2) 2021-08-25 : 게임에 소리나기 작업 (이병권)  
 *
 *
 * - Variable 
 * mg_CheckEffect                                       오브젝트 연결을 위한 변수 -> 체크 이미지를 보여주는 오브젝트 연결
 * ms_CheckImage                                        체크 이미지를 불러오는 스프라이트
 * 
 * - Function
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임을 시작할때 게임을 스킵할것인지 체크하는 기능 구현
public class CheckToSkipTheGame : MonoBehaviour
{
    GameObject mg_CheckEffect;
    public Sprite ms_CheckImage;

    // Start is called before the first frame update
    void Start()
    {
        mg_CheckEffect = GameObject.Find("CheckEffect");

        if (PlayerPrefs.HasKey("SkipGame") == false)
        {
            PlayerPrefs.SetInt("SkipGame", 1);
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = ms_CheckImage;
        }
        else if(PlayerPrefs.GetInt("SkipGame") == 1)
        {
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = ms_CheckImage;
        }
        else if (PlayerPrefs.GetInt("SkipGame") == 0)
        {
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("네모박스 클릭");


        // 만약 체크이미지가 없으면 보이게 출력, 있으면 없어지게 설정
        if (PlayerPrefs.GetInt("SkipGame") == 1)
        {
            GetComponent<SoundsEffectesintro>().PlaySound("ClickSkip");
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = null;
            PlayerPrefs.SetInt("SkipGame", 0);
        }
        else if (PlayerPrefs.GetInt("SkipGame") == 0)
        {   
            GetComponent<SoundsEffectesintro>().PlaySound("ClickSkip");
            mg_CheckEffect.GetComponent<SpriteRenderer>().sprite = ms_CheckImage;
            PlayerPrefs.SetInt("SkipGame", 1);
        }
    }
}
