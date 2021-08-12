
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementH : MonoBehaviour
{
    
    private GameObject mg_Hansel;
    public Vector3 mv3_TargetPoint;

 
    void Start()
    {
        mv3_TargetPoint = new Vector3(-2.7f, -0.8f, -2.5f);
        mg_Hansel = GameObject.Find("Hansel");
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_TargetPoint, 0.07f);
        
    }
    
    void Update()
    {
        mg_Hansel.transform.position = Vector3.MoveTowards(mg_Hansel.transform.position, mv3_TargetPoint, 0.07f);

    }
}
