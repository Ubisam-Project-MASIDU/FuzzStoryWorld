using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneControl : MonoBehaviour
{
    public float speed = 2.0f; // 이동 속도를 정해줌
    private Rigidbody rigid; // 중력 적용

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    public bool Run(Vector3 target) {
        float distance = Vector3.Distance(transform.position, target);
        if (distance >= 0.02f) {
            transform.position = Vector3.Slerp(transform.position, target, speed * Time.deltaTime);
            return true; // control 스크립트에서 이동처리 해주기 때문에 bool값 반환       
        }
    return false;
    }
     public void Turn(Vector3 targetPos)
    {
        // 캐릭터를 이동하고자 하는 좌표값 방향으로 회전시킨다
        Vector3 dir = targetPos - transform.position;   //방향값을 계산하여 dir에 넣어둠
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);  //위에서 계산한 방향값에서 회전을 담당하는 x와 z값만 가져옴
 
        //Quaternion.LookRotation(벡터값) : 쉽게 얘기해서 target을 기준으로 회전한다.
        Quaternion targetRot = Quaternion.LookRotation(dirXZ);
 
        //Rigibody의 강체를 . rotation 으로 변환하면 다음 물리 시뮬레이션 단계 후에 변환이 업데이트됩니다. 
        //Transform을 사용 하여 회전 을 업데이트하는 것보다 빠릅니다 .
        rigid.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1000.0f * Time.deltaTime);
        
 
    }
}

