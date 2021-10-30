using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.manager.playerHealth -= 5;

        Debug.Log(GameManager.manager.playerHealth);
    }
}
