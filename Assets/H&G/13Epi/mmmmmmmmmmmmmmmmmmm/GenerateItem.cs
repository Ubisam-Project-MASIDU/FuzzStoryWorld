using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItem : MonoBehaviour
{
    public GameObject Item1_Orange;
    public GameObject Item2_Red;
    public GameObject Item3_Purple;
    public GameObject Item4_Blue;
    public GameObject Item5_Green;
    public GameObject Item6_Yellow;
    public GameObject Item7_Star;
    GameObject GenItem;

    GameObject Row1_Collid;
    GameObject Row2_Collid;
    GameObject Row3_Collid;
    GameObject Row4_Collid;
    GameObject Row5_Collid;
    GameObject Row6_Collid;
    GameObject Row7_Collid;

    float delta = 0;

    int RandomValue;

    // Start is called before the first frame update
    void Start()
    {
        Row1_Collid = GameObject.Find("Row1_Collid");
        Row2_Collid = GameObject.Find("Row2_Collid");
        Row3_Collid = GameObject.Find("Row3_Collid");
        Row4_Collid = GameObject.Find("Row4_Collid");
        Row5_Collid = GameObject.Find("Row5_Collid");
        Row6_Collid = GameObject.Find("Row6_Collid");
        Row7_Collid = GameObject.Find("Row7_Collid");
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > 1)
        {
            this.delta = 0;
            if (Row1_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, -6);
            }
            if (Row2_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, -4);
            }
            if (Row3_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, -2);
            }
            if (Row4_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, 0);
            }
            if (Row5_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, 2);
            }
            if (Row6_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, 4);
            }
            if (Row7_Collid.GetComponent<CheckCollid>().b_IsCollision() == false)
            {
                RandomValue = Random.Range(1, 8);
                v_GenItem(RandomValue, 6);
            }
        }
    }

    public void v_GenItem(int RandomValue, int RowNumber)
    {
        if (RandomValue == 1)
            GenItem = Instantiate(Item1_Orange) as GameObject;
        else if (RandomValue == 2)
            GenItem = Instantiate(Item2_Red) as GameObject;
        else if (RandomValue == 3)
            GenItem = Instantiate(Item3_Purple) as GameObject;
        else if (RandomValue == 4)
            GenItem = Instantiate(Item4_Blue) as GameObject;
        else if (RandomValue == 5)
            GenItem = Instantiate(Item5_Green) as GameObject;
        else if (RandomValue == 6)
            GenItem = Instantiate(Item6_Yellow) as GameObject;
        else if (RandomValue == 7)
            GenItem = Instantiate(Item7_Star) as GameObject;

        GenItem.transform.position = new Vector3(RowNumber, 8, 0);
    }

}
