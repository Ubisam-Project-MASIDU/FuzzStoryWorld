using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageZoom : MonoBehaviour
{
    public GameObject target;
    public float cameraSpeed, halfHeight;
    public Camera cam;
    public Vector3 targetPosition;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    void Move() {
        
            //그림위치찾기
            targetPosition.Set(this.transform.position.x, target.transform.position.y, target.transform.position.z);
            //그림위치로 카메라 속도에 맞게 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed);
        
    }
}
