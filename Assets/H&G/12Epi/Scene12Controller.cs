using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene12Controller : MonoBehaviour {

    private enum GameResult {
        Win,
        Over
    }
    private VoiceManager mvm_VoiceManager;
    [SerializeField]
    private GameObject mgo_WinHAGPos;
    public GameObject mgo_Script;
    private SpriteRenderer mspr_SetBrightness;
    // private int mn_NumCharacter = 2;
    private Status mst_HAGStatus;
    public float HAGHP {
        set {
            mst_HAGStatus.HP = value;
            if (mst_HAGStatus.HP <= 0f) {
                DisplayUI(GameResult.Over);
                WitchTakeOnHAG();
            }
        }
        get {
            return mst_HAGStatus.HP;
        }
    }
    public Status HAGStatus {
        get {
            return mst_HAGStatus;
        }
    }
    private Status mst_WitchStatus;
    public Status WitchStatus {
        get {
            return mst_WitchStatus;
        }
    }
    public float WitchHP {
        set {
            mst_WitchStatus.HP = value;
            if (mst_WitchStatus.HP <= 0f) {
                DisplayUI(GameResult.Win);
                HAGMoveRewardStage();       //error
            }
        }
        get {
            return mst_WitchStatus.HP;
        }
    }
    void Awake() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mst_HAGStatus = new Status(20f, 2f, 10f, Status.Character.HAG);
        mst_WitchStatus = new Status(Status.Character.Witch);
        mspr_SetBrightness = GameObject.Find("Bright").GetComponent<SpriteRenderer>();
        // 마녀를 무찌르세요 ! 라는 문구 0_01Straing 씬에서 VMLoader -> VMController -> KRVoiceManager, ENVoiceManager, JPVoiceManager, CNVoiceManager 각각 인스펙터창에 삽입하기
        mvm_VoiceManager.playVoice(20);
    }
    


    void DisplayUI(GameResult grResult) {
        GameObject go_UI = GameObject.Find("UI");

        if (grResult == GameResult.Over) {
            go_UI.transform.GetChild(0).gameObject.SetActive(false);
            go_UI.transform.GetChild(1).gameObject.SetActive(false);
            go_UI.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(SetWinBright());
        } else {
            go_UI.transform.GetChild(0).gameObject.SetActive(false);
            go_UI.transform.GetChild(1).gameObject.SetActive(false);
            go_UI.transform.GetChild(3).gameObject.SetActive(true);
            Invoke("DestroyUI", 1.2f);
            StartCoroutine(SetOverBright());
        }
    }
    IEnumerator SetWinBright() {
        Color c_TempColor = mspr_SetBrightness.color;

        for (int i = 100; i >= 0; i--) {
            if (c_TempColor.a <= 0.2f) {
                c_TempColor.a += Time.deltaTime * 0.8f;               //이미지 알파 값을 타임 델타 값 * 0.01
            }
            mspr_SetBrightness.color = c_TempColor;
            yield return null;
        }
    } 
    IEnumerator SetOverBright() {
        Color c_TempColor = mspr_SetBrightness.color;

        for (int i = 100; i >= 0; i--) {
            if (c_TempColor.a <= 0.2f) {
                c_TempColor.a += Time.deltaTime * 0.8f;               //이미지 알파 값을 타임 델타 값 * 0.01
            }
            mspr_SetBrightness.color = c_TempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        for (int i = 100; i >= 0; i--) {
            if (c_TempColor.a >= 0f) {
                c_TempColor.a -= Time.deltaTime * 0.8f;               //이미지 알파 값을 타임 델타 값 * 0.01
            }
            mspr_SetBrightness.color = c_TempColor;
            yield return null;
        }
        //transform.GetChild(1).transform.GetChild(5).gameObject.SetActive(false);
    } 

    void WitchTakeOnHAG() {
        GameObject go_Witch = GameObject.Find("witch");
        go_Witch.transform.position = GameObject.Find("HAG").transform.position + new Vector3(0, 4, 0);
        go_Witch.GetComponent<WitchAttack>().mgo_HAG = null;     
        transform.GetChild(1).transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(1).transform.GetChild(4).transform.position = go_Witch.transform.position;  
        go_Witch.SetActive(false);

        Destroy(GameObject.Find("HAG"));
    }

    void HAGMoveRewardStage() {
        Destroy(GameObject.Find("witch"));
        Destroy(GameObject.Find("HAG"));
        transform.GetChild(1).transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(1).transform.GetChild(5).transform.position = GameObject.Find("HAG").transform.position;  
        GameObject.Find("MainCamera").transform.parent = transform.GetChild(1).transform.GetChild(5).transform;
        GameObject.Find("MainCamera").transform.localPosition = new Vector3(1.69f, 10.6f, -24.15f);
        GameObject.Find("MainCamera").transform.localEulerAngles = new Vector3(7.272f, 0f, 0f);
        GameObject.Find("EndHAG").GetComponent<HAGMove>().mv3_TargetPos = mgo_WinHAGPos.transform.position;
        GameObject.Find("EndHAG").GetComponent<HAGMove>().mb_SetPos = true;
        GameObject.Find("EndHAG").GetComponent<HAGMove>().mb_SetWinWalk = true;
        
    }
    
    void DestroyUI() {
        GameObject go_UI = GameObject.Find("UI");
        go_UI.transform.GetChild(3).gameObject.SetActive(false);
    }
    
    void CreateUI() {
        GameObject go_UI = GameObject.Find("UI");
        go_UI.transform.GetChild(5).gameObject.SetActive(true);
    }
    void Update() {
       if(mvm_VoiceManager.isPlaying() == false) {
            mgo_Script.SetActive(false);
          }  
    }
}
