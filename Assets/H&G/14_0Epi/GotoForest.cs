using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoForest : MonoBehaviour
{
    //public Camera MainCamera;
    private GameObject Hansel;
    private GameObject Gretel;
    private GameObject Witch;
    private VoiceManager mvm_VoiceManager;
    private bool playFirstVoice = false;
    private Vector3 HanselPos = new Vector3(90, -4f, -6);
    private Vector3 GretelPos = new Vector3(88, -4f, -6);

    // Start is called before the first frame update
    void Start()
    {
        Hansel = GameObject.Find("hansel");
        Gretel = GameObject.Find("gretel");
        Witch = GameObject.Find("witch");
        mvm_VoiceManager = FindObjectOfType<VoiceManager>();
        if (!playFirstVoice)
        {
            mvm_VoiceManager.playVoice(22);
            playFirstVoice = true;
        }
        
    }
    void Update()
    {
        Hansel.transform.position = Vector3.MoveTowards(Hansel.transform.position, HanselPos, 0.04f);
        Gretel.transform.position = Vector3.MoveTowards(Gretel.transform.position, GretelPos, 0.04f);
        Witch.transform.position = Vector3.MoveTowards(Witch.transform.position, new Vector3(15, -2.47f, 0), 0.02f);

        if(Hansel.transform.position == HanselPos && playFirstVoice && mvm_VoiceManager.isPlaying() == false)
        {
            Invoke("v_ChangeNextScene", 1f);
        }
    }
    public void v_ChangeNextScene()
    {
        SceneManager.LoadScene("1_14H&G");
    }
}
