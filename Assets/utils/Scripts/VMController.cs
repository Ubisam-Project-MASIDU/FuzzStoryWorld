using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMController : MonoBehaviour {

    public enum Country {
        KR,
        EN,
        JP,
        CN
    }

    public int mn_LanguageLength = 4;
    private int mn_CurrentVMIdx = 0;
    public bool mb_checkSceneReady = false;
    public bool mb_CheckLanguageReady = false;
    private GameObject mgo_loadingScene;
    public GameObject mc_loadingScene;
    private Country mct_CheckCountry = Country.KR;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        mgo_loadingScene = Instantiate(mc_loadingScene);
        mgo_loadingScene.SetActive(true);
    }
    
    void Update() {
        if (mn_CurrentVMIdx >= mn_LanguageLength && !mb_checkSceneReady) {
            mb_checkSceneReady = true;
            mgo_loadingScene.SetActive(false);
            return;
        }
        if (!mb_CheckLanguageReady) {
            for (int i = 0; i < mn_LanguageLength; i++) {
                if (i != (int)mct_CheckCountry) {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            mb_CheckLanguageReady = true;
        }        
        if (mn_CurrentVMIdx < mn_LanguageLength) {
            GameObject go_GetChild = transform.GetChild(mn_CurrentVMIdx).gameObject;

            if (!go_GetChild.activeSelf) {
                go_GetChild.SetActive(true);
            } else if (go_GetChild.GetComponent<VoiceManager>().mb_checkSceneReady) {
                mn_CurrentVMIdx++;
            }
        }
    }

    public void SetCountry(Country ctStrCountry) {
        mct_CheckCountry = ctStrCountry;
        mb_CheckLanguageReady = true;
    }
}
