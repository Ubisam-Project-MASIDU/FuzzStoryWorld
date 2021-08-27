using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoForest : MonoBehaviour
{
    //public Camera MainCamera;
    private GameObject Hansel;
    private GameObject Gretel;
    private GameObject Witch;
 
    // Start is called before the first frame update
    void Start()
    {
        Hansel = GameObject.Find("hansel");
        Gretel = GameObject.Find("gretel");
        Witch = GameObject.Find("witch");
        //Hansel.transform.position = new Vector3(-7.2f, -2.47f, 0);
        //Gretel.transform.position = new Vector3(-9.29f, -2.47f, 0);

    }
    void LateUpdate()
    {
        //transform.position = new Vector3(AT.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Hansel.transform.position = Vector3.MoveTowards(Hansel.transform.position, new Vector3(90, -4f , -6), 0.08f);
        Gretel.transform.position = Vector3.MoveTowards(Gretel.transform.position, new Vector3(90, -4f, -6), 0.08f);
        //Witch.transform.position = Vector3.MoveTowards(Witch.transform.position, new Vector3(15, -2.47f, 0), 0.03f);
        //transform.position = new Vector3(AT.position.x, transform.position.y, transform.position.z);

    }

    private void FollwPlayer()
    {
        //Vector3 position = Player.position;
        //position.Set(Player.position.x, transform.position.y, transform.position.z);
        //MainCamera.transform.SetPositionAndRotation(position, Quaternion.identity);
    }
}
