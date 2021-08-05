using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollid : MonoBehaviour
{
    bool mb_IsCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D cCollidObj)
    {
        Debug.Log("충돌 감지");
        mb_IsCollision = true;
    }

    void OnTriggerExit2D(Collider2D cCollidObj)
    {
        Debug.Log("충돌 끝");
        mb_IsCollision = false;
    }

    public bool b_IsCollision()
    {
        return mb_IsCollision;
    }
}
