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

    GameObject Col1;
    GameObject Col2;
    GameObject Col3;
    GameObject Col4;
    GameObject Col5;
    GameObject Col6;
    GameObject Col7;

    bool IsStopFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        Col1 = GameObject.Find("Col1");
        Col2 = GameObject.Find("Col2");
        Col3 = GameObject.Find("Col3");
        Col4 = GameObject.Find("Col4");
        Col5 = GameObject.Find("Col5");
        Col6 = GameObject.Find("Col6");
        Col7 = GameObject.Find("Col7");
    }

    // Update is called once per frame
    void Update()
    {
        IsStop();
    }

    public void v_GenItem(int ItemNumber, int ColNumber)
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

        if (ColNumber == 1)
        {
            GenItem.transform.SetParent(Col1.transform);
            GenItem.transform.position = new Vector3(-6, 8, 0);
        }
        else if (ColNumber == 2)
        {
            GenItem.transform.SetParent(Col2.transform);
            GenItem.transform.position = new Vector3(-4, 8, 0);
        }
        else if (ColNumber == 3)
        {
            GenItem.transform.SetParent(Col3.transform);
            GenItem.transform.position = new Vector3(-2, 8, 0);
        }
        else if (ColNumber == 4)
        {
            GenItem.transform.SetParent(Col4.transform);
            GenItem.transform.position = new Vector3(0, 8, 0);
        }
        else if (ColNumber == 5)
        {
            GenItem.transform.SetParent(Col5.transform);
            GenItem.transform.position = new Vector3(2, 8, 0);
        }
        else if (ColNumber == 6)
        {
            GenItem.transform.SetParent(Col6.transform);
            GenItem.transform.position = new Vector3(4, 8, 0);
        }
        else if (ColNumber == 7)
        {
            GenItem.transform.SetParent(Col7.transform);
            GenItem.transform.position = new Vector3(6, 8, 0);
        }
    }

    public void v_DestroyObject(int ColNumber, int ChildNumber)
    {
        if (IsStopFlag == true)
        {
            if(ColNumber == 1)
                DeletedObject = Col1.transform.GetChild(5 - ChildNumber).gameObject;
            else if(ColNumber == 2)
                DeletedObject = Col2.transform.GetChild(5 - ChildNumber).gameObject;
            else if (ColNumber == 3)
                DeletedObject = Col3.transform.GetChild(5 - ChildNumber).gameObject;
            else if (ColNumber == 4)
                DeletedObject = Col4.transform.GetChild(5 - ChildNumber).gameObject;
            else if (ColNumber == 5)
                DeletedObject = Col5.transform.GetChild(5 - ChildNumber).gameObject;
            else if (ColNumber == 6)
                DeletedObject = Col6.transform.GetChild(5 - ChildNumber).gameObject;

            Debug.Log("ColNumber : " + ColNumber + " ChildNumber : " + ChildNumber);
            if (DeletedObject.gameObject != null)
                Destroy(DeletedObject.gameObject, 3);
            DeletedObject = null;
        }
    }

    public void IsStop()
    {
        if (Col1.transform.childCount == 6 && Col2.transform.childCount == 6 && Col3.transform.childCount == 6 && Col4.transform.childCount == 6 && Col5.transform.childCount == 6 && Col6.transform.childCount == 6)
            IsStopFlag = true;
        else
            IsStopFlag = false;
    }

    public bool ReturnIsStopFlag()
    {
        return IsStopFlag;
    }
}
