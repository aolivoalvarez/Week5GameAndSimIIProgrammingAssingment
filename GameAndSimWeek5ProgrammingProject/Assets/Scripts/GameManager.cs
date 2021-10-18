using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager manager;

    public int playerHealth = 25;
    public int ammo = 10;
    int targets = 3;
    bool playerWon;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if(manager == null)
        {
            manager = this;
        }

        if (manager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            playerWon = false;
            Destroy(Player.gameObject);
            //SceneManager.LoadScene(2);
        }

        if (targets <= 0)
        {
            playerWon = true;
            SceneManager.LoadScene(2);
        }
    }
}
