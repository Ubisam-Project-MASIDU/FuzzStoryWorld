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
    GameObject DeletedObject;

    GameObject Row1;
    GameObject Row2;
    GameObject Row3;
    GameObject Row4;
    GameObject Row5;
    GameObject Row6;
    GameObject Row7;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {
        Row1 = GameObject.Find("Row1");
        Row2 = GameObject.Find("Row2");
        Row3 = GameObject.Find("Row3");
        Row4 = GameObject.Find("Row4");
        Row5 = GameObject.Find("Row5");
        Row6 = GameObject.Find("Row6");
        Row7 = GameObject.Find("Row7");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void v_GenItem(int ItemNumber, int RowNumber)
    {

        if (ItemNumber == 1)
            GenItem = Instantiate(Item1_Orange) as GameObject;
        else if (ItemNumber == 2)
            GenItem = Instantiate(Item2_Red) as GameObject;
        else if (ItemNumber == 3)
            GenItem = Instantiate(Item3_Purple) as GameObject;
        else if (ItemNumber == 4)
            GenItem = Instantiate(Item4_Blue) as GameObject;
        else if (ItemNumber == 5)
            GenItem = Instantiate(Item5_Green) as GameObject;
        else if (ItemNumber == 6)
            GenItem = Instantiate(Item6_Yellow) as GameObject;
        else if (ItemNumber == 7)
            GenItem = Instantiate(Item7_Star) as GameObject;

        if (RowNumber == 1)
        {
            GenItem.transform.SetParent(Row1.transform);
            GenItem.transform.position = new Vector3(-6, 8, 0);
        }
        else if (RowNumber == 2)
        {
            GenItem.transform.SetParent(Row2.transform);
            GenItem.transform.position = new Vector3(-4, 8, 0);
        }
        else if (RowNumber == 3)
        {
            GenItem.transform.SetParent(Row3.transform);
            GenItem.transform.position = new Vector3(-2, 8, 0);
        }
        else if (RowNumber == 4)
        {
            GenItem.transform.SetParent(Row4.transform);
            GenItem.transform.position = new Vector3(0, 8, 0);
        }
        else if (RowNumber == 5)
        {
            GenItem.transform.SetParent(Row5.transform);
            GenItem.transform.position = new Vector3(2, 8, 0);
        }
        else if (RowNumber == 6)
        {
            GenItem.transform.SetParent(Row6.transform);
            GenItem.transform.position = new Vector3(4, 8, 0);
        }
        else if (RowNumber == 7)
        {
            GenItem.transform.SetParent(Row7.transform);
            GenItem.transform.position = new Vector3(6, 8, 0);
        }
    }

    public void v_DestroyObject(int RowNumber, int ChildNumber)
    {
        if (Row1.transform.childCount == 6)
        {
            DeletedObject = Row1.transform.GetChild(6 - ChildNumber).gameObject;
            if(DeletedObject.gameObject != null)
                Destroy(DeletedObject.gameObject, 3);
        }
    }

}
