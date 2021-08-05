using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVoice : MonoBehaviour
{
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
        if (!mvm_PlayVoiceManager.isPlaying() && mvm_PlayVoiceManager.mb_checkSceneReady) {
            Invoke("nextSceneLoad", 2f);
        }
    }
    void nextSceneLoad() {
        SceneManager.LoadScene("1_02H&G");
    }
}
