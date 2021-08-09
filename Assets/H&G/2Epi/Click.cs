using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Click : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    int count = 0;

    public Text DoorClickText;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        DoorClickText.text = "";

    }

    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "stop")
        {
            Debug.Log("충돌");
            DoorClickText.text = "";
            
            //팝업창 띄워서 부모님 얘기하는거 들리게하기
        }



    }


    // Start is called before the first frame update

}
