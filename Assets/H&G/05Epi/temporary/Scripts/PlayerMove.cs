using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    public float jumpPower;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        //Jump
        if(Input.GetButtonDown("Jump") && !animator.GetBool("isJumping")){
            rigid.AddForce(Vector2.up*jumpPower , ForceMode2D.Impulse);
            animator.SetBool("isJumping",true);        
        }
        //Stop Speed
        if(Input.GetButtonUp("Horizontal")){
            //벡터 크기를 1로 만든 상태(단위벡터)
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f,rigid.velocity.y);
        }

        //Direction Sprite
        if(Input.GetButtonDown("Horizontal")){
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3){
            animator.SetBool("isWalking", false);
        }
        else{
            animator.SetBool("isWalking", true);
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

        //Landing Platform
        if(rigid.velocity.y < 0){
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0)); //에디터 상에서만 Ray를 그려주는 함수
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if(rayHit.collider != null){ //RaycastHit변수의 콜라이더로 검색 확인 기능
                if(rayHit.distance < 0.5f){
                    animator.SetBool("isJumping",false);
                }
            }
        }
    }
}
