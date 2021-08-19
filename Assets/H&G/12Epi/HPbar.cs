using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
  [SerializeField]
    private Slider hpbar;
    public GameObject mgo_CheckGameObject;
    public GameObject mgo_GameController;
    private Status mst_HAGStatus;
    private float maxHp = 100; //최대 체력
    private float curHp = 100; // 현재 체력
    void Start()
    {
        mgo_GameController = GameObject.Find("GameController");
        if (mgo_CheckGameObject.name == "HAG") {
            maxHp = mgo_GameController.GetComponent<Scene12Controller>().HAGStatus.HP;
            curHp = mgo_GameController.GetComponent<Scene12Controller>().HAGStatus.HP;
        } else if (mgo_CheckGameObject.name == "witch") {
            maxHp = mgo_GameController.GetComponent<Scene12Controller>().WitchStatus.HP;
            curHp = mgo_GameController.GetComponent<Scene12Controller>().WitchStatus.HP;
        }

        hpbar.value = (float) curHp / (float) maxHp;
    }
    void Update()
    {
        if (mgo_CheckGameObject.name == "HAG") {
            curHp = mgo_GameController.GetComponent<Scene12Controller>().HAGStatus.HP;
        } else if (mgo_CheckGameObject.name == "witch") {
            curHp = mgo_GameController.GetComponent<Scene12Controller>().WitchStatus.HP;
        }
        hpbar.value = (float) curHp / (float) maxHp;
        // if (Input.GetKeyDown(KeyCode.Space)) {
        //     curHp -= 10; 
        // }
        // HandleHp();
    }
    // private void HandleHp() {
    //     hpbar.value = (float) curHp / (float) maxHp;
    // }
}
