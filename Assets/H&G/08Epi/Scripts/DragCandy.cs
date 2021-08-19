/*
 * - Name : DragCandy.class
 * - Writer : 이윤교
 * - Content : 헨젤과 그레텔 Epi8 미니게임 - 마우스 이벤트 스크립트
 *                                   - 마우스 드래그시 오브젝트가 따라 움직이게 수정
 *                                   - 마우스에서 손을 뗄 경우 오브젝트 원래위치로 이동
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-11 : 코드 획일화 및 주석처리
 * 2021-08-19 : 효과음 재생 추가
 *
 * <Variable>
 * mv2_mouseDragPosition        마우스 위치를 저장하는 벡터
 * mv2_worldObjectPosition      카메라의 월드좌표로 변환을 위한 벡터
 * SoundManager                 효과음 재생 연결 오브젝트
 *
 * <Function>
 * OnMouseDown()                오브젝트를 클릭한 경우
 * OnMouseDrag()                오브젝트를 드래그한 경우
 * OnMouseUp()                  오브젝트에서 손을 떼는 경우
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCandy : MonoBehaviour{
    private Vector3 screenSpace;
    private Vector3 offset;
    GameObject SoundManager;

    void Start(){
        SoundManager = GameObject.Find("SoundManager");
    }
    // 오브젝트를 클릭한 경우
    private void OnMouseDown(){
        SoundManager.GetComponent<SoundManager>().playSound("mouseDown");
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);                                                                           // 오브젝트의 월드 좌표를 스크린 좌표로 변환
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));     // 오브젝트 월드벡터 - 마우스 월드벡터 (벡터끼리의 차는 서로의 거리와 방향을 뜻함. 여기서는 마우스에서 오브젝트까지의 벡터)
    }

    // 오브젝트를 드래그한 경우
    private void OnMouseDrag(){
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);                                              // 현재 마우스의 스크린좌표
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;                                                                  // 마우스 벡터 + 마우스->오브젝트 벡터 = 마우스 월드 좌표
        transform.position = curPosition;                                                                                                           // 오브젝트 위치 바꾸기
        Debug.Log("드래그앤 드롭 작동중");

    }

    // 오브젝트에서 손을 떼는 경우
    private void OnMouseUp(){
        SoundManager.GetComponent<SoundManager>().playSound("mouseUp");
        Debug.Log("오브젝트에서 손 뗌");
        if(this.tag == "Pink"){                                                                                                                     // 오브젝트에 따라
            this.transform.position = new Vector3(1.986f, 1.86f, -7.54f);                                                                           // 원래 위치로 이동
        }
        if (this.tag == "Yellow"){
            this.transform.position = new Vector3(2.178f, 0.955f, -7.54f);
        }
        if (this.tag == "Blue"){
            this.transform.position = new Vector3(3.288f, 1.02f, -7.54f);
        }
    }
}
