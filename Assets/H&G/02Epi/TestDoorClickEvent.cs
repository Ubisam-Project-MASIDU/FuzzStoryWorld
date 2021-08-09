/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoorClickEvent : MonoBehaviour
{
    private GameObject mgo_Hansel;
    private GameObject mgo_Gretel;

    Vector2 mv3_MousePosition;


    void Start()
    {
        mgo_Hansel = GameObject.Find("Hansel");
        mgo_Gretel = GameObject.Find("Gretel");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){

            mv3_MousePosition = Input.mousePosition;

            if (mv3_MousePosition.x > 9 && mv3_MousePosition.x < 11)
            {
                if (mv3_MousePosition.y > 0 && mv3_MousePosition.y < 10)
                {
                    transform.Translate(1, 0, 0);                 //
                    Debug.Log("buttonPress");
                }
            }
            /*if (mgo_Gretel.transform.position.x < 9){         //그레텔이 앞에 있으니까 그레텔이 특정 지점까지 오기전까지
                transform.Translate(1, 0, 0);                 //
                Debug.Log("11");
            }
        }
    }

  /*  public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "stop")
        {
            DoorClickText.text = "";
            ParentText.text = "\n                 가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.               \n";

            //팝업창 띄워서 부모님 얘기하는거 들리게하기
        }



    }
  
}
  */
