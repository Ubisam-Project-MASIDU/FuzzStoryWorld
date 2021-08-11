using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPuzzle : MonoBehaviour
{

    public Sprite[] puzzle_list = new Sprite[9];
    private GameObject[] slot = new GameObject[9];
    private GameObject puzzle_image;

    //public Sprite[] puzzle2_list = new Sprite[9];
    //private GameObject[] slot2 = new GameObject[9];
    //private GameObject puzzle2_image;

    public int[] randNumArray = new int[9];
    public int[] randNumArray2 = new int[9];

    private GameObject Slot1;
    private GameObject Slot2;
    private GameObject Slot3;
    private GameObject Slot4;
    private GameObject Slot5;
    private GameObject Slot6;
    private GameObject Slot7;
    private GameObject Slot8;
    private GameObject Slot9;

    /*private GameObject Slot2_1;
    private GameObject Slot2_2;
    private GameObject Slot2_3;
    private GameObject Slot2_4;
    private GameObject Slot2_5;
    private GameObject Slot2_6;
    private GameObject Slot2_7;
    private GameObject Slot2_8;
    private GameObject Slot2_9;
    */

    int mn_RandomValue;
    // Start is called before the first frame update
    void Start()
    {
        //puzzle1_image = GameObject.Find("Answer");
        slot[0] = GameObject.Find("Slot1");
        slot[1] = GameObject.Find("Slot2");
        slot[2] = GameObject.Find("Slot3");
        slot[3] = GameObject.Find("Slot4");
        slot[4] = GameObject.Find("Slot5");
        slot[5] = GameObject.Find("Slot6");
        slot[6] = GameObject.Find("Slot7");
        slot[7] = GameObject.Find("Slot8");
        slot[8] = GameObject.Find("Slot9");

        /*slot2[0] = GameObject.Find("Slot2_1");
        slot2[1] = GameObject.Find("Slot2_2");
        slot2[2] = GameObject.Find("Slot2_3");
        slot2[3] = GameObject.Find("Slot2_4");
        slot2[4] = GameObject.Find("Slot2_5");
        slot2[5] = GameObject.Find("Slot2_6");
        slot2[6] = GameObject.Find("Slot2_7");
        slot2[7] = GameObject.Find("Slot2_8");
        slot2[8] = GameObject.Find("Slot2_9");
        */
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
            slot[i].GetComponent<SpriteRenderer>().sprite = puzzle_list[randNumArray[i]];
            slot[i].name = randNumArray[i].ToString();
        }  
        
        
    }


    /*void mapReplay()
    {
        .GetComponent<SpriteRenderer>().sprite = puzzle1_list[randNumArray1[i]];
    }*/
}
            