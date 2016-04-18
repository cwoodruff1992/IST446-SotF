using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScreenScroll : MonoBehaviour {

    public float speed;
    public float tileSizeX;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {

        float newPosition = Mathf.Repeat(Time.time * speed, tileSizeX);
        transform.position = startPosition + new Vector3(-1,0,0) * newPosition;
    }
}
