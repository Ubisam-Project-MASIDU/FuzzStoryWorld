using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWitch : MonoBehaviour
{
    public GameObject mgo_HanselGretel;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per fram
    void Update()
    {     
        if(Mathf.Abs(mgo_HanselGretel.transform.position.x - transform.position.x) < 1.0) {
            anim.SetBool("Walking", false);
        } else {
            anim.SetBool("Walking", true);
            transform.position = Vector3.MoveTowards(transform.position, mgo_HanselGretel.transform.position, 2f * Time.deltaTime);
        }
        if(mgo_HanselGretel.transform.position.x - transform.position.x < 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }
}
    