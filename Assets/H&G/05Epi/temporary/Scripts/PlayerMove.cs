using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        //Stop Speed
        if(Input.GetButtonUp("Horizontal")){
            //벡터 크기를 1로 만든 상태(단위벡터)
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f,rigid.velocity.y);
        }

        //Direction Sprite
        if(Input.GetButtonDown("Horizontal")){
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    //Move Speed
     float h = Input.GetAxisRaw("Horizontal");
     rigid.AddForce(Vector2.right*h , ForceMode2D.Impulse);

     if(rigid.velocity.x > maxSpeed){ //Right Max Speed
        rigid.velocity = new Vector2(maxSpeed,rigid.velocity.y);
     }else if(rigid.velocity.x < maxSpeed*(-1)){ //Left Max Speed, 방향이 음수이므로 x-1
        rigid.velocity = new Vector2(maxSpeed*(-1),rigid.velocity.y);
     }
    }
}
