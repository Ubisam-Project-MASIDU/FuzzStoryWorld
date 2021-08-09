using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeNextScene : MonoBehaviour {
    private bool mb_CheckOncePlaying = true;
    private VoiceManager mvm_PlayVoiceManager;
    // Start is called before the first frame update
    void Start()
    {
        mvm_PlayVoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mvm_PlayVoiceManager.mb_checkSceneReady && mb_CheckOncePlaying) {
            mvm_PlayVoiceManager.playVoice(0);
            mb_CheckOncePlaying = false;
        }
    }
    void OnTriggerEnter(Collider cCollider) {
        if (cCollider.tag == "HAG")
            Invoke("changeNextScene", 1f);
    }

    void changeNextScene() {
        SceneManager.LoadScene("1_08H&G");
    }
}
