using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> CoinPool = new List<GameObject>();
    public GameObject[] Coins;
    public int objCnt = 1;
    void Awake(){
        for(int i = 0; i < Coins.Length; i++){
            for (int q = 0; q < objCnt; q++){
                CoinPool.Add(CreateObj(Coins[i], transform));
            }
        }
    }

    private void Start(){
        GameManager.instance.onPlay += PlayGame; 
    }
    void PlayGame(){
        StartCoroutine(CreateCoin()); 
    }
    IEnumerator CreateCoin(){
        while(GameManager.instance.isPlay){
            CoinPool[DeativeCoin()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f,3f));
        }
    }

    int DeativeCoin(){
        List<int>num = new List<int>();
        for (int i = 0; i < CoinPool.Count; i++){
            if(!CoinPool[i].activeSelf){
                num.Add(i);
            }
        }
        int x = 0;
        if(num.Count > 0){
            x = num[Random.Range(0,num.Count)];
        }
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent){
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
