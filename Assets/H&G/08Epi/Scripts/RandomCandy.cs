using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCandy : MonoBehaviour
{
    private GameObject mg_RandomItem; 
    int mn_RandomValue;
    public Sprite[] mspa_SpriteImage = new Sprite[7]; 
    private bool mb_checkShow;
    
    void Start(){
        mg_RandomItem = GameObject.Find("RandomImage");
        mn_RandomValue = Random.Range(0,7);
        mb_checkShow = false;
        //this.mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];
    }
    void Update(){
        if(!mb_checkShow){
            mn_RandomValue = Random.Range(0,7);
            mg_RandomItem.GetComponent<SpriteRenderer>().sprite = mspa_SpriteImage[mn_RandomValue];
            mb_checkShow = true;
        }
        
    }
}
