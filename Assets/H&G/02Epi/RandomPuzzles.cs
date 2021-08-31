/*
 * - Name : RandomPuzzles.cs                      
 * - Writer : 유희수
 * - Content : 퍼즐조각을 랜덤으로 나오게해주는 스크립트
 * 
 * - History
 * 2021-08-10 : 초기 개발
 * 2021-08-12 : 코드 획일화 및 주석처리
 *  
 * - Variable 
 * mspa_PuzzlePieces[]                                오브젝트 연결을 위한 배열 -> 퍼즐 조각 이미지 9개 연결
 * mga_Slot[]                                         각각의 퍼즐 조각이 들어갈 슬롯 연결을 위한 배열
 * mna_RandNumArray[]                                 퍼즐조각을 랜덤으로 섞기 위한 배열
 * 
 * 
 * - Function
 *  v_RandomNum()                                     중복없이 랜덤으로 숫자를 뽑아 이미지 배치해주는 함수
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPuzzles : MonoBehaviour{

    public VoiceManager mvm_VoiceManager;
    // private bool mb_PlayFirstVoice = false;
    public Sprite[] mspa_PuzzlePieces = new Sprite[4];                                                    //오브젝트 연결을 위한 배열 -> 퍼즐 조각 이미지 9개 연결
    private GameObject[] mga_Slot = new GameObject[4];                                                    //각각의 퍼즐 조각이 들어갈 슬롯 연결을 위한 배열
    int[] mna_RandNumArray = new int[4];                                                                  //퍼즐조각을 랜덤으로 섞기 위한 배열
    /// <summary>
    /// //
    /// </summary>
    void Start(){
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        //mvm_VoiceManager.playVoice(4);
        //mvm_VoiceManager.playVoice(15);
        //오브젝트 연결
        mga_Slot[0] = GameObject.Find("Slot1");
        mga_Slot[1] = GameObject.Find("Slot2");
        mga_Slot[2] = GameObject.Find("Slot3");
        mga_Slot[3] = GameObject.Find("Slot4");
        v_RandomNum();
    }

    //중복없이 랜덤으로 숫자를 뽑아 이미지 배치해주는 함수
    //랜덤으로 뽑은 숫자를 배열에 순서대로 저장하고, 배열의 인덱스와 오브젝트의 태그를 이용해 이미지 배치
    void v_RandomNum(){ 
        //랜덤 숫자 배치
        for (int i = 0; i < 4; i++){                                                                      //0~9까지
            mna_RandNumArray[i] = Random.Range(0, 4);                                                     //9개의 배열 인덱스에 0~9까지 랜덤숫자 넣어줌
            for (int j = 0; j < i; j++){                                                                  //현재 랜덤값과 기존 배열에 있던 값을 검사
                if (mna_RandNumArray[i] == mna_RandNumArray[j]){                                          //같은 랜덤값이 있으면
                    i--;                                                                                  //다시 랜덤값 뽑기
                    break;
                }
            }
        }
        //랜덤 이미지 배치
        for (int i = 0; i < 4; i++){                                                                      
            mga_Slot[i].GetComponent<SpriteRenderer>().sprite = mspa_PuzzlePieces[mna_RandNumArray[i]];   //랜덤값에 해당하는 이미지를 해당 퍼즐 조각에 배치시킴
            mga_Slot[i].tag = mna_RandNumArray[i].ToString();                                             //정답을 체크하기 위해 태그를 바꿔줌 
        }  
    }
}
            