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
    // Start is called before the first frame update
    void Awake()
    {
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");
        //mr_Rigidbody = mg_Hansel.GetComponent<Rigidbody>();
        setPos();

    }

    void Update()
    {
       
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    mv3_ObjectPos = hit.collider.gameObject.transform.position;
                    ms_ObjectName = hit.collider.gameObject.name;
                    Debug.Log(ms_ObjectName);
                }
            }
            HideBehindObject(ms_ObjectName);
        
        
        
        //mg_Hansel.transform.position = mv3_ObjectPos;
        //mg_Gretel.transform.position = mv3_ObjectPos;
        //Debug.Log(mv3_ObjectPos);
        //mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_ObjectPos, 2f * Time.deltaTime);
        //mr_Rigidbody.MovePosition(mv3_ObjectPos);
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
                break;
            case "Cauldron":
                mg_Hansel.transform.position = new Vector3(5.7f, 14f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(2.7f, 13.6f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                break;
            case "Tree":
                mg_Hansel.transform.position = new Vector3(-11.2f, 11.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-14.6f, 11f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 11);
                break;
            case "Log":
                mg_Hansel.transform.position = new Vector3(3.4f, 4.7f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -20);
                mg_Gretel.transform.position = new Vector3(-2f, 4.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 20);
                break;
            case "Stone":
                mg_Hansel.transform.position = new Vector3(-25.9f, 8.3f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(-28.4f, 7.2f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                break;
            case "House":
                mg_Hansel.transform.position = new Vector3(19.8f, 16.4f, -11f);
                mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, -10);
                mg_Gretel.transform.position = new Vector3(17f, 15.4f, -11f);
                mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 10);
                break;
            default:
                setPos();
                break;
        }
        mb_InitPos = false; //위치 옮겼으니까
    }
}
