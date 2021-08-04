/*
 * - Name : BlinkObject.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 반짝이는 효과를 주는 스크립트
 * 
 * - History
 * 1. 2021-07-27 : 초안 작성
 *                  
 * - Variable 
 * mf_time                              시간 측정을 위한 변수
 * mb_BlinkFlag                         Flag값이 True면 오브젝트를 깜박인다.
 * mb_HideFlag                          Hide Flag가 켜져있으면 오브젝트를 숨긴다.
 * 
 * -Function()
 * v_StartBlink()                       오브젝트를 반짝이게 한다.
 * v_StopBlink()                        반짝이는 효과를 제거하고 오브젝트출력
 * v_HideObject()                       오브젝트를 안보이게 설정
 * ChangBlinkFlagTrue()                 깜박이는 Flag값 True로 변경
 * ChangeBlinkFlagFalse()               깜박이는 Flag값 False로 변경
 * ChangeHideFlagTrue()                 오브젝트 숨기기 Flag값 True
 * ChangeHideFlagFalse()                오브젝트 숨기기 Flag값 False
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    float mf_time;
    bool mb_BlinkFlag = true;
    bool mb_HideFlag = false;

    // Update is called once per frame
    void Update()
    {
        if(mb_BlinkFlag == true)
        {
            v_StartBlink();
        }
        else if(mb_BlinkFlag == false && mb_HideFlag == false)
        {
            v_StopBlink();
        }
        else if(mb_HideFlag == true)
        {
            v_HideObject();
        }
    }

    #region 함수 선언부
    /// <summary>
    /// 오브젝트를 반짝이게 한다.
    /// </summary>
    public void v_StartBlink()
    {
        if (mf_time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            if (mf_time > 1f)
                mf_time = 0;
        }
        mf_time += Time.deltaTime;
    }
    /// <summary>
    /// 반짝이는 효과를 제거하고 오브젝트출력
    /// </summary>
    public void v_StopBlink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
    /// <summary>
    /// 오브젝트를 안보이게 설정
    /// </summary>
    public void v_HideObject()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    /// <summary>
    /// 깜박이는 Flag값 True로 변경
    /// </summary>
    public void ChangBlinkFlagTrue()
    {
        mb_BlinkFlag = true;
    }
    /// <summary>
    /// 깜박이는 Flag값 False
    /// </summary>
    public void ChangeBlinkFlagFalse()
    {
        mb_BlinkFlag = false;
    }
    /// <summary>
    /// 오브젝트 숨기기 Flag값 True
    /// </summary>
    public void ChangeHideFlagTrue()
    {
        mb_HideFlag = true;
    }
    /// <summary>
    /// 오브젝트 숨기기 Flag값 False
    /// </summary>
    public void ChangeHideFlagFalse()
    {
        mb_HideFlag = false;
    }
    #endregion
}
