using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkWitch : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;
    SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 4f);
    }
    void FixedUpdate()
    {
       //move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);  //velocity : 리지드바디의 현재 속도

      //platform check
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.2f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
            if(rayHit.collider == null) {
                Turn();
            }
        }              
    void Think() 
    {
        //set next active
        nextMove = Random.Range(-2, 2);
        Invoke("Think", 4f);
        
        //애니메이션
        anim.SetInteger("isWalking", nextMove);
        
        //방향(제한된 곳에 가면 방향 바꾸기)
        if(nextMove != 0) {
            spriteRenderer.flipX = nextMove == -1;
        }
    } 
    
    void Turn() {
                nextMove = nextMove * -1;
                spriteRenderer.flipX = nextMove == -1;
                CancelInvoke();
                Invoke("Think", 4f);

    }
}
