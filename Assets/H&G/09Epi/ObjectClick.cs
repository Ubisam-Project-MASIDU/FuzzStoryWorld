/*
 * - Name : CheckAnswerEpi9.class
 * - Writer : 유희수
 * - Content : 헨젤과그레텔 Epi9 - 오브젝트를 클릭하게 해서 모두 클릭하면 다음씬으로 넘어가는 스크립트
 *  
 * - HISTORY
 * 2021-08-17 : 초기 개발
 * 2021-08-23 : 코드 획일화 및 주석처리
 *
 * <Variable>
 *  mg_Hansel      헨젤 오브젝트를 연결하기 위한 변수
 *  mg_Gretel      그레텔 오브젝트를 연결하기 위한 변수 
 *  mg_Witch       마녀 오브젝트를 연결하기 위한 변수
 *  mr_CheckClickByRay  마우스가 클릭된곳을 카메라에서부터 레이저를 쏘아 감지하기 위한 Ray
 *  mrch_CheckClickObj  레이저를 쏜 곳에 있는 오브젝트를 반환
 *  mv3_ObjectPos       클릭된 오브젝트의 위치
 *  ms_ObjectName       클릭된 오브젝트의 이름
 *  mb_InitPos          플레이어들이 초기 위치에 있는지 확인하는 flag
 *  mn_count            오브젝트가 몇개 클릭됐는지 세어주는 변수
 *  mb_witchToHomeFlag  마녀가 집으로 돌아가도 되는지 확인해주는 flag
 *  ms_WitchWithcHAG    헨젤,그레텔과 같이 있는 마녀 spirte 연결
 *  
 *  mv3_PlantPos        오브젝트 위치 설정 -> Plant 연결
 *  mv3_CauldronPos     오브젝트 위치 설정 -> Cauldron 연결
 *  mv3_TreePos         오브젝트 위치 설정 -> Tree 연결
 *  mv3_LogPos          오브젝트 위치 설정 -> Log 연결
 *  mv3_StonePos        오브젝트 위치 설정 -> Stone 연결
 *  mv3_HousePos        오브젝트 위치 설정 -> House 연결
 *  mf_Speed            오브젝트가 움직일 속도 설정
 *  msc_TextFinishFlag  SceneControl 스크립트가 끝났는지 확인하는 변수를 가져오기 위함
 *  msc_Vibrate         SceneControl 클래스의 vibrate 변수를 참조하기 위함 
    
 * 
 * <Function>
 * v_SetPos()                   헨젤과 그레텔을 초기위치로 이동하게 해주는 함수
 * v_CountAnswer()              퍼즐을 맞출때마다 개수 변수를 더해주는 함수
 * v_ChangeNextScene()          다음씬으로 넘어가는 함수
 * v_WinText()                  텍스트를 활성화해주는 함수
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
    private Vector3 mv3_ObjectPos;
    private string ms_ObjectName;
    private RaycastHit mrch_CheckClickObj;
    private bool mb_InitPos;
    private int mn_count;
    private bool mb_WitchToHomeFlag = false;
    public Sprite ms_WitchWithcHAG;


    private Vector3 mv3_PlantPos = new Vector3(-4.8f, 6.1f, -4.4f);
    private Vector3 mv3_CauldronPos = new Vector3(13.3f, 11.3f, 1.7f);
    private Vector3 mv3_TreePos = new Vector3(-20f, 11.9f, -1.8f);
    private Vector3 mv3_LogPos = new Vector3(9.1f, 2.8f, -6.6f);
    private Vector3 mv3_StonePos = new Vector3(-23.9f, 1.8f, -7.9f);
    private Vector3 mv3_HousePos = new Vector3(13.6f, 3.7f, -6.9f);
    private float mf_Speed = 0.05f;


    public SceneControl msc_TextFinishFlag;
    public SceneControl msc_Vibrate;

    /*public ParticleSystem PlantParticle;
    public ParticleSystem CauldronParticle;
    public ParticleSystem TreeParticle;
    public ParticleSystem LogParticle;
    public ParticleSystem StoneParticle;
    public ParticleSystem HouseParticle;
    public int destroyParticleIndex;
    public ParticleSystem[] Particle = new ParticleSystem[6];
    [SerializeField] ParticleSystem lightParticle = null;
    */

    private SpriteRenderer[] renders = new SpriteRenderer[6];

    #region
    void Start()
    {
        msc_TextFinishFlag = GameObject.Find("GameControl").GetComponent<SceneControl>();
        msc_Vibrate = GameObject.Find("GameControl").GetComponent<SceneControl>();

        /*renders = new SpriteRenderer[6];
        Particle[0] = GameObject.FindGameObjectWithTag("Plant").GetComponent<ParticleSystem>();
        Particle[1] = GameObject.FindGameObjectWithTag("Cauldron").GetComponent<ParticleSystem>();
        Particle[2] = GameObject.FindGameObjectWithTag("Tree").GetComponent<ParticleSystem>();
        Particle[3] = GameObject.FindGameObjectWithTag("Log").GetComponent<ParticleSystem>();
        Particle[4] = GameObject.FindGameObjectWithTag("Stone").GetComponent<ParticleSystem>();
        Particle[5] = GameObject.FindGameObjectWithTag("House").GetComponent<ParticleSystem>();
        Particle[6] = GameObject.FindGameObjectWithTag("Plant").GetComponent<ParticleSystem>();
        /*renders[0] = GameObject.FindGameObjectWithTag("Plant").GetComponent<SpriteRenderer>();
        renders[1] = GameObject.FindGameObjectWithTag("Cauldron").GetComponent<SpriteRenderer>();
        renders[2] = GameObject.FindGameObjectWithTag("Tree").GetComponent<SpriteRenderer>();
        renders[3] = GameObject.FindGameObjectWithTag("Log").GetComponent<SpriteRenderer>();
        renders[4] = GameObject.FindGameObjectWithTag("Stone").GetComponent<SpriteRenderer>();
        renders[5] = GameObject.FindGameObjectWithTag("House").GetComponent<SpriteRenderer>();
        */
        //mspr_Witch = GameObject.Find("witch").GetComponent<SpriteRenderer>();
        msc_Vibrate = GameObject.Find("GameControl").GetComponent<SceneControl>();
       
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");
        mg_Witch = GameObject.Find("witch");
        // mn_count 초기화
        mn_count = 0;
        // 헨젤과 그레텔이 처음에 초기 위치에 있게 하기 위함.
        v_SetPos();

    }

    void Update()
    {
        // SceneContorl 스크립트에서 스크립트 진행이 끝났음을 알려주는 flag가 true가 되면 ObjectClick 스크립트 진행
        if (msc_TextFinishFlag.hidestartflag) {
            mg_Witch.GetComponent<MoveWitchToHAG>().enabled = false;
            // 진동애니메이션 비활성화
            msc_Vibrate.vibrate.SetActive(false);
            // 클릭한 오브젝트가 6개보다 적다면
            if (mn_count < 6) {
                // 마우스를 왼쪽버튼을 클릭했을때 true반환
                if (Input.GetMouseButtonDown(0)) {
                    // 마우스가 클릭된곳을 카메라에서부터 레이저를 쏘아 감지하기 위한 Ray
                    Ray mr_CheckClickByRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    // 레이저를 쏜 곳에 있는 오브젝트가 있다면
                    if (Physics.Raycast(mr_CheckClickByRay, out mrch_CheckClickObj)) {
                        // 오브젝트의 위치와 이름을 변수에 저장
                        mv3_ObjectPos = mrch_CheckClickObj.collider.gameObject.transform.position;
                        ms_ObjectName = mrch_CheckClickObj.collider.gameObject.name;
                        Debug.Log(ms_ObjectName);
                        // 현재 오브젝트가 아닌 다음 오브젝트를 클릭했을때, 직전에 클릭한 오브젝트를 비활성화
                        if (mn_count > 0) {
                            // 색을 어둡게해서 이미 클릭했음을 보여줌
                            renders[mn_count - 1].color = new Color(100 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                            // destroyParticleIndex = ddd(renders[count - 1].name);
                            // Destroy(Particle[destroyParticleIndex]);
                        }
                    }
                    // 클릭된 오브젝트의 이름을 매개변수로해서 헨젤과 그레텔이 오브젝트의 뒤로 숨게한다.
                    HideBehindObject(ms_ObjectName);
                    // 클릭된 오브젝트를 순서대로 배열에 저장, 각 오브젝트의 태그와 이름을 같게 설정해놓음
                    renders[mn_count] = GameObject.FindGameObjectWithTag(ms_ObjectName).GetComponent<SpriteRenderer>();
                    // 클릭횟수 증가
                    mn_count++;
                    Debug.Log(mn_count);
                }
            }
            // 오브젝트 6개가 모두 클릭됐다면 다음 씬으로 이동 
            else if (mn_count == 6) {
                Invoke("witchChange", 1.5f);
                Invoke("witchToHome", 2.5f);
                Invoke("v_ChangeNextScene", 5f);
            }

            // 마녀가 집으로 돌아가도 되는지 확인해주는 flag가 false라면 FindHAG함수 실행
            if (!mb_WitchToHomeFlag) {
                // 마녀를 헨젤과 그레텔이 있는 곳으로 가게 하기 위한 함수 실행
                FindHAG(ms_ObjectName);
            }
        }
    }

    // 헨젤과 그레텔을 초기위치로 이동하게 해주는 함수
    void v_SetPos() {
        mg_Hansel.transform.position = new Vector3(-11.16f, 5.79f, -12.83f);
        mg_Gretel.transform.position = new Vector3(-14.3f, 4.7f, -12.3f);
        mb_InitPos = true;
    }
    
    //
    void HideBehindObject(string sObjectName) {
        switch (sObjectName) {
            case "Plant":
                mg_Hansel.transform.position = new Vector3(-5.6f, 10.2f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-9.5f, 9.8f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                //ParticleAllPlay();
                break;
            case "Cauldron":
                mg_Hansel.transform.position = new Vector3(5.7f, 14f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(2.7f, 13.6f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                //ParticleAllPlay();
                break;
            case "Tree":
                mg_Hansel.transform.position = new Vector3(-11.2f, 11.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-14.6f, 11f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                //ParticleAllPlay();
                break;
            case "Log":
                mg_Hansel.transform.position = new Vector3(3.4f, 4.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-2f, 4.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 20);
                //ParticleAllPlay();
                break;
            case "Stone":
                mg_Hansel.transform.position = new Vector3(-25.9f, 8.3f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-28.4f, 7.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                //ParticleAllPlay();
                break;
            case "House":
                mg_Hansel.transform.position = new Vector3(19.8f, 16.4f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(17f, 15.4f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                //ParticleAllPlay();
                break;
            default:
                v_SetPos();
                break;
        }
        mb_InitPos = false;
    }

    void FindHAG(string objectname){
        mg_Witch.GetComponent<SpriteRenderer>().color = new Color(230 / 255f, 230 / 255f, 230 / 255f, 255 / 255f);
        for (int i = 0; i < 6; i++){
            if (objectname == "Plant"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_PlantPos, mf_Speed);
            }else if (objectname == "Cauldron"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_ObjectPos, mf_Speed);
            }else if (objectname == "Tree"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_TreePos, mf_Speed);
            }else if (objectname == "Log"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_LogPos, mf_Speed);
            }else if (objectname == "Stone"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_StonePos, mf_Speed);
            }else if (objectname == "House"){
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, mv3_HousePos, mf_Speed);
            }
        }
    }

    void witchChange()
    {
        Destroy(mg_Gretel);
        Destroy(mg_Hansel);
        mg_Witch.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        mg_Witch.transform.rotation = Quaternion.Euler(0, 0, 0);
        mg_Witch.GetComponent<SpriteRenderer>().sprite = ms_WitchWithcHAG;
        mg_Witch.gameObject.tag = "witchwithHAG";
        
    }

    void witchToHome()
    {
        mb_WitchToHomeFlag = true;
        if (mg_Witch.tag == "witchwithHAG")
        {
            mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(26f, 6.7f, -6.9f), 0.05f);
        }

    }

    /*void ParticleAllPlay()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Particle[i] != null)
            {
                Particle[i].Play();
            }
            
        }
    }

    int ddd(string objectName)
    {
        int result = 999;
        for (int i = 0; i < 6; i++)
        {

            if (objectName == Particle[i].tag)
            {
                result = i;
            }
        }
        return result; //니가 없앨 파티클 인덱스가 이거야~

    }*/

    public void v_ChangeNextScene()
    {
        SceneManager.LoadScene("1_10H&G");
    }
    /*

    void fffindHAG(string objectname, Vector3 objectpos)
    {
        for (int i = 0; i < 6; i++)
        {

            if (objectname == renders[i].tag)
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, objectpos + new Vector3(10, 0, 10), 0.07f);
            }
        }
    }
    //파티클 0~5까지 아무거나 저장해놓고 plant가 2에 있음
    //이름 같은 파티클 찾은다음에 */
}
#endregion