using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWitch : MonoBehaviour
{
    void OnTriggerEnter(Collider cCollider) {
        Destroy(this);
    }
}
