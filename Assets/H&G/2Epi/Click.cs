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
            Debug.Log("�浹");
            DoorClickText.text = "";
            
            //�˾�â ����� �θ�� ����ϴ°� �鸮���ϱ�
        }



    }


    // Start is called before the first frame update

}
