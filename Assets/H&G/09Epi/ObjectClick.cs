using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public GameObject mg_Hansel;
    public GameObject mg_Gretel;
    private Vector3 mv3_ObjectPos;
    private string ms_ObjectName;
    private RaycastHit hit;
    private bool mb_InitPos;
    private int count;
    public SceneControl sc;
    [SerializeField] ParticleSystem lightParticle;

    private SpriteRenderer[] renders;
    
    void Awake()
    { 
        sc = GameObject.Find("GameControl").GetComponent<SceneControl>();
        renders = new SpriteRenderer[7];
        renders[0] = GameObject.FindGameObjectWithTag("Plant").GetComponent<SpriteRenderer>();
        renders[1] = GameObject.FindGameObjectWithTag("Cauldron").GetComponent<SpriteRenderer>();
        renders[2] = GameObject.FindGameObjectWithTag("Tree").GetComponent<SpriteRenderer>();
        renders[3] = GameObject.FindGameObjectWithTag("Log").GetComponent<SpriteRenderer>();
        renders[4] = GameObject.FindGameObjectWithTag("Stone").GetComponent<SpriteRenderer>();
        renders[5] = GameObject.FindGameObjectWithTag("House").GetComponent<SpriteRenderer>();
        renders[6] = GameObject.FindGameObjectWithTag("Plant").GetComponent<SpriteRenderer>();
        
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");

        count = 0;
        setPos();

    }

    void Update()
    {

        if (sc.hidestartflag) {
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    mv3_ObjectPos = hit.collider.gameObject.transform.position;
                    ms_ObjectName = hit.collider.gameObject.name;
                    Debug.Log(ms_ObjectName);
                }
                HideBehindObject(ms_ObjectName);
            }
        }
    }
    void setPos()
    {
        mg_Hansel.transform.position = new Vector3(-11.16f, 5.79f, -12.83f);
        mg_Gretel.transform.position = new Vector3(-14.3f, 4.7f, -12.3f);
        mb_InitPos = true;
        Debug.Log(mb_InitPos);
    }

    public void HideBehindObject(string sObjectName)
    {
        switch (sObjectName)
        {
            case "Plant":
                mg_Hansel.transform.position = new Vector3(-5.6f, 10.2f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-9.5f, 9.8f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                lightParticle.Play();
                break;
            case "Cauldron":
                mg_Hansel.transform.position = new Vector3(5.7f, 14f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(2.7f, 13.6f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                lightParticle.Play();
                break;
            case "Tree":
                mg_Hansel.transform.position = new Vector3(-11.2f, 11.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-14.6f, 11f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                lightParticle.Play();
                break;
            case "Log":
                mg_Hansel.transform.position = new Vector3(3.4f, 4.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-2f, 4.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 20);
                lightParticle.Play();
                break;
            case "Stone":
                mg_Hansel.transform.position = new Vector3(-25.9f, 8.3f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-28.4f, 7.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                lightParticle.Play();
                break;
            case "House":
                mg_Hansel.transform.position = new Vector3(19.8f, 16.4f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(17f, 15.4f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                lightParticle.Play();
                break;
            default:
                setPos();
                break;
        }
        count++;
        ColorChange(sObjectName);
        mb_InitPos = false; //위치 옮겼으니까
        //숨은 위치와 hag만 밝게
    }

    void ColorChange(string sObjectName)
    {
        for (int i = 0; i < 7; i++)
        {
            if(sObjectName != renders[i].tag)
            {
                renders[i].color = new Color(80 / 255f, 80 / 255f, 80 / 255f, 80 / 255f);
            }
        }
    }

    //어두워졌을때 6개중 1개 선택 -> 숨기 -> 6번반복
    //count 6 됐을때 서서히 밝아지면서 마녀를 그 오브젝트쪽으로 이동

}
