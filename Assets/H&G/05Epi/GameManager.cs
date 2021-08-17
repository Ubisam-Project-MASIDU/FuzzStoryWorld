using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤 패턴 구현
    #region instance
    public static GameManager instance;
    private void Awake(){
        if(instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    
    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;
    public GameObject nextBtn;


    public void PlayBtnClick(){
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
    }

    public void GameOver(){
        nextBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
    }

    public void nextScene(){
        SceneManager.LoadScene("1_06H&G");
    }
    
}
