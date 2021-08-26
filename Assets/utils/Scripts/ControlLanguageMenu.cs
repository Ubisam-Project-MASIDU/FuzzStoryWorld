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
        mg_Country = GameObject.Find("나라");
        mg_LanguagePenel = GameObject.FindWithTag("LanguagePanel");

        if (PlayerPrefs.HasKey("ShowLanguageMenu") == false)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            mg_LanguagePenel.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            mg_Country.SetActive(true);
            //mg_LanguagePenel.SetActive(true);
            mg_LanguagePenel.GetComponent<RectTransform>().position = new Vector3(2279, 608.2f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.55f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            this.transform.localPosition = new Vector3(40, -330, 0);
        }
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            mg_Country.SetActive(false);
            //mg_LanguagePenel.GetComponent<RectTransform>().offsetMax.Set(-1099.242f, -950f);
            mg_LanguagePenel.GetComponent<RectTransform>().position = new Vector3(2255.24f, 859, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.11f, 0);
            //mg_LanguagePenel.SetActive(false);
            this.GetComponent<Image>().sprite = ms_ButtonImageFlip;
            this.transform.localPosition = new Vector3(40, 160, 0);
        }


    }

    public void v_ControlLanguageMenu()
    {
        if (PlayerPrefs.GetInt("ShowLanguageMenu") == 1)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 0);
            mg_Country.SetActive(false);
            //mg_LanguagePenel.SetActive(false);
            mg_LanguagePenel.GetComponent<RectTransform>().position = new Vector3(2255.24f, 859, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.11f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImageFlip;
            this.transform.localPosition = new Vector3(40, 160, 0);  
        }
        else if (PlayerPrefs.GetInt("ShowLanguageMenu") == 0)
        {
            PlayerPrefs.SetInt("ShowLanguageMenu", 1);
            mg_Country.SetActive(true);
            //mg_LanguagePenel.SetActive(true);
            mg_LanguagePenel.GetComponent<RectTransform>().position = new Vector3(2279, 608.2f, 0);
            mg_LanguagePenel.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.55f, 0);
            this.GetComponent<Image>().sprite = ms_ButtonImage;
            this.transform.localPosition = new Vector3(40, -330, 0);
        }
    }
}
