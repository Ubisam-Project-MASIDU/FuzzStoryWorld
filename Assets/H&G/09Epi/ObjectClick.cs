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
    // Start is called before the first frame update
    void Start()
    {
        mg_Hansel = GameObject.Find("Hansel");
        mg_Gretel = GameObject.Find("Gratel");
        //mr_Rigidbody = mg_Hansel.GetComponent<Rigidbody>();
        mv3_ObjectPos = new Vector3(-18.97f, 3.19f, -11f);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                mv3_ObjectPos = hit.collider.gameObject.transform.position;
                ms_ObjectName = hit.collider.gameObject.name;
                Debug.Log(ms_ObjectName);
            }
        }
        HideBehindObject();
        //mg_Hansel.transform.position = mv3_ObjectPos;
        //mg_Gretel.transform.position = mv3_ObjectPos;
        //Debug.Log(mv3_ObjectPos);
        //mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_ObjectPos, 2f * Time.deltaTime);
        //mr_Rigidbody.MovePosition(mv3_ObjectPos);
    }

    public void HideBehindObject()
    {
        if (ms_ObjectName == "House")
        {
            mg_Hansel.transform.position = new Vector3(7.4f, 7.4f, -11f);
            mg_Hansel.transform.rotation = Quaternion.Euler(0, 0, 12);
            mg_Gretel.transform.position = new Vector3(4.78f, 7.49f, -11f);
            mg_Gretel.transform.rotation = Quaternion.Euler(0, 0, 15);
        }
        else if (ms_ObjectName == "Box")
        {

        }
    }
}
