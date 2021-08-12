using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fffff : MonoBehaviour
{
    private GameObject Image;
    public Sprite Image1;
    public Sprite Image2;

    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;
    public GameObject Answer4;
    public GameObject Answer5;
    public GameObject Answer6;
    public GameObject Answer7;
    public GameObject Answer8;
    public GameObject Answer9;

    // Start is called before the first frame update
    void Start()
    {
        Image = GameObject.Find("Image");
        Image.GetComponent<SpriteRenderer>().sprite = Image1; //기본값은 첫번째 이미지
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstImage()
    {
        ActivePiece();

        Image.GetComponent<SpriteRenderer>().sprite = Image1; //첫번째 이미지로 바꿔줌
  
    }

    public void SecondImage()
    {
        ActivePiece();

        Image.GetComponent<SpriteRenderer>().sprite = Image2; //두번째 이미지로 바꿔줌
    }

    public void ActivePiece()
    {
        Answer1.SetActive(true);
        Answer2.SetActive(true);
        Answer3.SetActive(true);
        Answer4.SetActive(true);
        Answer5.SetActive(true);
        Answer6.SetActive(true);
        Answer7.SetActive(true);
        Answer8.SetActive(true);
        Answer9.SetActive(true);
    }
}
