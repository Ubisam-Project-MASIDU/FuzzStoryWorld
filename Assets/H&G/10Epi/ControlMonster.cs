using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMonster : MonoBehaviour
{
    int num = 6;

    // Update is called once per frame
    void Update()
    {
        if(num<=0){
            SceneManager.LoadScene("1_11H&G");
        }
    }

    public void Delete(){
        num--;

    }
}
