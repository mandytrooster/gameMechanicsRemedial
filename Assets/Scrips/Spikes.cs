using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private Vector2 startPos;
    private Vector2 endPos;
    private float speed = 2.0f;

    void Start () {
        startPos.x = transform.position.x;
        startPos.y = transform.position.y;
        endPos.y = startPos.y + 0.4f;
        endPos.x = transform.position.x;
        transform.position = new Vector3(startPos.x, startPos.y, 0.1f);
    }
	
	void Update () {
        transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
