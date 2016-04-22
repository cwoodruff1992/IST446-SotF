using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

    private GameMaster GM;

    void Start() {
        GM = GameObject.Find("_GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        
    }
}
