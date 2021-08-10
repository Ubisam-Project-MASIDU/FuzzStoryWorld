/*
 * - Name : EpisodeController.cs
 * - Writer : 최대준
 * 
 * - Content :
 * 현재 에피소드의 진행을 맡는 스크립트 클래스이다.
 * 
 * - History
 * 1) 2021-08-05 : 코드 구현. 
 * 2) 2021-08-06 : 주석 작성.
 *  
 * - Variable 
 * mgo_Bird                                     씬에서 표현되는 새 오브젝트 변수이다.
 * mgo_BirdPrefab                               씬에서 생성될 새 오브젝트의 스테레오 타입 변수이다.
 * mgo_HAG                                      헨젤과 그레텔 게임 오브젝트 변수이다.
 * mb_CheckScenarioFirst                        새가 날라가 나무에 도착했을 때를 첫 번째 시나리오로 하고, 새가 날라가 나무 그루터기까지 도착했을 때를 두 번째 시나리오라 했을 때, 언제가 첫 번째 시나리오고, 언제가 두 번째 시나리오인지 검사하는 변수이다.
 * mb_CheckScenarioSecond                       새가 나무 그루터기까지 도착했을 때를 나타내주는 변수이다.
 * mb_CheckScenarioFirstOnce                    각각 시나리오는 한 번씩만 실행되어야 하기 때문에 필요한 flag 변수이다.
 * mb_CheckScenarioSecondOnce                   각각 시나리오는 한 번씩만 실행되어야 하기 때문에 필요한 flag 변수이다.
 * 
 *
 * - Function
 * Update()                                     새가 어느정도 도착했는 지를 계속 관찰해 나무, 그루터기가 있는 곳까지 도달했을 때 나무, 그루터기에서 플레이어를 기다리는 것 처럼 보이게 구현한다.
 * waitPlayer()                               새가 나무, 그루터기 쪽에 도달했을 때, 새는 Destroy하고, 앉아 있는 모습의 새를 Instiate()한다.
 * restartFlying()                                   플레이어가 나무, 그루터기 쪽에 도달했다면, 앉아 있는 새를 Destroy하고, 다시 날라가는 새를 Instiate()한다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 에피소드에서 필요한 동작을 정의하는 클래스이다.
public class EpisodeController : MonoBehaviour {

    public GameObject mgo_Bird;                     // 새 오브젝트
    public GameObject mgo_BirdPrefab;               // 새 프리팹
    public GameObject mgo_HAG;                      // 헨젤과 그레텔 오브젝트

    private bool mb_CheckScenarioFirst = false;     // 시나리오 첫번째 인지 두번째인지 판단.
    private bool mb_CheckScenarioFirstOnce = false; // 각 시나리오가 한 번씩만 실행되는지 판단.
    private bool mb_CheckScenarioSecondOnce = false;
    private bool mb_CheckScenarioSecond = false;


    // 새 오브젝트가 x 좌표로 어느정도 왔는지 판단하고 시나리오를 실행한다.
    void Update() {
        if(mgo_Bird != null) {
            if(mgo_Bird.transform.position.x > -4.2 && !mb_CheckScenarioFirst && !mb_CheckScenarioFirstOnce) {
                waitPlayer();
                mb_CheckScenarioFirst = true;
            } else if (mgo_HAG.transform.position.x > -4.8 && mb_CheckScenarioFirst && !mb_CheckScenarioFirstOnce) {
                restartFlying();
                mb_CheckScenarioFirstOnce = true;
            } else if(mgo_Bird.transform.position.x > 1&& !mb_CheckScenarioSecond && !mb_CheckScenarioSecondOnce) {
                waitPlayer();
                mb_CheckScenarioSecond = true;
            } else if (mgo_HAG.transform.position.x > 0 && mb_CheckScenarioSecond && !mb_CheckScenarioSecondOnce) {
                restartFlying();
                mb_CheckScenarioSecondOnce = true;
            }
        }
        
    }

    // 시나리오에서 필요한 동작을 정의한 함수. 플레이어를 기다린다.
    void waitPlayer() {
        Destroy(mgo_Bird);
        mgo_Bird = transform.GetChild(0).gameObject;
        mgo_Bird.SetActive(true);
    }

    // 시나리오에서 필요한 동작을 정의한 함수. 플레이어가 도착하면, 다시 날아간다.
    void restartFlying() {
        Transform temp = mgo_Bird.transform;
        Destroy(mgo_Bird);
        mgo_Bird = Instantiate(mgo_BirdPrefab, temp.position, mgo_BirdPrefab.transform.rotation);
    }
}
