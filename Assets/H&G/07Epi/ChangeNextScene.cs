using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeNextScene : MonoBehaviour {
    void OnTriggerEnter(Collider cCollider) {
        if (cCollider.tag == "HAG")
            Invoke("changeNextScene", 1f);
    }
}
