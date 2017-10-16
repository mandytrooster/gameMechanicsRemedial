using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health;
    private int maxHealth = 10;
    public Texture2D fullHeart, halfHeart, emptyHeart;
    private Texture2D heart1, heart2, heart3, heart4, heart5;
    public Texture2D[] hearts;
    public Vector2 healthPos;

    public static bool isDead;

	void Start () {

        health = maxHealth;

        heart1 = fullHeart;
        heart2 = fullHeart;
        heart3 = fullHeart;
        heart4 = fullHeart;
        heart5 = fullHeart;

        hearts = new Texture2D[5];

        for (int i = 0; i < hearts.Length; i++) {
            hearts[i] = fullHeart;
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if(gameObject.transform.position.y < -7)
        {
            gameOver();
        }

        if (health == maxHealth)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = fullHeart;
            heart4 = fullHeart;
            heart5 = fullHeart;
        }

        if (health == maxHealth -1)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = fullHeart;
            heart4 = fullHeart;
            heart5 = halfHeart;
        }

        if (health == maxHealth - 2)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = fullHeart;
            heart4 = fullHeart;
            heart5 = emptyHeart;
        }

        if (health == maxHealth - 3)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = fullHeart;
            heart4 = halfHeart;
            heart5 = emptyHeart;
        }

        if (health == maxHealth - 4)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = fullHeart; 
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }

        if (health == maxHealth - 5)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = halfHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }

        if (health == maxHealth - 6)
        {
            heart1 = fullHeart;
            heart2 = fullHeart;
            heart3 = emptyHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }

        if (health == maxHealth - 7)
        {
            heart1 = fullHeart;
            heart2 = halfHeart;
            heart3 = emptyHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }
        if (health == maxHealth - 8)
        {
            heart1 = fullHeart;
            heart2 = emptyHeart;
            heart3 = emptyHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }
        if (health == maxHealth - 9)
        {
            heart1 = halfHeart;
            heart2 = emptyHeart;
            heart3 = emptyHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
        }

        if (health <= 0)
        {
            heart1 = emptyHeart;
            heart2 = emptyHeart;
            heart3 = emptyHeart;
            heart4 = emptyHeart;
            heart5 = emptyHeart;
            gameOver();
        }

		if (EnemySpawner.enemyCounter >= 3) 
		{
			health++;
			EnemySpawner.enemyCounter = 0;
		}
    }

    void gameOver()
    {
        isDead = true;
        SceneManager.LoadScene("startscreen");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            health--;
        }

		if (collision.gameObject.tag == "spikes")
		{
			health--;
		}

        if (collision.gameObject.tag == "heart")
        {
            health += 2;

            Destroy(GameObject.FindWithTag("heart"));
        }
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy1")
        {
            health--;
        }
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(healthPos.x, healthPos.y, 250, 50));
        GUI.DrawTexture(new Rect(0, 0, 25, 25), heart1, ScaleMode.ScaleToFit);
        GUI.DrawTexture(new Rect(25, 0, 25, 25), heart2, ScaleMode.ScaleToFit);
        GUI.DrawTexture(new Rect(50, 0, 25, 25), heart3, ScaleMode.ScaleToFit);
        GUI.DrawTexture(new Rect(75, 0, 25, 25), heart4, ScaleMode.ScaleToFit);
        GUI.DrawTexture(new Rect(100, 0, 25, 25), heart5, ScaleMode.ScaleToFit);
        GUI.EndGroup();
    }

}
