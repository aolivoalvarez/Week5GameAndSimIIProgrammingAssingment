using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public static GameManager manager;

    public int playerHealth = 25;
    public int ammo = 50;
    public int targets = 3;

    public GameObject Player;

    [SerializeField]
    Image aBar;

    [SerializeField]
    Image hBar;

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

        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerHealth <= 0) || (targets <= 0))
        {
            Destroy(Player.gameObject);
            SceneManager.LoadScene(2);
        }

        UpdateHUD();
    }

    void UpdateHUD()
    {
        aBar.fillAmount = ammo / 50.0f;
        hBar.fillAmount = playerHealth / 25.0f;
    }
}
