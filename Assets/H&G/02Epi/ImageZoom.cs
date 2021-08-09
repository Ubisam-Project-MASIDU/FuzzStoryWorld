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
        
            //�׸���ġã��
            targetPosition.Set(this.transform.position.x, target.transform.position.y, target.transform.position.z);
            //�׸���ġ�� ī�޶� �ӵ��� �°� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed);
        
    }
}
