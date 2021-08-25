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

    public void captionClose()
    {
        this.gameObject.SetActive(false);
        On.SetActive(false);
        Off.SetActive(true);

    }

    public void captionShow()
    {
        this.gameObject.SetActive(true);
        On.SetActive(true);
        Off.SetActive(false);
    }
}
