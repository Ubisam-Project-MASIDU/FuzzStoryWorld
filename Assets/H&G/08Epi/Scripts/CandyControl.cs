/*
 * - Name : CandyControl.class
 * - Writer : 이윤교
 * - Content : 헨젤과그레텔 Epi8 미니게임 - 배열로 남은 아이템 관리, 이 배열을 통해 랜덤으로 정답을 정하는 함수 및 아이템이 바뀌었는지 flag로 관리하는 스크립트
 * 
 * - HISTORY
 * 2021-08-10 : 초기 개발
 * 2021-08-11 : 코드 획일화 및 주석처리
 *
 * <Variable>
 * mba_RandomItemArr            각 아이템들이 이미 정답으로 나왔었는지 확인을 위한 용도의 배열
 * mn_RandomValue               정답을 저장하는 변수
 * mb_ChangeItemFlag            아이템이 바뀌었는지 확인하기위한 용도의 flag
 *
 * <Function>
 * v_CheckRandomItemArr()       정답배열에 num번째 값이 정답이 됬다고 설정해주는 함수
 * n_RandomItemValue()          정답배열을 참고하여 한번도 정답되지 않은 아이템중 랜덤값을 설정해주는 함수
 * n_HowManyleftArr()           게임이 완료되기 위해서 몇번의 정답이 더 남았는지를 반환해 주는 함수
 * v_ChangeFlagTrue()           mb_ChangeItemFlag 값 True로 설정
 * v_ChangeFlagFalse()          mb_ChangeItemFlag 값 False로 설정
 * b_checkFlag()                mb_ChangeItemFlag 값 반환
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyControl : MonoBehaviour{
    private bool[] mba_RandomItemArr = new bool[3];                   // 정답 관리하는 배열
    private int mn_RandomValue;
    private bool mb_ChangeItemFlag;
    
    void Start(){
        mb_ChangeItemFlag = false;                                    // Flag값 False로 초기화
        for (int n_i = 0; n_i < 3; n_i++){                            // 정답 배열 False로 초기화
            mba_RandomItemArr[n_i] = false;
        }
    }

    // 정답배열에 num번째 값이 정답이 됬다고 설정해주는 함수
    // num번째 정답배열값 true 입력
    public void v_CheckRandomItemArr(int num){
        mba_RandomItemArr[num] = true;
        Debug.Log(num + "번째 배열 트루값 입력");
    }

    // 정답배열을 참고하여 한번도 정답되지 않은 아이템중 랜덤값을 설정해주는 함수
    public int n_RandomItemValue(){
        while (true){
            mn_RandomValue = Random.Range(0, 3);
            if (mba_RandomItemArr[mn_RandomValue] == false){
                break;
            }
        }
        return mn_RandomValue;
    }

    // 게임이 완료되기 위해서 몇번의 정답이 더 남았는지를 반환해 주는 함수
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

    // mb_ChangeItemFlag 값 True로 설정
    public void v_ChangeFlagTrue(){
        mb_ChangeItemFlag = true;
        Debug.Log("Flag값 True");
    }

    // mb_ChangeItemFlag 값 False로 설정
    public void v_ChangeFlagFalse(){
        mb_ChangeItemFlag = false ;
        Debug.Log("Flag값 False");
    }

    // mb_ChangeItemFlag 값 반환해주는 함수
    public bool b_checkFlag(){
        return mb_ChangeItemFlag;
    }
}
