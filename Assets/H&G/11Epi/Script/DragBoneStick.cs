/*
 * - Name : DragBoneStick.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi11 - 마우스로 뼈다귀를 이용 할 수 있는 스크랩
 *                                  (핵심 내용)
 *                                 -1) 마우스로 오브젝트를 움직이게 한다
 *                                 -2) 마우스에서 손을 떼었을 때 오브젝트가 원래위치로 이동
 *                                 -3) 마우스에 오브젝트를 눌렀을 때 소리가 난다.
 *
 * - HISTORY (수정기록)
 * 1) 2021-08-5 : 초기 개발
 * 2) 2021-08-9 : 파일 인코딩 수정
 * 3) 2021-08-11 : 주석 처리 수정
 * 4) 2021-08-30 : 소리 수정
 *
 * - <Variable> 쓴것들에 대하여 설명
 * 1) mv2_mouseDragPosition        마우스 위치를 저장하는 벡터
 * 2) mv2_worldObjectPosition      카메라의 월드좌표로 변환을 위한 벡터
 *
 * - <Function>
 * 1) OnMouseDown()                오브젝트를 클릭한 경우
 * 2) OnMouseDrag()                오브젝트를 드래그한 경우
 * 3) OnMouseUp()                  오브젝트에서 손을 떼는 경우
 * 4) OnTriggerEnter :             해당 트리거 콜라이더와 트리거와 접촉한 강체(or 강체가 없다면 콜라이더)로 보내집니다 (충돌)
 * 5) cCollider.tag :              충돌해야 하는 물체를 이름을 설정해서 지정해주는 것
 * 6) Destory :                    충돌하였을 때 사라지게 하는 것
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBoneStick : MonoBehaviour
{
    private Vector3 screenSpace;
    private Vector3 offset;

    GameObject mg_SoundManager;

    void Start(){
        mg_SoundManager = GameObject.Find("SoundManager");                                  // 사운드 매니저 게임오브젝트 연결
    }

    // 오브젝트를 클릭한 경우
    private void OnMouseDown(){
        mg_SoundManager.GetComponent<SoundManager>().playSound("Clik3");                    // 물체를 견인을 때 소리 나게 하기
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
    }

    // 오브젝트를 드래그한 경우
    private void OnMouseDrag(){
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = curPosition;
        Debug.Log("드래그앤 드롭 작동중");

    }

    // 오브젝트에서 손을 떼는 경우
    // 오브젝트에 따라 원래 위치로 이동
    private void OnMouseUp(){
        Debug.Log("오브젝트에서 손 뗌");
        if(this.tag == "bb1"){                                                    
            this.transform.position = new Vector3(-1.32f, 1.02f, -7.5f);             
        }
        if (this.tag == "bb2"){
            this.transform.position = new Vector3(1.0f, 1.02f, -7.5f);
        }
    }
}
