using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
    public Sprite button;
    public Sprite pressed;

    public bool buttonPressed = false;

	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = button;
    }
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerJump")
        {
            this.GetComponent<SpriteRenderer>().sprite = pressed;
            buttonPressed = true;
        }
    }
}
