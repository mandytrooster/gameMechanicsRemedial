using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour {

    private Key keys;
    private bool pickedUp;

    void Start () {
        keys = gameObject.GetComponent<Key>();
    }
	
	void Update () {
		
     
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (GameObject.Find("keyYellow").GetComponent<Key>().keyPickedUp == true)
            {
                Debug.Log("key worked");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } 
        }
    }
}
