using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    GameObject mg_GameDirector;
    GameObject mg_RandomItem;
    int mn_answer;
    int mn_LeftTime;

    // Start is called before the first frame update
    void Start()
    {
        this.mg_GameDirector = GameObject.Find("GameDirector");                                         // 게임오브젝트들 연결
        this.mg_RandomItem = GameObject.Find("RandomImage");
    }

    // Update is called once per frame
    void Update()
    {
        mn_answer = mg_RandomItem.GetComponent<RandomCandy>().n_ReturnAnswer();                       // 실시간으로 정답을 전달받는다
    }

    void OnTriggerEnter2D(Collider2D cCollidObj){
        if(cCollidObj.tag == "Pink"){
            if (mn_answer == 0){
                Debug.Log("Pink Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(0);                 // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();            // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                          // 정답이 되었다고 flag값 변경  
            }else{
                Debug.Log("Pink Candy 먹기 실패");
            }
        }else if(cCollidObj.tag == "Yellow"){
            if (mn_answer == 1){
                Debug.Log("Yellow Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(1);                 // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();            // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                          // 정답이 되었다고 flag값 변경  
            }else{
                Debug.Log("Yellow Candy 먹기 실패");
            }
        }else if(cCollidObj.tag == "Blue"){
            if (mn_answer == 2){
                Debug.Log("Blue Candy 먹기 성공");
                mg_GameDirector.GetComponent<CandyControl>().v_CheckRandomItemArr(2);                 // 정답배열에 해당 아이템이 정답처리가 되었다고 표시
                mn_LeftTime = mg_GameDirector.GetComponent<CandyControl>().n_HowManyleftArr();            // 남은 횟수 확인 및 값 저장
                Destroy(cCollidObj.gameObject);
                mg_GameDirector.GetComponent<CandyControl>().v_ChangeFlagTrue();                          // 정답이 되었다고 flag값 변경  
            }else{
                Debug.Log("Blue Candy 먹기 실패");
            }
        }
    }
}
