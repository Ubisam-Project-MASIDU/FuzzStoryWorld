using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCaption : MonoBehaviour
{
    private ChangeCountry changecc;
    private CaptionControl cc;
    private GameObject Off;
    private GameObject On;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        Off = GameObject.Find("Off");
        On = GameObject.Find("On");
        
    }

    public void captionOn() //on��ư ������ �ڸ� ������� off��ư ����
    {
        
        this.gameObject.SetActive(false);        
        On.SetActive(false);
        Off.SetActive(true);
        
    }

    public void captionOff() //off��ư ������ �ڸ� ����� on��ư ����
    {
        this.gameObject.SetActive(true);
        On.SetActive(true);
        Off.SetActive(false);
        
        
    }
}
