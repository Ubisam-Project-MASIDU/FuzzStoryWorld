using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    Vector3 mv3_initPos;
    public int count;
    private GameObject mgo_GameControl;

    void Start(){
        mv3_initPos = this.transform.position;
        count = 0;
        mgo_GameControl = GameObject.Find("GameControl");
    }

    void Update(){
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 11f * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision){
        if (Input.GetMouseButtonUp(0)){
            if (collision.tag == this.tag){
                Destroy(this.gameObject);
                mgo_GameControl.GetComponent<AnswerCheckEpi3>().v_CountAnswer();
            }
        }
    }
}
