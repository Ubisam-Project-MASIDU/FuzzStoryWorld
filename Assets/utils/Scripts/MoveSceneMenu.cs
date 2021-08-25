using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneMenu : MonoBehaviour
{
    public string ms_NextSceneName;
    public string ms_PreviousSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveNextScene()
    {
        Debug.Log("씬 이동버튼 클릭");
        SceneManager.LoadScene(ms_NextSceneName);
    }

    public void MovePreviousScene()
    {
        Debug.Log("씬 이동버튼 클릭");
        SceneManager.LoadScene(ms_PreviousSceneName);
    }
}
