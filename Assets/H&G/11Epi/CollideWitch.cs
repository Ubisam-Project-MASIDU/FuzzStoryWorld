using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWitch : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D cCollider) {

        if (this.tag == "bb1" ){
            Destroy(this.gameObject);          
        }    
    }
}
