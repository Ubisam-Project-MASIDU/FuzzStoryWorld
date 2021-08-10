using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWitch : MonoBehaviour
{

    void OnTriggerEnter(Collider cCollider) {

        if (cCollider.tag == "bb1" ){
            Destroy(cCollider.gameObject);          
        }    
        
        else if (cCollider.tag == "bb2" ){
            Destroy(cCollider.gameObject);          
        }  
    }
}
