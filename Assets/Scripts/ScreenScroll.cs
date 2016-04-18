using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScreenScroll : MonoBehaviour {

    public float speed;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        transform.position = startPosition + new Vector3(1, 0, 0) * (Time.time * speed);
    }
}
