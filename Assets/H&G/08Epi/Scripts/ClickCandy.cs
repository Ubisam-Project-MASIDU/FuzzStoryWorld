using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClickCandy : MonoBehaviour
{
    private int mn_Click = 5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("클릭");
        this.mn_Click-= 1;
        if(this.mn_Click == 0){
            Debug.Log("제거");
            Destroy(this.gameObject);
        }
    }
}
