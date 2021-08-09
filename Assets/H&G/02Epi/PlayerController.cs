using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
       
    }

    public void ButtonDown()
    {
        transform.Translate(1, 0, 0);
        Debug.Log("buttonPress");
        
    }

 
    
}
