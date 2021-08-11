using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleCheck : MonoBehaviour
{
    private GameObject Answer1;
    private GameObject Answer2;
    private GameObject Answer3;
    private GameObject Answer4;
    private GameObject Answer5;
    private GameObject Answer6;
    private GameObject Answer7;
    private GameObject Answer8;
    private GameObject Answer9;

    private GameObject GameControl;
    Vector3 mv3_initPos;

    AnswerCheck ac;
    
    // Start is called before the first frame update
    void Start()
    {
        mv3_initPos = this.transform.position;
 
        Answer1 = GameObject.Find("1");
        GameControl = GameObject.Find("GameControl");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 11f * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetMouseButtonUp(0))
        {
 
            if (col.name.ToString() == this.name)
            {
                
                Destroy(col.gameObject);
                Destroy(this.gameObject);
                //ac.AnswerCount();
                GameControl.GetComponent<AnswerCheck>().AnswerCount();

            }
        }
    }
}
