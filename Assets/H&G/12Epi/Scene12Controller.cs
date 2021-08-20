using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene12Controller : MonoBehaviour {

    private int mn_NumCharacter = 2;
    private Status mst_HAGStatus;
    public Status HAGStatus {
        get {
            return mst_HAGStatus;
        }
    }
    private Status mst_WitchStatus;
    public Status WitchStatus {
        get {
            return mst_WitchStatus;
        }
    }

    void Start() {
        mst_HAGStatus = new Status(20f, 2f, 10f, Status.Character.HAG);
        mst_WitchStatus = new Status(Status.Character.Witch);
    }

    void Update() {
        if (mst_HAGStatus.HP < 0) {
            // game over..
        }
        if (mst_WitchStatus.HP < 0) {
            // game clear..
        }
    }
}
