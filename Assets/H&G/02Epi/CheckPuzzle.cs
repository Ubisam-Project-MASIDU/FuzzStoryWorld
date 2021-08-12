using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPuzzle : MonoBehaviour
{
 
    private GameObject GameControl;
    Vector3 mv3_initPos;

    AnswerCheck ac;

    // Start is called before the first frame update
    void Start()
    {
        mv3_initPos = this.transform.position;

        GameControl = GameObject.Find("GameControl");

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 12f * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetMouseButtonUp(0))
        {

            if (col.name.ToString() == this.name)
            {
                col.gameObject.SetActive(false);
               
                Destroy(this.gameObject);
                
                GameControl.GetComponent<AnswerCheck>().AnswerCount();

            }
        }
    }
}
