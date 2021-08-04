/*
 * - Name : CharacterMovesWhenDragging.cs
 * - Writer : 김명현
 * 
 * - Content
 * 오브젝트를 클릭후 드래그할 경우 해당 오브젝트가 이동되는 스크립트
 * 
 * - History
 * 1. 2021-07-27 : 초안 작성
 *                  
 * - Variable 
 * mv2_mouseDragPosition                마우스 위치를 저장하는 벡터
 * mv2_worldObjectPosition              카메라의 월드좌표로 변환을 위한 벡터
 * msm_soundManager                     SoundManager 오브젝트에 접근하기위한 변수
 * mb_DragFlag                          Flag가 켜져있는동안에만 드래그 기능 활성화
 * mb_SoundFlag                         효과음이 한번만 나오게하기위한 Flag
 * mb_DraggingFlag                      오브젝트가 드래그중인지 확인하기 위한 Flag
 * mb_MouseUpFlag                       오브젝트에서 손을 떼는 순간을 알기위한 Flag
 * - Function
 * OnMouseDrag()                        오브젝트를 드래그한 경우
 * OnMouseUp()                          오브젝트에서 손을 떼는 경우
 * v_ChangeDragFlagTrue()               오브젝트가 Drag 가능한 상태로 변경
 * v_ChangeDragFlagFalse()              오브젝트가 Drag 불가능한 상태로 변경
 * v_CheckDragFlag()                    오브젝트가 드래그 가능한 상태인지 확인
 * b_CheckDragging()                    오브젝트가 현재 드래그 중인지 확인하는 함수
 * b_CheckMouseUp()                     오브젝트에서 손을 떼는순간 Flag값 True 반환해주는 함수
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 오브젝트 드래그시 효과음 및 마우스 포인터 위치에 따라 오브젝트가 이동하게끔 해주는 스크립트
/// </summary>
public class CharacterMovesWhenDragging : MonoBehaviour
{
    private SoundManager msm_soundManager;
    private bool mb_DragFlag = true;                                                                                    // Flag가 켜져있는동안에만 드래그 기능 활성화
    private bool mb_SoundFlag = false;                                                                                  // 효과음이 한번만 나오게하기위한 Flag
    private bool mb_DraggingFlag = false;                                                                               // 오브젝트가 드래그중인지 확인하기 위한 Flag
    private bool mb_MouseUpFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        msm_soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();                                // 효과음을 위해 SoundManager 오브젝트 연결
    }

    // Update is called once per frame
    void Update()
    {
        //mb_MouseUpFlag = false;                                                                                         // 평상시 MouseUpFlag 값 False 유지
    }

    /// <summary>
    /// 오브젝트를 드래그하는경우 작동되는 함수
    /// </summary>
    private void OnMouseDrag()
    {
        if (mb_DragFlag == true)
        {
            Vector2 mv2_mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 mv2_worldObjectPosition = Camera.main.ScreenToWorldPoint(mv2_mouseDragPosition);
            this.transform.position = mv2_worldObjectPosition;
            Debug.Log("오브젝트 드래그 상태");
            mb_DraggingFlag = true;                                                                                     // 드래깅 상태 Flag값 True
            if (mb_SoundFlag == false)                                                                                  // 드래그 시 효과음 재생
            {
                msm_soundManager.playSound(0);
                mb_SoundFlag = true;
            }
        }
    }
    /// <summary>
    /// 오브젝트에서 손을 떼는 경우
    /// </summary>
    private void OnMouseUp()
    {
        if (mb_DragFlag == true)
        {
            Debug.Log("오브젝트에서 손 뗌");
            msm_soundManager.playSound(1);                                                                              // 드래그 해제 시 효과음 재생
            mb_SoundFlag = false;
            mb_DraggingFlag = false;                                                                                    // 드래깅 상태 Flag값 False
            mb_MouseUpFlag = true;
            Invoke("v_ChangeMouseUpFalgFalse", 0.5f);
        }
    }
    
    /// <summary>
    /// 드래그 가능한 상태로 변경
    /// </summary>
    public void v_ChangeDragFlagTrue()
    {
        mb_DragFlag = true;
    }
    /// <summary>
    /// 드래그 불가능한 상태로 변경
    /// </summary>
    public void v_ChangeDragFlagFalse()
    {
        mb_DragFlag = false;
    }
    /// <summary>
    /// 드래그가 가능한 상태인지 확인
    /// </summary>
    /// <returns>드래그가 가능한 상태면 True, 아니면 False</returns>
    public bool v_CheckDragFlag()
    {
        return mb_DragFlag;
    }
    /// <summary>
    /// 현재 드래그상태인지 확인
    /// </summary>
    /// <returns>드래그 중이면 True 아니면 False 반환</returns>
    public bool b_CheckDragging()
    {
        return mb_DraggingFlag;
    }
    /// <summary>
    /// 오브젝트에서 손을 떼는순간 Flag값 True 반환해주는 함수
    /// </summary>
    /// <returns>오브젝트에서 손을떼는순간 True반환 아니면 False</returns>
    public bool b_CheckMouseUp()
    {
        return mb_MouseUpFlag;
    }
    public void v_ChangeMouseUpFalgFalse()
    {
        mb_MouseUpFlag = false;
    }
}
