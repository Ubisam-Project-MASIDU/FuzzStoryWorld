using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItem : MonoBehaviour
{
    float x, y;
    float delta = 0;

    bool StopFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > 1)
        {
            if (x == this.transform.position.x && y == this.transform.position.y)
            {
                StopFlag = true;
            }
            else
            {
                x = this.transform.position.x;
                y = this.transform.position.y;
                StopFlag = false;
            }
            delta = 0;
        }

        Debug.Log(StopFlag);
    }

    void OnCollisionEnter(Collision cCollidObj)
    {
        //Debug.Log("충돌 감지");
        if (StopFlag == true)
        {
            Debug.Log("충돌 감지");
        }
        
    }

    public bool ReturnStopFlag()
    {
        return StopFlag;
    }

}
