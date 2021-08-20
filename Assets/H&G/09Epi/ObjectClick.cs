using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public GameObject mg_Hansel;
    public GameObject mg_Gretel;
    private GameObject mg_Witch;
    private Vector3 mv3_ObjectPos;
    private string ms_ObjectName;
    private RaycastHit hit;
    private bool mb_InitPos;
    private int count;
    private bool witchToHomeFlag = false;

    private Vector3 plantPos = new Vector3(-4.8f, 6.1f, -4.4f);
    private Vector3 cauldronPos = new Vector3(13.3f, 11.3f, 1.7f);
    private Vector3 treePos = new Vector3(-20f, 11.9f, -1.8f);
    private Vector3 logPos = new Vector3(9.1f, 2.8f, -6.6f);
    private Vector3 stonePos = new Vector3(-23.9f, 1.8f, -7.9f);
    private Vector3 housePos = new Vector3(13.6f, 3.7f, -6.9f);
    private float speed = 0.05f;

    public SceneControl sc;
    public SceneControl vib;

    public ParticleSystem PlantParticle;
    public ParticleSystem CauldronParticle;
    public ParticleSystem TreeParticle;
    public ParticleSystem LogParticle;
    public ParticleSystem StoneParticle;
    public ParticleSystem HouseParticle;
    public int destroyParticleIndex;
    public ParticleSystem[] Particle = new ParticleSystem[6];
    [SerializeField] ParticleSystem lightParticle = null;

    private SpriteRenderer[] renders;
    private SpriteRenderer witch;
    public Sprite witchwithHAG;

    void Start()
    {
        sc = GameObject.Find("GameControl").GetComponent<SceneControl>();
        vib = GameObject.Find("GameControl").GetComponent<SceneControl>();

        renders = new SpriteRenderer[6];
        /*renders[0] = GameObject.FindGameObjectWithTag("Plant").GetComponent<SpriteRenderer>();
        renders[1] = GameObject.FindGameObjectWithTag("Cauldron").GetComponent<SpriteRenderer>();
        renders[2] = GameObject.FindGameObjectWithTag("Tree").GetComponent<SpriteRenderer>();
        renders[3] = GameObject.FindGameObjectWithTag("Log").GetComponent<SpriteRenderer>();
        renders[4] = GameObject.FindGameObjectWithTag("Stone").GetComponent<SpriteRenderer>();
        renders[5] = GameObject.FindGameObjectWithTag("House").GetComponent<SpriteRenderer>();
        */
        witch = GameObject.Find("witch").GetComponent<SpriteRenderer>();

        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");
        mg_Witch = GameObject.Find("witch");

        
        count = 0;
        setPos();

        //mg_Witch.GetComponent<MoveWitchToHAG>().enabled = false;
    }

    void Update()
    {

        if (sc.hidestartflag)
        {
            mg_Witch.GetComponent<MoveWitchToHAG>().enabled = false;
            vib.vibrate.SetActive(false);
            if (count < 6)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        mv3_ObjectPos = hit.collider.gameObject.transform.position;
                        ms_ObjectName = hit.collider.gameObject.name;
                        Debug.Log(ms_ObjectName);
                        if (count > 0)
                        {
                            renders[count - 1].color = new Color(100 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);

                            //destroyParticleIndex = ddd(renders[count - 1].name);
                            //Destroy(Particle[destroyParticleIndex]);
                        }
                    }
                    HideBehindObject(ms_ObjectName);
                    renders[count] = GameObject.FindGameObjectWithTag(ms_ObjectName).GetComponent<SpriteRenderer>();

                    count++;
                    Debug.Log(count);
                }
            }
            else if (count == 6)
            {
                Invoke("witchChange", 1.5f);
                Invoke("witchToHome", 2.5f);
            }

            if (!witchToHomeFlag)
            {
                findHAG(ms_ObjectName);
            }
            //findHAG(ms_ObjectName);
        }
    }
    void setPos()
    {
        mg_Hansel.transform.position = new Vector3(-11.16f, 5.79f, -12.83f);
        mg_Gretel.transform.position = new Vector3(-14.3f, 4.7f, -12.3f);
        mb_InitPos = true;
    }

    void HideBehindObject(string sObjectName)
    {
        switch (sObjectName)
        {
            case "Plant":
                mg_Hansel.transform.position = new Vector3(-5.6f, 10.2f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-9.5f, 9.8f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                ParticleAllPlay();
                break;
            case "Cauldron":
                mg_Hansel.transform.position = new Vector3(5.7f, 14f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(2.7f, 13.6f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                ParticleAllPlay();
                break;
            case "Tree":
                mg_Hansel.transform.position = new Vector3(-11.2f, 11.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-14.6f, 11f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                ParticleAllPlay();
                break;
            case "Log":
                mg_Hansel.transform.position = new Vector3(3.4f, 4.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-2f, 4.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 20);
                ParticleAllPlay();
                break;
            case "Stone":
                mg_Hansel.transform.position = new Vector3(-25.9f, 8.3f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-28.4f, 7.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                ParticleAllPlay();
                break;
            case "House":
                mg_Hansel.transform.position = new Vector3(19.8f, 16.4f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(17f, 15.4f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                ParticleAllPlay();
                break;
            default:
                setPos();
                break;
        }

        mb_InitPos = false;
    }

    void findHAG(string objectname)
    {
        witch.color = new Color(230 / 255f, 230 / 255f, 230 / 255f, 255 / 255f);
        for (int i = 0; i < 6; i++)
        {
            if (objectname == "Plant")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, plantPos, speed);
            }
            else if (objectname == "Cauldron")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, cauldronPos, speed);
            }
            else if (objectname == "Tree")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, treePos, speed);
            }
            else if (objectname == "Log")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, logPos, speed);
            }
            else if (objectname == "Stone")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, stonePos, speed);
            }
            else if (objectname == "House")
            {
                mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, housePos, speed);
            }
        }
    }

    void witchChange()
    {
        Destroy(mg_Gretel);
        Destroy(mg_Hansel);
        mg_Witch.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        mg_Witch.transform.rotation = Quaternion.Euler(0, 0, 0);
        mg_Witch.GetComponent<SpriteRenderer>().sprite = witchwithHAG;
        mg_Witch.gameObject.tag = "witchwithHAG";
    }

    void witchToHome()
    {
        witchToHomeFlag = true;
        if (mg_Witch.tag == "witchwithHAG")
        {
            mg_Witch.transform.position = Vector3.MoveTowards(mg_Witch.transform.position, new Vector3(22f, 6.7f, -6.9f), 0.05f);
        }

    }

    void ParticleAllPlay()
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

    }


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
    //이름 같은 파티클 찾은다음에 
}


