using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCaption : MonoBehaviour
{
    private GameObject Off;
    private GameObject On;
    // Start is called before the first frame update
    void Start()
    {
        Off = GameObject.Find("Off");
        On = GameObject.Find("On");
        Off.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void captionOn() //on버튼 누르면 자막 사라지고 off버튼 나옴
    {
        this.gameObject.SetActive(false);
        On.SetActive(false);
        Off.SetActive(true);

    }

    public void captionOff() //off버튼 누르면 자막 생기고 on버튼 나옴
    {
        this.gameObject.SetActive(true);
        On.SetActive(true);
        Off.SetActive(false);
    }
}
