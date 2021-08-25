/*
 * - Name : SoundsEffectesintro.cs
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

public class SoundsEffectesintro : MonoBehaviour
{
   public AudioClip audioKorean;                // 한국어를 선택하였을 때

   public AudioClip audioEnglish;               // 영어를 선택하였을 때

   public AudioClip audioJapan;                 // 일본어를 선택하였을 때

   public AudioClip audioChina;                 // 중국어를 선택하였을 때           

   public AudioClip audioClickSkip;            

   AudioSource audioSource;                     // 두 경우를 하나의 저장해서 다른 곳에서 불러오게 한다 

   void Awake(){

       this.audioSource = GetComponent<AudioSource>();
   }
 
   public void PlaySound(string action) {
       switch(action) {
            case "Korean":                                   // 한국어를 선택하였을 때
                audioSource.clip = audioKorean;
                break;
            case "English":                                // 영어를 선택하였을 때
                audioSource.clip = audioEnglish;
                break;
            case "Japan":                                   // 일본어를 선택하였을 때
                audioSource.clip = audioJapan;
                break;
            case "China":                                   // 중국어를 선택하였을 때
                audioSource.clip = audioChina;
                break;
            case "ClickSkip":
                audioSource.clip = audioClickSkip;
                break;

        }
        audioSource.Play();
   }   

}