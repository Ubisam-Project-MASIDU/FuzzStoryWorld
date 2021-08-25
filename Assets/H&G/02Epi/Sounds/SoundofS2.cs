/*
 * - Name : SoundodS2.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi_2 - 1. 마우스로 문을 클릭하여 걸어 갈때
 *                               - 2. 마우스로 시작 버튼을 눌렀을 때 미니게임 시작 할때
 * - HISTORY (수정기록)
 * 2021-08-25 : 코드 작성 
 * 2021-08-26 : 주석 작성
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

public class SoundofS2 : MonoBehaviour
{

  public AudioClip audioWalk;                // 문을 선택하여 걸어 갈때

   AudioSource audioSource;                     // 두 경우를 하나의 저장해서 다른 곳에서 불러오게 한다 

   void Awake(){

       this.audioSource = GetComponent<AudioSource>();
   }
 
   public void PlaySound(string action) {
       switch(action) {
            case "Walk":                                   // 한국어를 선택하였을 때
                audioSource.clip = audioWalk;
                break;
        }
        audioSource.Play();
   }   

}
