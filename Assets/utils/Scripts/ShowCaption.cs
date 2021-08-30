/*
 * - Name : ShowCaption.cs
 * - Writer : 유희수

 * - Content : 자막 on/off 하는 버튼 컨트롤하는 스크립트 
 *
 * - History
 * 1) 2021-08-20 : 초기 개발
 * 2) 2021-08-30 : 코드 획일화 및 주석 처리
 * 
 * - Variable 
 * mcc_CaptionControl                                 CaptionControl 클래스에서 자막 인덱스를 가져오기 위한 객체                                 
 * mg_Offbtn                                          Off버튼 연결
 * mg_Onbtn                                           On버튼 연결
 * 
 * - Function
 * captionOn                                          자막 On버튼을 눌렀을때 실행되는 함수
 * captionOff                                         자막 Off버튼을 눌렀을때 실행되는 함수
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCaption : MonoBehaviour{
    private CaptionControl mcc_CaptionControl;
    private GameObject mg_Offbtn;
    private GameObject mg_Onbtn;

    void Start(){
        mcc_CaptionControl = GameObject.Find("CaptionPanel").GetComponent<CaptionControl>();
        mg_Offbtn = GameObject.Find("Off");
        mg_Onbtn = GameObject.Find("On");
    }
    //On버튼을 누르면 자막이 사라지고 Off버튼 나오는 함수
    public void captionOn(){
        this.gameObject.SetActive(false);        
        mg_Onbtn.SetActive(false);
        mg_Offbtn.SetActive(true); 
    }
    // Off버튼을 누르면 자막 생기고 On버튼 나오는 함수
    public void captionOff(){
        this.gameObject.SetActive(true);
        mg_Onbtn.SetActive(true);
        mg_Offbtn.SetActive(false);
    }
}
