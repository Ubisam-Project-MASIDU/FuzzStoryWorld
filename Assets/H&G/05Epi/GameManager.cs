using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public delegate void OnPlay();
    public OnPlay onPlay;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;

    public void PlayBtnClick(){
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke();
    }
    
}
