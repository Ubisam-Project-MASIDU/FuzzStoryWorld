using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Epi8_Game : MonoBehaviour
{
    private GameObject Gratel;
    private GameObject Hansel;
    private GameObject Target;
    private Vector3 Position;

    VoiceManager vm;

    // Start is called before the first frame update
    void Start()
    {
        Gratel = GameObject.Find("Gratel");
        Hansel = GameObject.Find("Hansel");
        Target = GameObject.Find("Target");
        Position = Target.transform.position;
        // Position = new Vector3(6.4f,5.2f,-14.6f);

        this.vm = GameObject.Find("VoiceManager").GetComponent<VoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ChangePosition(Gratel,Position,0.05f);
        // ChangePosition(Hansel,Position,0.05f);
        
        if (vm.mb_checkSceneReady){                                                 //tts 사용전 작업이 다 준비되면
            ChangePosition(Gratel,Position,0.05f);
            ChangePosition(Hansel,Position,0.05f);
        
        }
    }

    //go_Object가  v3_Pos위치로 f_Velocity 속력으로 이동하는 함수 
    void ChangePosition(GameObject go_Object,Vector3 v3_Pos,float f_Velocity){
        go_Object.transform.position = Vector3.MoveTowards(go_Object.transform.position,v3_Pos,f_Velocity);
    }
}
