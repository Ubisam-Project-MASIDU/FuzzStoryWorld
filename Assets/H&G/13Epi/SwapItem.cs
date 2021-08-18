/*
 * - Name : SwapItem.cs
 * - Writer : 김명현
 * 
 * - Content :
 * 아이템을 드래그하면 어느방향으로 드래그 하였는지 할려주는 스크립트
 * 
 * - History
 * 1) 2021-08-11 : 어느방향으로 드래그하였는지 알려주는 함수 작성
 * 2) 2021-08-12 : 상하좌우 방향으로 드래그 기능 구현
 * 
 * - Variable 
 * mb_DragFlag                                      Flag 값 -> Flag값이 True일 경우에만 어느방향으로 드래그하였는지 알려줌
 * mv3_screenSpace                                  월드좌표를 화면좌표로 변경하여 저장해두는 변수
 * mv3_offset                                       마우스 클릭좌표를 계산하기 위해 필요
 * mv3_StartPoint                                   마우스 클릭좌표를 저장해두는 변수
 * mv3_EndPoint                                     마우스에서 손을뗄떼 좌표를 저장해주는 변수
 * DragDirection                                    드래그 방향을 숫자로 변환해 저장해두는 변수
 * mg_GameDirector                                  게임디렉터 오브젝트 연결을 위한 변수
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

// 아이템들을 서로 바꿀때의 처리를 작성해둔 스크립트
public class SwapItem : MonoBehaviour
{
    bool mb_DragFlag = false;                                                           // Flag 값 -> Flag값이 True일 경우에만 어느방향으로 드래그하였는지 알려줌
    private Vector3 mv3_screenSpace;                                                    // 월드좌표를 화면좌표로 변경하여 저장해두는 변수
    private Vector3 mv3_offset;                                                         // 마우스 클릭좌표를 계산하기 위해 필요
    Vector3 mv3_StartPoint;                                                             // 마우스 클릭좌표를 저장해두는 변수
    Vector3 mv3_EndPoint;                                                               // 마우스에서 손을뗄떼 좌표를 저장해주는 변수
    int DragDirection;                                                                  // 드래그 방향을 숫자로 변환해 저장해두는 변수
    GameObject mg_GameDirector;                                                         // 게임디렉터 오브젝트 연결을 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        mg_GameDirector = GameObject.Find("GameDirector");                              // 오브젝트 연결
    }

    // Update is called once per frame
    void Update()
    {
        mb_DragFlag = mg_GameDirector.GetComponent<ManageArray>().b_ReturnDragFlag();   // 드래그가 가능한 상태인지 실시간으로 전달받는다.
    }

    /// <summary>
    /// 마우스 왼쪽 버튼을 누른경우
    /// </summary>
    private void OnMouseDown()
    {
        if (mb_DragFlag == true)                                                        // 마우스가 클릭 가능한 상태인 경우
        {                                                                               // 마우스 좌표를 딴다.
            mv3_screenSpace = Camera.main.WorldToScreenPoint(transform.position);                                   
            mv3_offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z));
            mv3_StartPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z)) + mv3_offset;
            //Debug.Log("마우스 다운 포지션 : " + mv3_StartPoint);
        }
    }

    /// <summary>
    /// 마우스 왼쪽 버튼을 뗀 경우
    /// </summary>
    private void OnMouseUp()
    {
        if (mb_DragFlag == true)                                                        // 마우스가 클릭 가능한 상태인 경우
        {                                                                               // 마우스 좌표를 딴다.
            mg_GameDirector.GetComponent<ManageArray>().v_ChangeDragFlagFalse();
            var curmv3_screenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mv3_screenSpace.z);
            mv3_EndPoint = Camera.main.ScreenToWorldPoint(curmv3_screenSpace) + mv3_offset;
            //Debug.Log("마우스 업 : " + mv3_EndPoint);
            DragDirection = n_CalculateTheAngle(mv3_StartPoint, mv3_EndPoint);          // 처음 눌렀을때의 위치와 뗄떄의 각도를 계산하여 어느방향으로 드래그하였는지 계산한다.
            ShowMeDragDirection(DragDirection);                                         // 어느방향으로 드래그하였는지 로그를 출력해준다.
            mg_GameDirector.GetComponent<ManageArray>().v_ChangeSwapFalgTrue();

            switch (DragDirection)
            {
                case -1:
                    //Debug.Log("드래그 안함");
                    break;
                case 0:
                    //Debug.Log("드래그 방향 : Left");
                    v_DragLeft();
                    Debug.Log(mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop());           // 드래그한 방향으로 아이템을 옮긴다.
                    if (mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop() == false)         // 아이템 배열을 검사하여 아이템이 터지지 않을 경우 원래위치로 복원
                        Invoke("v_DragRight", 1.5f);
                    break;
                case 1:
                    //Debug.Log("드래그 방향 : Down");
                    v_DragDown();
                    Debug.Log(mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop());
                    if (mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop() == false)
                        Invoke("v_DragUp", 1.5f);
                    break;
                case 2:
                    //Debug.Log("드래그 방향 : Right");
                    v_DragRight();
                    Debug.Log(mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop());
                    if (mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop() == false)
                        Invoke("v_DragLeft", 1.5f);
                    break;
                case 3:
                    //Debug.Log("드래그 방향 : Up");
                    v_DragUp();
                    Debug.Log(mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop());
                    if (mg_GameDirector.GetComponent<ManageArray>().b_InspectArrayIsPop() == false)
                        Invoke("v_DragDown", 1.5f);
                    break;
            }
            mg_GameDirector.GetComponent<ManageArray>().v_ChangeFailToDragFlagFalse();
            Invoke("v_TurnOnMouseDrag", 1.5f);
        }
    }

    #region 함수 선언부
    /// <summary>
    /// 드래그한 방향을 계산해주는 함수
    /// </summary>
    /// <param name="v3StartPoint">마우스 첫 지점</param>
    /// <param name="v3EndPoint">마우스 끝 지점</param>
    /// <returns></returns>
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

    /// <summary>
    /// 드래그 방향을 로그에 출력해주는 함수
    /// </summary>
    /// <param name="nAngle">n_CalculateTheAngle() 함수의 결과값을 넣어준다.</param>
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

    /// <summary>
    /// Invoke를 사용하기위해 함수형태로 선언, 아래쪽으로 드래그
    /// </summary>
    public void v_DragDown()
    {
        mg_GameDirector.GetComponent<ManageArray>().v_DragToDown(this.gameObject);
    }

    /// <summary>
    /// Invoke를 사용하기위해 함수형태로 선언, 위쪽으로 드래그
    /// </summary>
    public void v_DragUp()
    {
        mg_GameDirector.GetComponent<ManageArray>().v_DragToUp(this.gameObject);
    }

    /// <summary>
    /// /// <summary>
    /// Invoke를 사용하기위해 함수형태로 선언, 오른쪽으로 드래그
    /// </summary>
    /// </summary>
    public void v_DragRight()
    {
        mg_GameDirector.GetComponent<ManageArray>().v_DragToRight(this.gameObject);
    }

    /// <summary>
    /// Invoke를 사용하기위해 함수형태로 선언, 왼쪽으로 드래그
    /// </summary>
    public void v_DragLeft()
    {
        mg_GameDirector.GetComponent<ManageArray>().v_DragToLeft(this.gameObject);
    }
    #endregion
}
