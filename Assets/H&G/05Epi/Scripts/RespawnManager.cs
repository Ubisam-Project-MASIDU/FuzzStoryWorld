/*
 * - Name : RespawnManager.cs
 * - Writer : 이윤교
 * - Content : 게임을 시작할 때 조약돌을 미리 여러개를 생성하고 필요할 때 마다 활성화를 시키고 필요가 없어지면 비활성화를 시키는 스크립트
 * 
 * - HISTORY
 * 2021-08-13 : 초기 개발
 * 2021-08-18 : 코드 주석처리
 * 2021-08-23 : 코드 획일화
 *
 *
 * <Variable>
 * ma_Rocks        GameObject형 배열
 * ml_RockPool     GameObject형 리스트
 * mn_objCnt       원하는 조약돌 갯수 지정 변수
 *
 * <Function>
 * PlayGame()   게임 재생 메소드
 * DeativRock() 비활성화가 되어았는 오브젝트를 찾기
 * CreateObj()  ml_RockPool에 추가할 오브젝트 복제를 위함
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour{
    // GameObject형 배열과 리스트 선언
    public GameObject[] ma_Rocks;                                    // 조약돌 prefabs 을 넣어둠, 게임이 시작하면 배열의 prefabs을 복사해서 리스트에 추가하고 관리해 줄거임
    public List<GameObject> ml_RockPool = new List<GameObject>();
    public int mn_objCnt = 1;                                        // Inspector 창에서 조약돌 원하는 갯수 지정 가능

    void Awake(){
        for(int i = 0; i < ma_Rocks.Length; i++){
            for (int q = 0; q < mn_objCnt; q++){                     // 조약돌 배열의 prefab을 원하는 수 만큼 생성해서 ml_RockPool 리스트에 추가 
                ml_RockPool.Add(CreateObj(ma_Rocks[i], transform));
            }
        }
    }

    private void Start(){
        GameManager.instance.onPlay += PlayGame;                    // delegate에 등록
    }

    // PlayGame 메소드 생성
    void PlayGame(bool isplay){
        // 모든 조약돌 비활성화 상태로 만들기
        for (int i = 0; i < ml_RockPool.Count; i++){                   
            if(ml_RockPool[i].activeSelf){                          // 조약돌이 활성화가 되어있다면
                ml_RockPool[i].SetActive(false);                    // 비활성화 시키기
            }
        }
        if(isplay){                                                 // 게임이 진행중이면
            StartCoroutine(CreateRock()); 
        }else{
            StopAllCoroutines();
        }   
    }

    //Coroutine을 사용해서 정해진 시간마다 List의 조약돌 중 한개를 랜덤으로 뽑아 활성화
    IEnumerator CreateRock(){
        yield return new WaitForSeconds(0.5f);                      // Coroutine의 While문을 0.5초 뒤에 실행
        while(GameManager.instance.mb_isPlay){                      // 게임이 진행중인 동안
            ml_RockPool[DeativRock()].SetActive(true);              // 비활성화 되어있는 오브젝트(조약돌) 활성화
            yield return new WaitForSeconds(Random.Range(1f,3f));   // 괄호 안에 숫자만큼 (1초에서 3초 사이 랜덤으로) 기다렸다가 다음 줄을 진행
        }
    }

    // 비활성화가 되어았는 오브젝트를 찾기
    int DeativRock(){
        List<int>num = new List<int>();                             //정수형 리스트 생성
        for (int i = 0; i < ml_RockPool.Count; i++){
            //비활성된 오브젝트를 찾아서
            if(!ml_RockPool[i].activeSelf){ 
                //순번을 정수형 리스트에 추가
                num.Add(i); 
            }
        }
        int x = 0;
        // 비활성된 오브젝트가 존재한다면
        if(num.Count > 0){ 
            // 정수형 리스트에서 임의의 수 한개를 골라서 반환
            x = num[Random.Range(0,num.Count)]; 
        }
        return x;
    }

    // GameObject를 반환형으로 갖는 CreateObj 메소드 생성 -> GameObject와 Transform 을 매개변수로 가짐. 
    GameObject CreateObj(GameObject obj, Transform parent){
        GameObject copy = Instantiate(obj);                          // 매개변수로 받은 GameObject를 복제
        copy.transform.SetParent(parent);                            // Transform의 자식으로 설정하고
        copy.SetActive(false);                                       // 비활성화
        return copy;                                                 // 리턴값으로 반환
    }
}