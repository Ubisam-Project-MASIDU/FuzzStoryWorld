using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeController : MonoBehaviour
{

    public GameObject mgo_Bird;
    public GameObject mgo_BirdPrefab;
    public GameObject mgo_HAG;

    private bool mb_CheckScenarioFirst = false;
    private bool mb_CheckScenarioFirstOnce = false;
    private bool mb_CheckScenarioSecondOnce = false;

    private bool mb_CheckScenarioSecond = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mgo_Bird != null) {
            if(mgo_Bird.transform.position.x > -4.2 && !mb_CheckScenarioFirst && !mb_CheckScenarioFirstOnce) {
                scenarioFirst();
                mb_CheckScenarioFirst = true;
            }
            else if (mgo_HAG.transform.position.x > -4.8 && mb_CheckScenarioFirst && !mb_CheckScenarioFirstOnce) {
                reStruct();
                mb_CheckScenarioFirstOnce = true;
            }
            else if(mgo_Bird.transform.position.x > 1&& !mb_CheckScenarioSecond && !mb_CheckScenarioSecondOnce) {
                scenarioSecond();
                mb_CheckScenarioSecond = true;
            }
            else if (mgo_HAG.transform.position.x > 0 && mb_CheckScenarioSecond && !mb_CheckScenarioSecondOnce) {
                reStruct();
                mb_CheckScenarioSecondOnce = true;
            }
        }
        
    }

    void scenarioFirst() {
        Destroy(mgo_Bird);
        mgo_Bird = transform.GetChild(0).gameObject;
        mgo_Bird.SetActive(true);
    }

    void scenarioSecond() {
        Destroy(mgo_Bird);
        mgo_Bird = transform.GetChild(0).gameObject;
        mgo_Bird.SetActive(true);
    }

    void reStruct() {
        Transform temp = mgo_Bird.transform;
        Destroy(mgo_Bird);
        mgo_Bird = Instantiate(mgo_BirdPrefab, temp.position, mgo_BirdPrefab.transform.rotation);
    }
}
