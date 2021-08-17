/*
 * - Name : DragBoneStick.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi10 - 마우스로 몬스터를 죽였을 때 소리가 나게 하는 스크립
                                   (핵심 내용)
 *                                 -1) 몬스터 체력이 줄었을 때 소리
 *                                 -2) 몬스터가 죽었을 때 소리
 
 * - HISTORY (수정기록)
 * 2021-08-12 : 코드 작성 
 * 2021-08-13 : 주석 작성
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

public class SoundEffectes : MonoBehaviour
{
   public AudioClip audioAttack;

   public AudioClip audioDie;

   AudioSource audioSource;

   void Awake(){

       this.audioSource = GetComponent<AudioSource>();
   }
 
   public void PlaySound(string action) {
       switch(action) {
           case "ATTACK":
                audioSource.clip = audioAttack;
                break;
            case "DIE" :
                audioSource.clip =  audioDie;
                break;

        }
        audioSource.Play();
   }
   

}
