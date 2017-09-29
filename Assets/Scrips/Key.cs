using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour {

    private SpriteRenderer sr;
    public bool keyPickedUp = false;
    public bool visible;
    public Texture2D keyYellow, keyEmpty;
    public Texture2D key;
    public Vector2 keyPos;

    private void Start()
    {
        key = keyEmpty;
        keyPickedUp = false;

        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.enabled = true;
    }

    private void Update()
    {
        if (keyPickedUp == true)
        {
            key = keyYellow;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            keyPickedUp = true;
        }

        if (keyPickedUp == true)
        {
            sr.enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(keyPos.x, keyPos.y, 250, 50));
        GUI.DrawTexture(new Rect(135, 0, 25, 25), key, ScaleMode.ScaleToFit);
        GUI.EndGroup();
    }

}
