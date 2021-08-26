using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour{
    public void First(){
        StartCoroutine(ChangeNextScene("0_01LanguageSelect"));
    }

    IEnumerator ChangeNextScene(string name){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }

/* 추후 동화 업데이트를 하게 된다면 사용 예정 
    public void Second(){
        //Support.SetActive(true);
    }
    public void Third(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Fourth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Fifth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Sixth(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Seventh(){
        //SceneManager.LoadScene("New Scene");
    }
    public void Eighth(){
        //SceneManager.LoadScene("New Scene");
    }
*/

}
