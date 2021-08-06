/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchShapeGame : MonoBehaviour
{

    Vector2 mv2_beforePos;
    public bool mb_classifyWhetherAns = false;
    public Sprite sNextSprite;

    // Start is called before the first frame update
    void Start()
    {
        mv2_beforePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mv2_beforePos = Vector3.MoveTowards(this.transform.position, mv2_beforePos, 10f * Time.deltaTime);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if( collision.tag == this.tag)
            {

            }
        }
    }
}
*/