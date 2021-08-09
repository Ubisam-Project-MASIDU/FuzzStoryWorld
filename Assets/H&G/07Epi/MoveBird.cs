using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private float mf_CheckTime = 0;
    public bool mb_CheckEndBird = false;
    private GameObject mgo_HAG;

    void Start() {
        mgo_HAG = GameObject.Find("gretel").gameObject;
    }

    void Update() {
        mf_CheckTime += Time.deltaTime;
        if (mb_CheckEndBird && (mf_CheckTime >= 0.2f) && (transform.position.y <= 2f)) {
            mf_CheckTime = 0f;
        }
        if(!mb_CheckEndBird && (mf_CheckTime >= 0.2f) && (transform.position.y <= 2f)){
            mf_CheckTime = 0f;
            if (transform.position.z <= -10.8f)
                GetComponent<Rigidbody>().AddForce(1.5f, 120f, 10f);
            else if (transform.position.z >= -11.6f)
                GetComponent<Rigidbody>().AddForce(1.5f, 120f, -10f);
            else
                GetComponent<Rigidbody>().AddForce(1.5f, 120f, Random.Range(-10f, 10f));
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0))
                 mgo_HAG.GetComponent<MoveHAG>().SetTargetPos(transform.position);
         }
    }



    void OnTriggerEnter(Collider cCollider) {
        if (this.tag == "moving bird" && cCollider.name == "cookiesHouse") {
            GameObject.Find("cookiesHouse").transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
