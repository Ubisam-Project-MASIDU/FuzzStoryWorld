using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCandy : MonoBehaviour
{
    private Vector3 screenSpace;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 오브젝트를 클릭한 경우
    private void OnMouseDown(){
        //translate the cubes position from the world to Screen Point
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);
        //calculate any difference between the cubes world position and the mouses Screen position converted to a world point 
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
    }

    // 오브젝트를 드래그한 경우
    private void OnMouseDrag(){
        //keep track of the mouse position
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        //convert the screen mouse position to world point and adjust with offset
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        //update the position of the object in the world
        transform.position = curPosition;
        Debug.Log("드래그앤 드롭 작동중");

    }

    // 오브젝트에서 손을 떼는 경우
    private void OnMouseUp(){
        Debug.Log("오브젝트에서 손 뗌");
        if(this.tag == "Pink"){                                                       // 오브젝트에 따라
            this.transform.position = new Vector3(1.986f, 1.86f, -7.54f);                          // 원래 위치로 이동
        }
        if (this.tag == "Yellow"){
            this.transform.position = new Vector3(2.178f, 0.955f, -7.54f);
        }
        if (this.tag == "Blue"){
            this.transform.position = new Vector3(3.288f, 1.02f, -7.54f);
        }
    }
}
