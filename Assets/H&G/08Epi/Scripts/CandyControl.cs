using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyControl : MonoBehaviour
{
    private bool[] mba_RandomItemArr = new bool[3];                   // 정답 관리하는 배열
    private int mn_RandomValue;
    private bool mb_ChangeItemFlag;
    
    void Start(){
        mb_ChangeItemFlag = false;                                          // Flag값 False로 초기화
        for (int n_i = 0; n_i < 3; n_i++){                                  // 정답 배열 False로 초기화
            mba_RandomItemArr[n_i] = false;
        }
    }

    /// <summary>
    /// 정답배열에 num번째 값이 정답이 됬다고 설정해주는 함수
    /// </summary>
    /// <param name="num">num번째 정답배열값 true 입력</param>
    public void v_CheckRandomItemArr(int num){
        mba_RandomItemArr[num] = true;
        Debug.Log(num + "번째 배열 트루값 입력");
    }

    /// <summary>
    /// 정답배열을 참고하여 한번도 정답되지 않은 아이템중 랜덤값을 설정해주는 함수
    /// </summary>
    /// <returns>int 랜덤값</returns>
    public int n_RandomItemValue(){
        while (true){
            mn_RandomValue = Random.Range(0, 3);
            if (mba_RandomItemArr[mn_RandomValue] == false){
                break;
            }
        }
        return mn_RandomValue;
    }

    /// <summary>
    /// 게임이 완료되기 위해서 몇번의 정답이 더 남았는지를 반환해 주는 함수
    /// </summary>
    /// <returns>int 남은 횟수</returns>
    public int n_HowManyleftArr(){
        int n_left = 0;
        for (int n_i = 0; n_i < 3; n_i++){
            if (mba_RandomItemArr[n_i] == true){
                Debug.Log(n_i + "번째 배열값 true");
            }
            if (mba_RandomItemArr[n_i] == false){
                Debug.Log(n_i + "번째 배열값 false");
                n_left += 1;
            }
        }
        Debug.Log(n_left + "번 남았습니다.");
        return n_left;
    }

    /// <summary>
    /// mb_ChangeItemFlag 값 True로 설정
    /// </summary>
    public void v_ChangeFlagTrue(){
        mb_ChangeItemFlag = true;
        Debug.Log("Flag값 True");
    }

    /// <summary>
    /// mb_ChangeItemFlag 값 False로 설정
    /// </summary>
    public void v_ChangeFlagFalse(){
        mb_ChangeItemFlag = false ;
        Debug.Log("Flag값 False");
    }

    /// <summary>
    /// mb_ChangeItemFlag 값 반환해주는 함수
    /// </summary>
    /// <returns>Flag값</returns>
    public bool b_checkFlag(){
        return mb_ChangeItemFlag;
    }
}
