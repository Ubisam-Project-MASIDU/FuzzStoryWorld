using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorClickEvent : MonoBehaviour
{
    public GameObject mgo_Hansel;
    public GameObject mgo_Gretel;

    public Button mbtn_Door;
    GameObject m_DoorClickBlink;

    private Rigidbody rb;
    public Text mt_DoorClickText;

    public VoiceManager mvm_VoiceManager;
    private bool mb_playOne = false;
    private bool mb_playTwo = false;


    Vector2 mv3_MousePosition;


    void Start()
    {
        mgo_Hansel = GameObject.Find("Hansel");
        mgo_Gretel = GameObject.Find("Gretel");

        mbtn_Door = transform.GetComponent<Button>();
        mbtn_Door.onClick.AddListener(fOnMouseDown);


        mt_DoorClickText = GameObject.Find("Text").GetComponent<Text>();

        mvm_VoiceManager = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();


        m_DoorClickBlink = GameObject.Find("arrow");

        m_DoorClickBlink.SetActive(false);
    }
    void Update()
    {
        if (mvm_VoiceManager.mb_checkSceneReady && !mb_playOne)
        {

            // 나레이션 한번 출력 
            mvm_VoiceManager.playVoice(0);
            mb_playOne = true;
        }

        if (mvm_VoiceManager.isPlaying() == false && mvm_VoiceManager.mb_checkSceneReady && mb_playTwo)
        {
            // 음성 출력이 끝나면 다음 씬으로 이동
            changeNextScene();

        }

    }
    void fOnMouseDown()
    {
        if (mvm_VoiceManager.isPlaying() == false)
        {
            fNarration();
            if (mgo_Gretel.transform.position.x < 9)
            {
                mgo_Gretel.transform.Translate(1, 0, 0);
                mgo_Hansel.transform.Translate(1, 0, 0);
                Debug.Log("buttonPress");

            }
            else
            {
                m_DoorClickBlink.SetActive(false);

                mt_DoorClickText.text = "\n           가난을 못 버티고 부모님은 헨젤과 그레텔을 숲속에 버리려 계획했어요.        \n";

                mvm_VoiceManager.playVoice(1);
                mb_playTwo = true;
            }
        }
    }

    void fNarration()
    {
        mt_DoorClickText.text = "\n     문을 터치해주세요        \n";

        m_DoorClickBlink.SetActive(true);
        m_DoorClickBlink.GetComponent<BlinkObject>().ChangBlinkFlagTrue();
    }

    void changeNextScene()
    {
        SceneManager.LoadScene("1_03H&G");
    }
}

