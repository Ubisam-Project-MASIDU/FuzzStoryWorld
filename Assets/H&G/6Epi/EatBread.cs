using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBread : MonoBehaviour
{

    public GameObject mgo_Bread1;
    public GameObject mgo_Bread2;
    private VoiceManager mvm_VoiceManager; 
    private bool mb_Check = true;
    private bool mb_playonce = false;
    public GameObject mv3_Empty;

    // Update is called once per frame
    void Start() {
        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }
    void Update()
    {
    if(mvm_VoiceManager.mb_checkSceneReady && !mb_playonce) {
        mvm_VoiceManager.playVoice(0);
        mb_playonce = true;
    }

    if(Mathf.Abs(mgo_Bread1.transform.position.x - transform.position.x) < 1.0 
            && mb_Check) {
        Invoke("destroyB1", 1f);
        mb_Check = false;
        }

    else if(Mathf.Abs(mgo_Bread2.transform.position.x - transform.position.x) < 0.7 
            && !mb_Check) {
        Invoke("destroyB2", 1f);
        Invoke("Stop",1.3f);
        }

    else {
     transform.position = Vector3.MoveTowards(transform.position, mv3_Empty.transform.position, 0.5f * Time.deltaTime);
        }

    }
    
    void Stop() {
        Time.timeScale = 0;
    }
    void destroyB1() {
        mgo_Bread1.GetComponent<SpriteRenderer>().sprite = null;      
 
    }

    void destroyB2() {
        mgo_Bread2.GetComponent<SpriteRenderer>().sprite = null;      
 
    }
}
