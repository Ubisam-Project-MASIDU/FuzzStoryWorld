using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    private float mf_CountTime = 0f;
    private int mn_CountSecond = 1;
    void Update()
    {

        mf_CountTime += Time.deltaTime;
        if (mn_CountSecond < mf_CountTime) {
            mn_CountSecond++;
            if (this.GetComponent<SpriteRenderer>().enabled)
                this.GetComponent<SpriteRenderer>().enabled = false;
            else
                this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
