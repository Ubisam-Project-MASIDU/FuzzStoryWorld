using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Vector3 mv3_initPos;
    public bool locked = false;
    public Sprite sNextSprite;
    // Start is called before the first frame update
    void Start()
    {
        mv3_initPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, mv3_initPos, 10f * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("1");
            if (collision.name[collision.name.Length - 1] == this.name[this.name.Length - 1])
            {
                Debug.Log("2");
                Destroy(this.gameObject);
            }
        }
    }
}
