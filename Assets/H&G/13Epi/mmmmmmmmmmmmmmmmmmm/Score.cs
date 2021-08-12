using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject mg_Score;

    double score = 0;

    // Start is called before the first frame update
    void Start()
    {
        mg_Score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        mg_Score.GetComponent<Text>().text = "Á¡¼ö : " + score;
    }

    public void v_IncreaseScore()
    {
        score = score + 10;
    }
}
