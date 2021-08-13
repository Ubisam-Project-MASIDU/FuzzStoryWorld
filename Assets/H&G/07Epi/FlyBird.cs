/*
 * - Name : FlyBird.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 새가 날아가는 것처럼 동작을 구현한 스크립트 코드이다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-09 : 주석 작성.
 *  
 * - Variable 
 * mr_CheckMousePosByRay                                마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 클래스이다.                        
 * mrch_CheckMousePosHitObj                             레이져를 쏜 곳에 오브젝트가 있다면 이 hit 클래스 변수에 담긴다.                          
 * mgo_HAG                                              헨젤과 그레텔 오브젝트이다.               
 * mf_CheckTime                                         시간을 재어 0.2초 마다 addForce함수를 통해 나는것처럼 힘을 가해 주기 위한 변수이다.
 * mb_CheckEndBird                                      새가 마지막 마녀집에 도착하는 새 오브젝트인지 확인하기 위한 변수이다.       
 *
 * - Function
 * Update()                                             0.2초 마다 새 오브젝트에게 일정한 방향으로 특정한 크기의 힘을 주어 나는 것 처럼 표현한다. 또한 클릭 이벤트를 감지하여 새쪽으로 헨젤과그레텔 오브젝트를 움직일 수 있도록 한다.        
 * OnTriggerEnter(Collider cCollider)                   마녀 집에 도착하면 새를 사라지게 하는 함수이다.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 새가 날아가는 동작을 정의한 스크립트 클래스이다.
public class FlyBird : MonoBehaviour {
    private Ray mr_CheckMousePosByRay;                      // 마우스가 클릭된 곳을 카메라에서부터 레이져를 쏘아 감지하기 위한 Ray 
    private RaycastHit mrch_CheckMousePosHitObj;            // 레이져를 쏜 곳에 오브젝트가 있다면 이 hit 클래스 변수에 담긴다.
    private float mf_CheckTime = 0;                         // 시간을 재어 0.2초 마다 addForce함수를 통해 나는것처럼 힘을 가해 주기 위한 변수이다.
    public bool mb_CheckEndBird = false;                    // 새가 마지막 마녀집에 도착하는 새 오브젝트인지 확인하기 위한 변수이다.
    private GameObject mgo_HAG;                             // 헨젤과 그레텔 오브젝트이다. 


    // 헨젤과 그레텔 게임오브젝트를 초기화한다.
    void Start() {
        mgo_HAG = GameObject.Find("gretel").gameObject;
    }

    // 0.2초 마다 새 오브젝트에게 일정한 방향으로 특정한 크기의 힘을 주어 나는 것 처럼 표현한다. 또한 클릭 이벤트를 감지하여 새쪽으로 헨젤과그레텔 오브젝트를 움직일 수 있도록 한다.
    void Update() {
        mf_CheckTime += Time.deltaTime;

        if (mb_CheckEndBird && (mf_CheckTime >= 0.2f) && (transform.position.y <= 2f)) {
            mf_CheckTime = 0f;
        }

        if(!mb_CheckEndBird && (mf_CheckTime >= 0.2f) && (transform.position.y <= 2f)){
            mf_CheckTime = 0f;
            if (transform.position.z <= -10.8f) {
                GetComponent<Rigidbody>().AddForce(5f, 120f, 10f);
            } else if (transform.position.z >= -11.6f) {
                GetComponent<Rigidbody>().AddForce(5f, 120f, -10f);
            } else {
                GetComponent<Rigidbody>().AddForce(5f, 120f, Random.Range(-10f, 10f));
            }
        }

        mr_CheckMousePosByRay = Camera.main.ScreenPointToRay(Input.mousePosition);

         if(Physics.Raycast(mr_CheckMousePosByRay, out mrch_CheckMousePosHitObj)) {
             if(Input.GetMouseButtonDown(0)) {
                 mgo_HAG.GetComponent<MoveHAG>().SetTargetPos(transform.position);
             }
         }
    }

    // 마녀집에 도착하면 이 새 오브젝트는 사라지고, 새로 마녀집에 앉은 모습의 새 오브젝트를 생성하도록 하였다.
    void OnTriggerEnter(Collider cCollider) {
        if (this.tag == "moving bird" && cCollider.name == "cookiesHouse") {
            GameObject.Find("cookiesHouse").transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
