/*
 * - Name : ControlLanguageMenu.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 언어 변경 메뉴를 접었다 필수 있게끔 설정
 * 
 * - History
 * 1) 2021-08-27 : 언어 변경 메뉴를 접었다 필수 있게끔 설정
 * 
 * - Variable
 * mg_Country                                       나라 오브젝트 연결을 위한 변수
 * mg_LanguagePenel                                 나라 뒷 배경 패널 오브젝트 연결을 위한 변수
 * ms_ButtonImage                                   버튼 이미지
 * ms_ButtonImageFlip                               위아래로 뒤집힌 버튼 이미지
 * 
 * - Function
 * v_ControlLanguageMenu()                          버튼이 눌리면 나라 리스트를 보여주거나 리스트를 숨기는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLanguageMenu : MonoBehaviour
{
    GameObject mg_Country;
    GameObject mg_LanguagePenel;
    public Sprite ms_ButtonImage;
    public Sprite ms_ButtonImageFlip;

    // Start is called before the first frame update
    void Start()
    {
        // 오브젝트 연결
        mg_Country = GameObject.Find("나라");
        mg_LanguagePenel = GameObject.FindWithTag("LanguagePanel");

        // 처음 실행하여 키값이 없는경우
        if (PlayerPrefs.HasKey("ShowLanguageMenu") == false)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            mg_LanguagePenel.SetActive(true);
        }
        // 메뉴를 열어둔 상태
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            mg_Country.SetActive(true);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            mg_LanguagePenel.GetComponent<RectTransform>().localPosition = new Vector3(50f, -50f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.53f, 0);
            this.transform.localPosition = new Vector3(40, -325, 0);
        }
        // 메뉴를 접어둔 상태
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            mg_Country.SetActive(false);
            this.GetComponent<Image>().sprite = ms_ButtonImageFlip;
            mg_LanguagePenel.GetComponent<RectTransform>().localPosition = new Vector3(50f, 200f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0);
            this.transform.localPosition = new Vector3(40, 175, 0);
        }
    }

    public void v_ControlLanguageMenu()
    {
        // 열린 메뉴를 접는경우
        if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 0);
            mg_Country.SetActive(false);
            mg_LanguagePenel.GetComponent<RectTransform>().localPosition = new Vector3(50f, 200f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImageFlip;
            this.transform.localPosition = new Vector3(40, 175, 0);  
        }
        // 접힌 메뉴를 여는 경우
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            mg_LanguagePenel.GetComponent<RectTransform>().localPosition = new Vector3(50f, -50f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.53f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            this.transform.localPosition = new Vector3(40, -325, 0);
        }
    }
}
