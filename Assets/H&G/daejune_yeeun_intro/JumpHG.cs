using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHG : MonoBehaviour
{
    public GameObject mv3_TargetPos;
    private bool mb_CheckOnceJump = true;

    void Update() {
        if (Mathf.Abs(mv3_TargetPos.transform.position.x - transform.position.x) < 0.001 && mb_CheckOnceJump) {
            Invoke("jump", 1.5f);
            mb_CheckOnceJump = false;
        }
        else {
            transform.position = Vector3.Slerp(transform.position, mv3_TargetPos.transform.position, 0.4f * Time.deltaTime);
        }
    }
    void jump() {
        gameObject.GetComponent<Rigidbody>().AddForce(75f, 300f, 25f);
    }
}
