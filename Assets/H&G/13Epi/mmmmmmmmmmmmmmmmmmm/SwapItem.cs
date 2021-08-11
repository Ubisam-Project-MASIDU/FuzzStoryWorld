/*
 * - Name : SwapItem.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 아이템을 드래그하면 어느방향으로 드래그 하였는지 할려주는 스크립트
 * 
 * - History
 * 1) 2021-08-11 : 어느방향으로 드래그하였는지 알려주는 함수 작성
 *  
 * - Variable 
 * mb_DragFlag                                      Flag 값 -> Flag값이 True일 경우에만 어느방향으로 드래그하였는지 알려줌
 * mv3_screenSpace                                  월드좌표를 화면좌표로 변경하여 저장해두는 변수
 * mv3_offset                                       마우스 클릭좌표를 계산하기 위해 필요
 * mv3_StartPoint                                   마우스 클릭좌표를 저장해두는 변수
 * mv3_EndPoint                                     마우스에서 손을뗄떼 좌표를 저장해주는 변수
 * 
 * 
 * 
 * 
 * 
 * - Function
 * ChangeSwapFlagTrue()                             DragFlag값을 True로 변환
 * ChangeSwapFlagFalse()                            DragFlag값을 False로 변환
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapItem : MonoBehaviour
{
    bool mb_DragFlag = true;
    private Vector3 mv3_screenSpace;
    private Vector3 mv3_offset;

    Vector3 mv3_StartPoint;
    Vector3 mv3_EndPoint;

    int DragDirection;
    GameObject mg_GameDirector;



    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (mb_DragFlag == true)
        {
            mv3_screenSpace = Camera.main.WorldToScreenPoint(transform.position);                                   
            mv3_offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z));
            mv3_StartPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z)) + mv3_offset;
            //Debug.Log("마우스 다운 포지션 : " + mv3_StartPoint);
        }
    }

    private void OnMouseUp()
    {
        if (mb_DragFlag == true)
        {
            var curmv3_screenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z);
            mv3_EndPoint = Camera.main.ScreenToWorldPoint(curmv3_screenSpace) + mv3_offset;
            //Debug.Log("마우스 업 : " + mv3_EndPoint);
            DragDirection = n_CalculateTheAngle(mv3_StartPoint, mv3_EndPoint);
            ShowMeDragDirection(DragDirection);
            mg_GameDirector.GetComponent<ManageArray>().ChangeSwapFalgTrue();

            switch (DragDirection)
            {
                case -1:
                    //Debug.Log("드래그 안함");
                    break;
                case 0:
                    //Debug.Log("드래그 방향 : Left");
                    break;
                case 1:
                    //Debug.Log("드래그 방향 : Down");
                    break;
                case 2:
                    //Debug.Log("드래그 방향 : Right");
                    break;
                case 3:
                    //Debug.Log("드래그 방향 : Up");
                    //transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                    //Debug.Log("x : " + transform.position.x + " y : " + transform.position.y);
                    mg_GameDirector.GetComponent<ManageArray>().DragToUp(this.gameObject);
                    break;
            }
        }
    }



    public void ChangeDragFlagTrue()
    {
        mb_DragFlag = true;
    }

    public void ChangeDragFlagFalse()
    {
        mb_DragFlag = false;
    }

    public int n_CalculateTheAngle(Vector3 v3StartPoint, Vector3 v3EndPoint)
    {
        Vector3 DragDirection = v3StartPoint - v3EndPoint;
        if (DragDirection.magnitude <= 0.2f) 
            return -1;
        float aimAngle = Mathf.Atan2(DragDirection.y, DragDirection.x);

        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
        float angle = aimAngle * Mathf.Rad2Deg;
        int swipe = (((int)angle + 45) % 360) / 90;
        return swipe;
    }

    public void ShowMeDragDirection(int nAngle)
    {
        switch (nAngle)
        {
            case -1:
                Debug.Log("드래그 안함");
                break;
            case 0:
                Debug.Log("드래그 방향 : Left");
                break;
            case 1:
                Debug.Log("드래그 방향 : Down");
                break;
            case 2:
                Debug.Log("드래그 방향 : Right");
                break;
            case 3:
                Debug.Log("드래그 방향 : Up");
                break;
        }
    }
}
