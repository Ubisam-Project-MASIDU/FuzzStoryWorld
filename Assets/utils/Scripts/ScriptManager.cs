/*
 * - Name : ScriptManager.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 스크립트(대사)관리하는 스크립트
 * 
 * - History -
 * 1. 2021-07-27 : 초안 작성
 * 
 * - 사용법
 * 1. ms_Script 에 스크립트(대사)들을 입력해둔다.
 * 2. mg_ScriptObject 에 텍스트를 출력할 오브젝트를 연결한다.
 * 3. 함수들을 통해 스크립트를 출력하거나 내용을 지운다.
 *                    
 * - Variable 
 * ms_Script                                            스크립트(대사)를 저장해두는 배열 
 * mg_ScriptObject                                      스크립트를 입력할 오브젝트
 * mn_ScriptSequence                                    출력할 스크립트(대사)를 순서를 저장한 변수 (차례)
 * 
 * - Function
 * v_NoneScript(int nGameObjectNum)                     텍스트 값을 공백으로 설정해주는 함수
 * v_NextScript(int nGameObjectNum)                     배열에 저장된 다음 문자열을 출력해주는 함수
 * v_NextScript(int nGameObjectNum, int nScriptnum)     인덱스 값을 입력받아 해당 문자열을 출력해주는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스크립트(대사)를 관리하는 스크립트, 연결한 오브젝트의 텍스트값을 공백, 설정해둔 문자열로 출력할수 있다.
/// </summary>
public class ScriptManager : MonoBehaviour
{
    #region 변수 선언부

    public string[] ms_Script;                                                                              // 스크립트(대사)를 저장해두는 배열 
    public GameObject[] mg_ScriptObject;                                                                      // 스크립트를 입력할 오브젝트
    int mn_ScriptSequence = -1;                                                                             // 출력할 스크립트(대사)를 순서를 저장한 변수
    #endregion

    #region 함수 선언부

    /// <summary>
    /// 텍스트 값을 공백으로 설정해주는 함수
    /// </summary>
    /// <param name="nGameObjectNum">텍스트 값을 지울 오브젝트의 인덱스 값</param>
    public void v_NoneScript(int nGameObjectNum)
    {
        mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = "";
    }

    /// <summary>
    /// 전달받은 인덱스의 오브젝트 텍스트값에 저장된 다음 문자열을 출력해주는 함수
    /// </summary>
    /// <param name="nGameObjectNum">출력할 위치의 오브젝트 인덱스 값</param>
    public void v_NextScript(int nGameObjectNum)
    {
        mn_ScriptSequence += 1;                                                                             // 함수가 실행될 때 차례를 1증가시킨후 출력
        if (mn_ScriptSequence < ms_Script.Length)                                                           // 차례에 맞는 스크립트 출력
        {
            mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = ms_Script[mn_ScriptSequence];
        }
        else if (mn_ScriptSequence >= ms_Script.Length)                                                     // 배열의 크기를 초과한 경우 오류문구 출력
        {
            Debug.Log(mg_ScriptObject[nGameObjectNum].name + "오브젝트에 넣을 스크립트 배열 최대크기를 초과했습니다.");
        }
    }

    /// <summary>
    /// 인덱스 값을 입력받아 해당 문자열을 출력해주는 함수
    /// </summary>
    /// <param name="nGameObjectNum">출력할 위치의 오브젝트 인덱스 값</param>
    /// <param name="nScriptnum">출력할 텍스트의 인덱스 값</param>
    public void v_NextScript(int nGameObjectNum, int nScriptnum)
    {
        if(nScriptnum >= ms_Script.Length)                                                                         // 배열의 크기를 초과한 경우 오류문구 출력
        {
            Debug.Log(mg_ScriptObject[nGameObjectNum].name + "의 NextScript(" + nScriptnum + ")함수로 입력한 값이 스트링배열 최대크기를 초과했습니다.");
        }
        else                                                                                                // 매겨변수로 입력받은 순서의 스크립트 출력
        {
            mg_ScriptObject[nGameObjectNum].GetComponent<Text>().text = ms_Script[nScriptnum];
        }
    }
    #endregion
}
