using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarWitch : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    public GameObject mgo_witch;
    private float maxHp = 100; //최대 체력
    private float curHp = 100; // 현재 체력
    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            curHp -= 10; 
        }
        HandleHp();
        if (curHp <= 0) {
            Destroy(mgo_witch.gameObject);
        }
    }
    private void HandleHp() {
        hpbar.value = (float) curHp / (float) maxHp;
    }
}
