using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
    private Vector2 startPos;
    private Vector2 endPos;
    private float speed = 1.0f;

	void Start () {
        startPos.x = transform.position.x;
        startPos.y = transform.position.y;
        endPos.y = startPos.y + 2;
        endPos.x = transform.position.x;
	}

	void FixedUpdate () {

        transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1.0f));
	}
}
