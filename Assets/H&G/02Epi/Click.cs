using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Click : MonoBehaviour
{

    public GameObject mgo_Hansel;
    public GameObject mgo_Gretel;

    
    Rigidbody rb;
    public float speed;

    int count = 0;

    public Text DoorClickText;
    public Text ParentText;

    void Start()
    {
        mgo_Hansel = GameObject.Find("Hansel");
        mgo_Gretel = GameObject.Find("Gretel");


        rb.GetComponent<Rigidbody>();
        DoorClickText.text = "";

    }

    void Update()
    {
       
    }
    private void OnMouseDown() //���콺 Ŭ�� �̺�Ʈ
    {
        if (mgo_Gretel.transform.position.x < 9) //�׷����� �տ� �����ϱ� �׷����� Ư�� �������� ����������
        {
            transform.Translate(1, 0, 0);
            Debug.Log("buttonPress");
        }
        Debug.Log("stop");
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "stop")
        {
            DoorClickText.text = "";
            ParentText.text = "\n                 ������ �� ��Ƽ�� �θ���� ������ �׷����� ���ӿ� ������ ��ȹ�߾��.               \n";

            //�˾�â ����� �θ�� ����ϴ°� �鸮���ϱ�
        }



    }


    // Start is called before the first frame update

}
