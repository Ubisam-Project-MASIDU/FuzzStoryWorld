using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageArray : MonoBehaviour
{
    int[,] ItemArray = new int[6,7];

    string TextArray = "아이템 배치표\n";

    GameObject GameDirector;
    GameObject DestroyObject;
    float delta = 0;
    bool InitFlag = false;
    bool GenerateFlag = true;
    int i = 5;

    int cursor;
    int distance;





    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector");

        InitItemArray();
        ShowItemArray();

    }

    // Update is called once per frame
    void Update()
    {
        //초기 설정
        this.delta += Time.deltaTime;
        if (this.delta > 1)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i >= 0)
                {
                    GameDirector.GetComponent<GenerateItem>().v_GenItem(ItemArray[i, j], (j + 1));
                }
                else
                    GenerateFlag = false;
            }
            this.delta = 0;
            i--;
        }


        //터지는거 확인
        if (GenerateFlag == false)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    distance = 1;
                    cursor = ItemArray[i, j];
                    //가로로 확인
                    for (int k = j + 1; k < 7; k++)
                    {
                        if (cursor != ItemArray[i, k] && distance < 3)
                        {
                            break;
                        }
                        else if (cursor == ItemArray[i, k] && k < 6)
                        {
                            distance++;
                        }
                        else if (cursor == ItemArray[i, k] && k == 6 || cursor != ItemArray[i, k] && distance >= 3)
                        {
                            Debug.Log("i : " + i + " j : " + j + " cursor : " + cursor);
                            
                            /*
                            for (int n = 0; n <= distance; n++)
                            {
                                //ItemArray[i, j+n] = -1;
                                
                                if (j == 1)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);
                                else if (j == 2)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);
                                else if (j == 3)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);
                                else if (j == 4)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);
                                else if (j == 5)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);
                                else if (j == 6)
                                    GameDirector.GetComponent<GenerateItem>().v_DestroyObject(i, j + n);

                            }
                            */  
                            break;
                        }
                    }
                }
            }
            //ShowItemArray();
        }



    }

    public void InitItemArray()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                ItemArray[i, j] = Random.Range(1, 5);           //아이템 범위 지정 (초기값:8)
            }
        }
    }

    public void ShowItemArray()
    {
        for (int i=0; i<6; i++)
        {
            for (int j=0; j<7; j++)
            {
                TextArray = TextArray + ItemArray[i, j] + " ";
            }
            TextArray += "\n";
        }
        Debug.Log(TextArray);
    }

}
