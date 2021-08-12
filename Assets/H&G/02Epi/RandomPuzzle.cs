using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPuzzle : MonoBehaviour
{

    public Sprite[] puzzleImage = new Sprite[9];
    private GameObject[] slot = new GameObject[9];
    
    int[] randNumArray = new int[9];

    private GameObject Slot1;
    private GameObject Slot2;
    private GameObject Slot3;
    private GameObject Slot4;
    private GameObject Slot5;
    private GameObject Slot6;
    private GameObject Slot7;
    private GameObject Slot8;
    private GameObject Slot9;

    int mn_RandomValue;
    // Start is called before the first frame update
    void Start()
    {

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

        for (int i = 0; i < 9; i++)
        {
            slot[i].GetComponent<SpriteRenderer>().sprite = puzzleImage[randNumArray[i]];
            slot[i].tag = randNumArray[i].ToString();
        }  
    }
}
            