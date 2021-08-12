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
 * mgo_Bird                 씬에서 표현되는 새 오브젝트 변수이다.
 * mgo_BirdPrefab           씬에서 생성될 새 오브젝트의 스테레오 타입 변수이다.
 * mgo_HAG                  헨젤과 그레텔 게임 오브젝트 변수이다.
 * mfa_CheckBirdPos         새가 날라가 나무에 도착했을 때를 첫 번째 시나리오로 하고, 새가 날라가 나무 그루터기까지 도착했을 때를 두 번째 시나리오라 했을 때, 언제가 첫 번째 시나리오고, 언제가 두 번째 시나리오인지 검사하는 변수이다. 일정한 x좌표 값을 2개 가지고 있어 새의 위치를 검사할 때 기준이 되어준다. 
 * mfa_CheckHAGPos          헨젤과그레텔이 나무에 도착했을 때를 첫 번째 시나리오로 하고, 헨젤과 그레텔이 나무 그루터기까지 도착했을 때를 두 번째 시나리오라 했을 때, 언제가 첫 번째 시나리오고, 언제가 두 번째 시나리오인지 검사하는 변수이다. 일정한 x좌표 값을 2개 가지고 있어 헨젤과그레텔의 위치를 검사할 때 기준이 되어준다.
 * mn_checkCurScene         각각 시나리오는 한 번씩만 실행되어야 하기 때문에 현재 진행사항을 int형 변수로 저장하고 있다.
 * 
 *
 * - Function
 * Update()                 새가 어느정도 도착했는 지를 계속 관찰해 나무, 그루터기가 있는 곳까지 도달했을 때 나무, 그루터기에서 플레이어를 기다리는 것 처럼 보이게 구현한다.
 * waitPlayer()             새가 나무, 그루터기 쪽에 도달했을 때, 새는 Destroy하고, 앉아 있는 모습의 새를 Instiate()한다.
 * restartFlying()          플레이어가 나무, 그루터기 쪽에 도달했다면, 앉아 있는 새를 Destroy하고, 다시 날라가는 새를 Instiate()한다.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 에피소드에서 필요한 동작을 정의하는 클래스이다.
public class EpisodeController : MonoBehaviour {

    public GameObject mgo_Bird;                     // 새 오브젝트
    public GameObject mgo_BirdPrefab;               // 새 프리팹
    public GameObject mgo_HAG;                      // 헨젤과 그레텔 오브젝트
    private float[] mfa_CheckBirdPos = new float[2];
    private float[] mfa_CheckHAGPos = new float[2];
    private int mn_checkCurScene = 0;


    void Start() {
        mfa_CheckBirdPos[0] = -10f; mfa_CheckBirdPos[1] = 8.7f;
        mfa_CheckHAGPos[0] = -13f; mfa_CheckHAGPos[1] = 6f;
    }

    // 새 오브젝트가 x 좌표로 어느정도 왔는지 판단하고 시나리오를 실행한다.
    void Update() {
        if (mn_checkCurScene < mfa_CheckBirdPos.Length) {
            if (mgo_Bird.transform.localPosition.x > mfa_CheckBirdPos[mn_checkCurScene]) {
                waitPlayer();
            } else if (mgo_HAG.transform.localPosition.x > mfa_CheckHAGPos[mn_checkCurScene]) {
                restartFlying();
                mn_checkCurScene++;
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
        mgo_Bird = Instantiate(mgo_BirdPrefab, temp.position, mgo_BirdPrefab.transform.rotation, transform);
    }
}
