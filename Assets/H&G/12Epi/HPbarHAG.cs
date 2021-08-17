using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarHAG : MonoBehaviour
{
  [SerializeField]
    private Slider hpbar;
    public GameObject mgo_HAG;
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
    }
    private void HandleHp() {
        hpbar.value = (float) curHp / (float) maxHp;
    }
}
