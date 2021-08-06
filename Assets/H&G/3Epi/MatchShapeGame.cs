/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchShapeGame : MonoBehaviour
{

    public GameObject Circle;
    public GameObject Square;
    public GameObject Triangle;
    Vector2 mv2_initPos;
    public bool locked = false;
    public Sprite sNextSprite;
    void Start()
    {
        mv2_initPos = this.transform.position
    }
  
    private Transform shapeBasket;

    private Vector3 mv3_initPos;

    private Vector3 mousePos;

    private float deltaX, deltaY;

    public static bool locked;

    /*Vector2 mv2_beforePos;
    public bool mb_classifyWhetherAns = false;
    public Sprite sNextSprite;*/

    // Start is called before the first frame update
    /*
    void Start()
    {
        mv3_initPos = transform.position;
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log("1");

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        Debug.Log("2");
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - shapeBasket.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - shapeBasket.position.y) <= 0.5f)
                    {
                        
                        transform.position = new Vector3(shapeBasket.position.x, shapeBasket.position.y, -4.92f);
                        locked = true;
                        Debug.Log("3");
                    }
                    else
                    {
                        transform.position = new Vector3(mv3_initPos.x, mv3_initPos.y, -4.92f);
                    }
                    break;

            }
        }
    }
}
*/
    /*
    private void OnMouseDown()
    {
       
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - m_shapePos.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - m_shapePos.position.y) <= 0.5f)
        {
            transform.position = new Vector2(m_shapePos.position.x, m_shapePos.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(mv2_initPos.x, mv2_initPos.y);
        }
    }

}


   /* private void OnTriggerStay2D(Collider2D collision)
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