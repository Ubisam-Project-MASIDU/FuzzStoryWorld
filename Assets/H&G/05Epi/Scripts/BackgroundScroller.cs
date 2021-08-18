using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject Background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay){
            transform.Translate(Vector2.left * Time.deltaTime * 1f);    // 오브젝트(조약돌) 좌측으로 이동
        }

    }
}
