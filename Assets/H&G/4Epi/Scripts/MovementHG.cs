using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHG : MonoBehaviour
{
    public GameObject Gratel;
    public GameObject Hansel;
    public GameObject GratelPos;
    public GameObject HanselPos;
    // Start is called before the first frame update
    void Start(){
        Gratel = GameObject.Find("Gratel");
        Hansel = GameObject.Find("Hansel");
        GratelPos = new Vector2(110,-290);
        HanselPos = new Vector2(110,-290);
        // Gratel.GetComponent<RectTransform>().anchoredPosition = new Vector2(110,-290);

        // Hansel.GetComponent<RectTransform>().anchoredPosition = new Vector2(110,-290);
    }

    // Update is called once per frame
    void Update()
    {
        Gratel.position = Vector3.MoveTowards(gameObject.transform.position, GratelPos.transform.position,0.1f);
    }
}
