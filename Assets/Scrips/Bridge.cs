using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    private SpriteRenderer sr;
    public ButtonPressed button;

    void Start () {
        sr  = gameObject.GetComponent<SpriteRenderer>();

        sr.enabled = false;
    }
	void Update () {

        if (button.GetComponent<ButtonPressed>().buttonPressed == true)
        {
            sr.enabled = true;
        }
	}
}
