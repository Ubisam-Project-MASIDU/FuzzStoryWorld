/*
 * - Name : SoundsEffectsSprasch.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi_0(intro) - 마우스로 나라별로 선택하였을 때 소리가 나게 하는 스크립
 *
 * - HISTORY (수정기록)
 * 2021-08-24 : 코드 작성 
 * 2021-08-25 : 주석 작성
 * 
 * <Function>
 * AudioSource : 소리를 불러오는 하나의 장치
 * PlaySound : 소리를 저장하면 그 소시를 불러오는 장치
 * audioAttack : 공격을 할때 소리를 불러오는 장치
 * audioDie : 케릭터가 죽었을 때 소리를 불러오는 장치
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffectsSprash : MonoBehaviour
{
   public AudioClip audioJumpandEnter;                // 한국어를 선택하였을 때

   public AudioClip audioWalking;               // 영어를 선택하였을 때

                  

   AudioSource audioSource;                     // 두 경우를 하나의 저장해서 다른 곳에서 불러오게 한다 

   void Awake(){

       this.audioSource = GetComponent<AudioSource>();
   }
 
   public void PlaySound(string action) {
       switch(action) {
            case "Enter":                                   // 책에 들어갔을 때
                audioSource.clip = audioJumpandEnter;
                break;
            case "Walk":                                // 걸어 갈 때
                audioSource.clip = audioWalking;
                break;
        }
        audioSource.Play();
   }
   

}
