using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPuzzle : MonoBehaviour
{

    public Sprite[] puzzleImage1 = new Sprite[9];
    public Sprite[] puzzleImage2 = new Sprite[9];
    private GameObject[] slot = new GameObject[9];


    int[] randNumArray = new int[9];

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

    private GameObject Slot1;
    private GameObject Slot2;
    private GameObject Slot3;
    private GameObject Slot4;
    private GameObject Slot5;
    private GameObject Slot6;
    private GameObject Slot7;
    private GameObject Slot8;
    private GameObject Slot9;


    void Start()
    {
        Image = GameObject.Find("Image");
        Image.GetComponent<SpriteRenderer>().sprite = Image1; //기본값은 첫번째 이미지

        slot[0] = GameObject.Find("Slot1");
        slot[1] = GameObject.Find("Slot2");
        slot[2] = GameObject.Find("Slot3");
        slot[3] = GameObject.Find("Slot4");
        slot[4] = GameObject.Find("Slot5");
        slot[5] = GameObject.Find("Slot6");
        slot[6] = GameObject.Find("Slot7");
        slot[7] = GameObject.Find("Slot8");
        slot[8] = GameObject.Find("Slot9");

        RandomNum();
    }

    // Update is called once per frame



    void RandomNum() //중복없는 랜덤 이미지 배치
    {
        for (int i = 0; i < 9; i++)
        {
            randNumArray[i] = Random.Range(0, 9);
            for (int j = 0; j < i; j++)
            {
                if (randNumArray[i] == randNumArray[j])
                {
                    i--;
                    break;
                }
            }
        }

        /*for (int i = 0; i < 9; i++)
        {
            slot[i].GetComponent<SpriteRenderer>().sprite = puzzleImage1[randNumArray[i]];
            slot[i].name = randNumArray[i].ToString();
        }*/  
    }

    public void FirstImage()
    {
        ActivePiece(); //흰조각들 다시 보이게하기
        InitArray();
        Image.GetComponent<SpriteRenderer>().sprite = Image1; //첫번째 이미지로 바꿔줌

        RandomNum();

        for (int i = 0; i < 9; i++)
        {
            slot[i].GetComponent<SpriteRenderer>().sprite = puzzleImage1[randNumArray[i]];
            slot[i].name = randNumArray[i].ToString();
        }
    }

    public void SecondImage()
    {
        ActivePiece();
        InitArray();
        Image.GetComponent<SpriteRenderer>().sprite = Image2; //두번째 이미지로 바꿔줌

        RandomNum();

        for (int i = 0; i < 9; i++)
        {
            slot[i].GetComponent<SpriteRenderer>().sprite = puzzleImage2[randNumArray[i]];
            slot[i].name = randNumArray[i].ToString();
        }
    }
    public void InitArray()
    {
        for (int i = 0; i < 9; i++)
        {
            randNumArray[i] = 999; //배열초기화
        }
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
            