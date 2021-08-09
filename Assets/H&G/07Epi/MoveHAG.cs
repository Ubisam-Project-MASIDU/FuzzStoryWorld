using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHAG : MonoBehaviour {
    private float mf_CheckTime = 0;
    private Vector3 mv3_TargetPos;
    private bool mb_StartWalk = false;
    
    void Update() {
        if(mb_StartWalk == true) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(mv3_TargetPos.x, transform.position.y, mv3_TargetPos.z), 0.5f * Time.deltaTime);
        }
    }

    public void SetTargetPos(Vector3 v3TargetPos) {
        mv3_TargetPos = v3TargetPos;
        mb_StartWalk = true;
    }

}
