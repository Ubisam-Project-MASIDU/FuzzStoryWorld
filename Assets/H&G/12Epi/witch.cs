using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witch : MonoBehaviour
{

    void OnCollisionEnter(Collision collison) {
        if(collison.gameObject.tag == "bone") {
            Debug.Log("마녀가 맞음");
        }
    }
}
