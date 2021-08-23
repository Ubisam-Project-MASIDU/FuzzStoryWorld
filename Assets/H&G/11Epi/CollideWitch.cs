/*
 * - Name : CollideWitch.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi11 - 헨젤과그레텔이 가지고 있는 뼈 막대기와 마녀가 만났을때 사라지게 하는 스크렙
 
 * - HISTORY (수정기록)
 * 1) 2021-08-5 : 초기 개발
 * 2) 2021-08-9 : 파일 인코딩 수정
 * 3) 2021-08-11 : 주석 처리 수정
 
 * <Function> 쓴것들에 대하여 설명
 * 1) OnTriggerEnter : 해당 트리거 콜라이더와 트리거와 접촉한 강체(or 강체가 없다면 콜라이더)로 보내집니다 (충돌)
 * 2) cCollider.tag : 충돌해야 하는 물체를 이름을 설정해서 지정해주는 것
 * 3)Destory : 충돌하였을 때 사라지게 하는 것
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWitch : MonoBehaviour 
{

    GameObject ControlBone;
    void Start(){
        ControlBone = GameObject.Find("ControlBone");
    }
    

    void OnTriggerEnter(Collider cCollider) {


        if (cCollider.tag == "bb1" ){                 // bb1(그레텔이 가지고 있는 뼈다기 이름을 backbone인데 그것을 줄여서 bb로 지정하고 사라지게 하기 위해 이름을 붙여줌) 
            ControlBone.GetComponent<TurnPage>().Delete();
            Destroy(cCollider.gameObject);            // 만약 위에 bb1일 Witch(마녀)에 3D에 다았을 때 사라지게 함
            GetComponent<SoundofBoneStick>().PlaySound("GIVE");    // 만약 뼈다귀를 받았으면 소리가 나게한다
        }    
        
        else if (cCollider.tag == "bb2" ){           // bb2(헨젤이 가지고 있는 뼈다기 이름을 backbone인데 그것을 줄여서 bb로 지정하고 사라지게 하기 위해 이름을 붙여줌) 
            ControlBone.GetComponent<TurnPage>().Delete();
            Destroy(cCollider.gameObject);           // 만약 위에 bb1일 Witch(마녀)에 3D에 다았을 때 사라지게 함  
            GetComponent<SoundofBoneStick>().PlaySound("GIVE");         // 만약 뼈다귀를 받았으면 소리가 나게한다
        }
    }
        
}
