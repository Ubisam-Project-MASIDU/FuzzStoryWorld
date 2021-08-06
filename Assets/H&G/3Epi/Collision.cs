using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Vector3 mv3_initPos;
   
    // Start is called before the first frame update
    void Start()
    {
        mv3_initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 11f * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("1");
            if (collision.tag == this.tag)
            {
                Debug.Log("2");
                Destroy(this.gameObject);
            }
        }
    }
}
