using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene12Controller : MonoBehaviour {
    private VoiceManager mvm_VoiceManager;
    private int mn_NumCharacter = 2;
    private Status mst_HAGStatus;
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

    void Start() {
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        mst_HAGStatus = new Status(20f, 2f, 10f, Status.Character.HAG);
        mst_WitchStatus = new Status(Status.Character.Witch);
        // 마녀를 무찌르세요 ! 라는 문구 0_01Straing 씬에서 VMLoader -> VMController -> KRVoiceManager, ENVoiceManager, JPVoiceManager, CNVoiceManager 각각 인스펙터창에 삽입하기
        // mvm_VoiceManager.playVoice()
    }

    void Update() {
        if (mst_HAGStatus.HP < 0) {
            // game over..
        }
        if (mst_WitchStatus.HP < 0) {
            // game clear..
        }
    }
}
