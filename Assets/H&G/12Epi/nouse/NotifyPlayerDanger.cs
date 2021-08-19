using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyPlayerDanger : MonoBehaviour
{
    private ParticleSystem mps_WaitEffect;
    private GameObject mgo_NotifyPlayerBox;

    void Start() {
        mps_WaitEffect = GetComponent<ParticleSystem>();
        mps_WaitEffect.Stop(true);
        mgo_NotifyPlayerBox = transform.GetChild(0).gameObject;
        Invoke("StartAttack", 2f);
    }

    void StartAttack() {
        mgo_NotifyPlayerBox.GetComponent<MeshRenderer>().enabled = false;
        mps_WaitEffect.Play(true);

        Invoke("StopAttack", 1f);
    }

    void StopAttack() {
        Destroy(this);
    }
}
