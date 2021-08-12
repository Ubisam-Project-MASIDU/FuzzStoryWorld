using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEffect : MonoBehaviour
{
    public GameObject mg_RepresentChar;
    public GameObject mg_SetEffect;
    void OnTriggerEnter(Collider cCollider) {
        Destroy(mg_RepresentChar);
        this.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("loadNextScene", 1f);
    }
    void loadNextScene() {
        SceneManager.LoadScene("1_01H&G");
    }
}
