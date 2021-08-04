/*
 * - Name : BGMmanager.cs
 * - Writer : 최대준
 * - Content : BGMmanager 클래스에서는 이름에서와 같이 씬에 필요한 BGM 사운드를 출력하도록 설계하였다.
 * - Where the code is applied : for any scenes to need making a BGM sound...
 * - History -
 * 2021-07-23 : 제작 완료
 * 2021-07-23 : 주석 처리
 * 2021-07-27 : 피드백에 의한 주석 변경.
 *
 * - BGMmanager Member Variable 
 * 
 * null
 *
 * - BGMmanager Member Function
 *
 * Awake() : Start() 함수보다도 이전에 호출되는 함수로, 프리팹의 인스턴스화 직후에 호출된다. BGM이 겹치면 안되기에 또다른 BGMmanager 오브젝트 클래스가 존재하는지 확인후에 존재한다면 현재 이 오브젝트를 파괴하고, 존재하지 않는다면 이 오브젝트를 씬이 옮겨가면서 자동으로 파괴되지 않도록 DontDestroyOnLoad함수로 래핑해준다.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 본 클래스는 씬에 브금을 출력하는데에 목적이 있는 클래스이다.
public class BGMmanager : MonoBehaviour {
    // Start함수보다 더 빨리 호출되는 함수로, BGMmanager 클래스가 전환되는 씬에 존재한다면 해당 클래스 오브젝트는 사라지게 된다.
    void Awake() {
        var obj = FindObjectsOfType<BGMmanager>();
        if(obj != null) {
            if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
