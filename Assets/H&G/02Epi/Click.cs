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
    private void OnMouseDown() //마우스 클릭 이벤트
    {
        if (mgo_Gretel.transform.position.x < 9) //그레텔이 앞에 있으니까 그레텔이 특정 지점까지 오기전까지
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
            ParentText.text = "\n                 가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.               \n";

            //팝업창 띄워서 부모님 얘기하는거 들리게하기
        }



    }


    // Start is called before the first frame update

}
