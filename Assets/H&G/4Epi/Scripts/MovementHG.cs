using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHG : MonoBehaviour
{
    private GameObject Gratel;
    private GameObject Hansel;
    private RectTransform GratelPos;
    private RectTransform HanselPos;

    float gratelX = 0.0f;
    float HanselX = 0.0f;

    private GameObject rock1;
    private GameObject rock2;
    private GameObject rock3;

    private Image RockLeft;
    private Image RockMiddle;
    private Image RockRight;
    // Start is called before the first frame update
    void Start(){
        Gratel = GameObject.Find("Gratel");
        Hansel = GameObject.Find("Hansel");

        GratelPos = Gratel.GetComponent<RectTransform>();
        HanselPos = Hansel.GetComponent<RectTransform>();

        gratelX = GratelPos.anchoredPosition.x;
        HanselX = HanselPos.anchoredPosition.x;

        rock1 = GameObject.Find("rock1");
        rock2 = GameObject.Find("rock2");
        rock3 = GameObject.Find("rock3");

        RockLeft = rock1.GetComponent<Image>();
        RockMiddle = rock2.GetComponent<Image>();
        RockRight = rock3.GetComponent<Image>();
        
        // Gratel.GetComponent<RectTransform>().anchoredPosition = new Vector2(110,-290);

        // Hansel.GetComponent<RectTransform>().anchoredPosition = new Vector2(110,-290);
    }

    // Update is called once per frame
    void Update()
    {
       if(GratelPos.anchoredPosition.x > 110.0f){
           gratelX -= 4.0f;
           GratelPos.anchoredPosition = new Vector3(gratelX,-309.0f);
       }
        if(HanselPos.anchoredPosition.x > 490.0f){
           HanselX -= 4.0f;
           HanselPos.anchoredPosition = new Vector3(HanselX,-245.0f);
       }
    }

    // public void ChangeHGRectTransform(){
    //     GratelPos.anchoredPosition = new Vector3(110,-245,0);
    //     HanselPos.anchoredPosition = new Vector3(110,-245,0);
    // }
}
