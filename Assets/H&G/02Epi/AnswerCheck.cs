using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerCheck : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnswerCount()
    {
        count++;
        Debug.Log(count);

        if (count == 9)
        {
            Invoke("changeNextScene", 2f);
        }
    }
    void changeNextScene()
    {
        SceneManager.LoadScene("1_03H&G");
    }
}