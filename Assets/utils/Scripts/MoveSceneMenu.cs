using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveSceneMenu : MonoBehaviour
{
    public string ms_NextSceneName;
    public string ms_PreviousSceneName;
    public string ms_HomeSceneName;

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
        Debug.Log("다음 씬으로 이동");
        SceneManager.LoadScene(ms_NextSceneName);
    }

    public void MovePreviousScene()
    {
        Debug.Log("이전 씬으로 이동");
        SceneManager.LoadScene(ms_PreviousSceneName);
    }

    public void MoveHomeScene()
    {
        Debug.Log("홈으로 이동");
        SceneManager.LoadScene(ms_HomeSceneName);
    }
}
