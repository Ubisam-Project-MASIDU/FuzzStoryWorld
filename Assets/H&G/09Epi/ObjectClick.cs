/*
 * - Name : CheckAnswerEpi9.class
 * - Writer : 유희수, 이병권
 * - Content : 헨젤과그레텔 Epi9 - 오브젝트를 클릭하게 해서 모두 클릭하면 다음씬으로 넘어가는 스크립트
 *                                  1) 케릭터가 움직이면 소리가 나게 한다
 *                                  2) 마녀에게 잡혔을 때 소리나게 한다                       
 *
 * - HISTORY
 * 1) 2021-08-17 : 초기 개발
 * 2) 2021-08-23 : 코드 획일화 및 주석처리
 *
 * <Variable>
 *  mg_Hansel                                     헨젤 오브젝트를 연결하기 위한 변수
 *  mg_Gretel                                     그레텔 오브젝트를 연결하기 위한 변수 
 *  mg_Witch                                      마녀 오브젝트를 연결하기 위한 변수
 *  mr_CheckClickByRay                            마우스가 클릭된곳을 카메라에서부터 레이저를 쏘아 감지하기 위한 Ray
 *  mrch_CheckClickObj                            레이저를 쏜 곳에 있는 오브젝트를 반환
 *  mv3_ObjectPos                                 클릭된 오브젝트의 위치
 *  ms_ObjectName                                 클릭된 오브젝트의 이름
 *  mb_InitPos                                    플레이어들이 초기 위치에 있는지 확인하는 flag
 *  mn_count                                      오브젝트가 몇개 클릭됐는지 세어주는 변수
 *  mb_witchToHomeFlag                            마녀가 집으로 돌아가도 되는지 확인해주는 flag
 *  ms_WitchWithcHAG                              헨젤,그레텔과 같이 있는 마녀 spirte 연결
 *  mspra_ClickObject                             클릭한 오브젝트를 저장하는 배열
 *  mv3_PlantPos                                  오브젝트 위치 설정 -> Plant 연결
 *  mv3_CauldronPos                               오브젝트 위치 설정 -> Cauldron 연결
 *  mv3_TreePos                                   오브젝트 위치 설정 -> Tree 연결
 *  mv3_LogPos                                    오브젝트 위치 설정 -> Log 연결
 *  mv3_StonePos                                  오브젝트 위치 설정 -> Stone 연결
 *  mv3_HousePos                                  오브젝트 위치 설정 -> House 연결
 *  mf_Speed                                      오브젝트가 움직일 속도 설정
 *  msc_TextFinishFlag                            SceneControl 스크립트가 끝났는지 확인하는 변수를 가져오기 위함
 *  msc_Vibrate                                   SceneControl 클래스의 vibrate 변수를 참조하기 위함  
 * 
 * <Function>
 * v_SetPos()                                      헨젤과 그레텔을 초기위치로 이동하게 해주는 함수
 * v_FindHAG()                                     숨어있는 헨젤과 그레텔을 마녀가 찾아 따라가게 하는 함수
 * v_HideBehindObject()                            헨젤과 그레텔을 오브젝트의 뒤로 이동하게 해주는 함수
 * v_WitchChange()                                 헨젤과 그레텔을 데리고 집으로 돌아가는 마녀의 Sprite로 바꿔주는 함수
 * v_WitchToHome()                                 마녀가 헨젤과 그레텔을 집으로 데려가는 함수
 * v_ChangeNextScene()                             다음씬으로 넘어가는 함수
 * v_WinText()                                     텍스트를 활성화해주는 함수
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectClick : MonoBehaviour {

    // 오브젝트 연결
    private GameObject mg_Hansel;
    private GameObject mg_Gretel;
    private GameObject mg_Witch;
    private GameObject mg_Plant;
    private GameObject mg_Cauldron;
    private GameObject mg_Tree;
    private GameObject mg_Log;
    private GameObject mg_Stone;
    private GameObject mg_House;
    private GameObject mg_Tree2;
    private GameObject mg_Caulron2;

    // 오브젝트의 위치를 저장하는 변수
    private Vector3 mv3_ObjectPos;
    // 오브젝트의 이름을 저장하는 변수
    private string ms_ObjectName;
    // 레이저를 쏜 곳에 있는 오브젝트를 반환
    private RaycastHit mrch_CheckClickObj;
    // 초기 위치에 있는지 알려주는 flag
    private bool mb_InitPos;
    // 클릭된 오브젝트의 개수를 세는 변수
    private int mn_count;
    // 마녀가 집으로 돌아가도 되는지 확인해주는 flag
    private bool mb_WitchToHomeFlag = false;
    // 헨젤,그레텔과 같이 있는 마녀 spirte 연결
    public Sprite ms_WitchWithcHAG;
    // 클릭한 오브젝트를 저장하는 배열
    private SpriteRenderer[] mspra_ClickObject = new SpriteRenderer[6];

    // 오브젝트 위치 설정
    private Vector3 mv3_PlantPos = new Vector3(-4.8f, 6.1f, -4.4f);
    private Vector3 mv3_CauldronPos = new Vector3(13.3f, 11.3f, 1.7f);
    private Vector3 mv3_TreePos = new Vector3(-20f, 11.9f, -1.8f);
    private Vector3 mv3_LogPos = new Vector3(9.1f, 2.8f, -6.6f);
    private Vector3 mv3_StonePos = new Vector3(-23.9f, 1.8f, -7.9f);
    private Vector3 mv3_HousePos = new Vector3(13.6f, 3.7f, -6.9f);
    private float mf_Speed = 0.05f;

    // SceneControl 스크립트 변수
    private SceneControl msc_TextFinishFlag;
    public SceneControl msc_Vibrate;

    GameObject mg_SoundManager;

    void Start(){
        // 오브젝트 연결
        mg_Plant = GameObject.Find("Plant");
        mg_Cauldron = GameObject.Find("Cauldron");
        mg_Tree = GameObject.Find("Tree");
        mg_Log = GameObject.Find("Log");
        mg_Stone = GameObject.Find("Stone");
        mg_House = GameObject.Find("House");
        mg_Tree2 = GameObject.Find("Tree2");
        mg_Caulron2 = GameObject.Find("Cauldron2");
        msc_TextFinishFlag = GameObject.Find("GameControl").GetComponent<SceneControl>();
        msc_Vibrate = GameObject.Find("GameControl").GetComponent<SceneControl>();
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");
        mg_Witch = GameObject.Find("witch");
        // mn_count 초기화
        mn_count = 0;
        // 사운드 매니저 게임오브젝트 연결
        mg_SoundManager = GameObject.Find("SoundManager");
        // 헨젤과 그레텔이 처음에 초기 위치에 있게 하기 위함.
        v_SetPos();
    }

    void Update(){
        // SceneContorl 스크립트에서 스크립트 진행이 끝났음을 알려주는 flag가 true가 되면 ObjectClick 스크립트 진행
        if (msc_TextFinishFlag.mb_ObjClickStart) {
            mg_Witch.GetComponent<MoveWitchToHAG>().enabled = false;
            // 진동애니메이션 비활성화
            msc_Vibrate.mg_VibrateAni.SetActive(false);
            // 만약 게임 스킵모드일 경우 미니게임 건너뛰기
            if(PlayerPrefs.GetInt("SkipGame") == 1){
                mn_count = 6;
            }
            // 클릭한 오브젝트가 6개보다 적다면
            if (mn_count < 6) {
                // 마우스를 왼쪽버튼을 클릭했을때 true반환
                if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        // 마우스가 클릭된곳을 카메라에서부터 레이저를 쏘아 감지하기 위한 Ray
                        Ray mr_CheckClickByRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                        // 레이저를 쏜 곳에 있는 오브젝트가 있다면
                        if (Physics.Raycast(mr_CheckClickByRay, out mrch_CheckClickObj))
                        {
                            // 오브젝트의 위치와 이름을 변수에 저장
                            mv3_ObjectPos = mrch_CheckClickObj.collider.gameObject.transform.position;
                            ms_ObjectName = mrch_CheckClickObj.collider.gameObject.name;
                            Debug.Log(ms_ObjectName);
                            // 현재 오브젝트가 아닌 다음 오브젝트를 클릭했을때, 직전에 클릭한 오브젝트를 비활성화
                            if (mn_count > 0)
                            {
                                // 색을 어둡게해서 이미 클릭했음을 보여줌
                                mspra_ClickObject[mn_count - 1].color = new Color(100 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                                if (mspra_ClickObject[mn_count - 1].tag == "Tree")
                                {
                                    mg_Tree2.GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                                }
                                if (mspra_ClickObject[mn_count - 1].tag == "Cauldron")
                                {
                                    mg_Caulron2.GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                                }
                                // destroyParticleIndex = ddd(renders[count - 1].name);
                                // Destroy(Particle[destroyParticleIndex]);
                            }
                            // 클릭된 오브젝트의 이름을 매개변수로해서 헨젤과 그레텔이 오브젝트의 뒤로 숨게한다.
                            v_HideBehindObject(ms_ObjectName);
                            // 클릭된 오브젝트를 순서대로 배열에 저장, 각 오브젝트의 태그와 이름을 같게 설정해놓음
                            mspra_ClickObject[mn_count] = GameObject.FindGameObjectWithTag(ms_ObjectName).GetComponent<SpriteRenderer>();
                            // 클릭횟수 증가
                            mn_count++;
                            Debug.Log(mn_count);
                        }
                        
                    }
                }
                
            }
            // 오브젝트 6개가 모두 클릭됐다면 다음 씬으로 이동 
            else if (mn_count == 6) {
                Invoke("v_WithcChange", 1.5f);
                Invoke("v_WithcToHome", 2.5f);
                Invoke("v_ChangeNextScene", 5f);
            }
            else
            {
                mn_count = 6;
            }

            // 마녀가 집으로 돌아가도 되는지 확인해주는 flag가 false라면 FindHAG함수 실행
            if (!mb_WitchToHomeFlag) {
                // 마녀를 헨젤과 그레텔이 있는 곳으로 가게 하기 위한 함수 실행
                v_FindHAG(ms_ObjectName);
            }
        }
    }

    // 헨젤과 그레텔을 초기위치로 이동하게 해주는 함수
    void v_SetPos() {
        mg_Hansel.transform.position = new Vector3(-11.16f, 5.79f, -12.83f);
        mg_Gretel.transform.position = new Vector3(-14.3f, 4.7f, -12.3f);
        mb_InitPos = true;
    }
    
    
    // 헨젤과 그레텔을 오브젝트의 뒤로 이동하게 해주는 함수
    // 클릭한 오브젝트의 이름을 매개변수로 받아 switch문 이용
    void v_HideBehindObject(string sObjectName) {
        switch (sObjectName) {
            // 오브젝트의 이름이 "Plant" 라면 Plant 오브젝트뒤에 위치시킨다.
            case "Plant":
                mg_Hansel.transform.position = new Vector3(-5.6f, 10.2f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-9.5f, 9.8f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다                
                //ParticleAllPlay();
                break;
            // 오브젝트의 이름이 "Cauldron" 라면 Cauldron 오브젝트뒤에 위치시킨다.
            case "Cauldron":
                mg_Hansel.transform.position = new Vector3(5.7f, 14f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(2.7f, 13.6f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다
                //ParticleAllPlay();
                break;
            // 오브젝트의 이름이 "Tree" 라면 Tree 오브젝트뒤에 위치시킨다.
            case "Tree":
                mg_Hansel.transform.position = new Vector3(-11.2f, 11.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-14.6f, 11f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다
                //ParticleAllPlay();
                break;
            // 오브젝트의 이름이 "Log" 라면 Log 오브젝트뒤에 위치시킨다.
            case "Log":
                mg_Hansel.transform.position = new Vector3(3.4f, 4.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-2f, 4.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 20);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다
                //ParticleAllPlay();
                break;
            // 오브젝트의 이름이 "Stone" 라면 Stone 오브젝트뒤에 위치시킨다.
            case "Stone":
                mg_Hansel.transform.position = new Vector3(-25.9f, 8.3f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-28.4f, 7.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다
                //ParticleAllPlay();
                break;
            // 오브젝트의 이름이 "House" 라면 House 오브젝트뒤에 위치시킨다.
            case "House":
                mg_Hansel.transform.position = new Vector3(19.8f, 16.4f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(17f, 15.4f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                mg_SoundManager.GetComponent<SoundManager>().playSound("Hide");   // 애들이 숨었을 때 소리나게 한다
                //ParticleAllPlay();
                break;
            // 초기위치로 이동
            default:
                v_SetPos();
                break;
        }
        mb_InitPos = false;
    }
    
    // 숨어있는 헨젤과 그레텔을 마녀가 찾아 따라가게 하는 함수
    // 클릭한 오브젝트를 매개변수로 받아 if문으로 마녀를 클릭한 오브젝트로 이동시킴
    void v_FindHAG(string sObjectName){
        mg_Witch.GetComponent<SpriteRenderer>().color = new Color(230 / 255f, 230 / 255f, 230 / 255f, 255 / 255f);
        for (int i = 0; i < 6; i++){
            if (sObjectName == "Plant"){
                //
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_PlantPos, mf_Speed);
            }else if (sObjectName == "Cauldron"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_ObjectPos, mf_Speed);
            }else if (sObjectName == "Tree"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_TreePos, mf_Speed);
            }else if (sObjectName == "Log"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_LogPos, mf_Speed);
            }else if (sObjectName == "Stone"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_StonePos, mf_Speed);
            }else if (sObjectName == "House"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_HousePos, mf_Speed);
            }
        }
    }

    // 헨젤과 그레텔을 데리고 집으로 돌아가는 마녀의 Sprite로 바꿔주는 함수
    void v_WithcChange(){
        // 헨젤과 그레텔 오브젝트를 삭제해준다.
        Destroy(mg_Gretel);
        Destroy(mg_Hansel);
        // 오브젝트의 크기, 위치 등을 조정하고 마녀의 Sprite를 다른 그림으로 바꾼다.
        mg_Witch.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        mg_Witch.transform.rotation = Quaternion.Euler(0, 0, 0);
        mg_Witch.GetComponent<SpriteRenderer>().sprite = ms_WitchWithcHAG;
        // 바뀐 마녀의 모습을 확인하기 위해 tag를 바꿔준다.
        mg_Witch.gameObject.tag = "witchwithHAG";
    }

    // 마녀가 헨젤과 그레텔을 집으로 데려가는 함수
    void v_WithcToHome(){
        // 집으로 데려가도 되는지 표시하는 flag를 true로 바꿔준다.
        mb_WitchToHomeFlag = true;
        // 마녀가 집으로 돌아가도 되는지 조건 검사
        if (mg_Witch.tag == "witchwithHAG"){
            mg_SoundManager.GetComponent<SoundManager>().playSound("Catch");   // 마녀가 아이들을 잡았을 때 소리나게 한다
            // 헨젤과 그레텔을 집으로 데려가는 모습의 마녀로 바뀌었다면, 마녀를 집으로 이동시킨다.
            mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(35f, 6.7f, -6.9f), 0.05f);
        }
    }

    //다음 씬으로 이동시켜주는 함수
    public void v_ChangeNextScene(){
        SceneManager.LoadScene("1_10H&G");
    }
 }