/*
 * - Name : HAGAttack.cs
 * - Writer : 이예은
 * 
 * - Content :
 * 헨젤과 그레텔이 마녀를 공격하는 것을 정의한 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-13 : 코드 구현중. 
 * 2) 2021-08-13 : 주석 작성.
 *  
 * - Variable 
 * 
 *
 * - Function
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HAGAttack : MonoBehaviour
{
    //public GameObject mv3_Witch; //가야할 곳
    public GameObject mgo_bone;
    //public bool moveGo = false;
    private BoneControl Bone; // 캐릭터의 행동 스크립트 
    private Vector3 target; // 캐릭터의 이동 타켓 위치

    void Start() {
        Bone = GetComponent<BoneControl>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 10000f)) {
               // if(hit.transform.gameObject.name == "witch") {
                target = hit.point;
                //Debug.Log(hit.transform.gameObject);          
                }      
                //if(hit.transform.gameObject.name == "witch") {
                //    Debug.Log("마녀"); 
                //}
           // }        
        } 
    if(Bone.Run(target)) {
        Bone.Turn(target);
    } else {
        Destroy(mgo_bone);
         }
    }            
    //void OnCollisionEnter(Collision collision) {
    //    if(collision.gameObject.tag == "player") {
   //         Destroy(mgo_bone, 2f);
    //    }
    //}
    //void attack() {
    //    transform.position = Vector3.Slerp(transform.position, mv3_Witch.transform.position, 1f * Time.deltaTime);
    //}
}