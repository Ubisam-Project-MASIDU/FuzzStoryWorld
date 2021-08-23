using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyPlayerDanger : MonoBehaviour {
    private GameObject mps_WaitEffect;
    private GameObject mgo_NotifyPlayerBox;
    private Status mst_HAGStatus;
    private Status mst_WitchStatus;
    private Scene12Controller msc_SceneController;
    private int mn_WitchMagicDamage = 3;
    void Start() {
        transform.GetChild(0).gameObject.SetActive(false);
        msc_SceneController = GameObject.Find("GameController").GetComponent<Scene12Controller>();
        mgo_NotifyPlayerBox = transform.GetChild(0).gameObject;
        Invoke("StartAttack", 2f);
    }

    void StartAttack() {
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<SphereCollider>().enabled = true;
        Invoke("StopAttack", 1f);
    }

    void StopAttack() {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider cOtherCollider) {
        if (cOtherCollider.name == "HAG") {
            HAGMove hm_CheckDamaging = GameObject.Find("HAG").GetComponent<HAGMove>();
            if (!hm_CheckDamaging.DamagingHAG) {
                GameObject.Find("HAG").GetComponent<HAGMove>().HAGHit();
                msc_SceneController.HAGHP -= msc_SceneController.WitchStatus.AttackDamage * mn_WitchMagicDamage;
            }
        }
    }
}