/*
 * - Name : SoundofBoneStick.cs
 * - Writer : 이병권
 * - Content : 헨젤과그레텔Epi11 - 마우스로 뼈다귀를 마녀에게 주었을 때 소리가 나는 스크립
 *  
 * - HISTORY (수정기록)
 * 1) 2021-08-12 : 초기 개발
 * 2) 2021-08-13: 주석 처리 수정
 *
 * - Function
 * 1) AudioSource : 소리를 불러오는 하나의 장치
 * 2) PlaySound : 소리를 저장하면 그 소시를 불러오는 장치
 * 3) Givebone2Witch : 마녀에게 뼈다기를 주는 하나의 이름
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundofBoneStick : MonoBehaviour {

    public AudioClip Givebone2Witch;

    AudioSource audioSource;

    void Awake(){
        this.audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(string action){
        switch(action){
            case "GIVE":
            audioSource.clip =  Givebone2Witch;
            break;
        }
        audioSource.Play();
    }

}
