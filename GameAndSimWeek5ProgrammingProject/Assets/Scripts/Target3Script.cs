using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target3Script : MonoBehaviour

{
    [SerializeField]
    Transform placement;

    float speed = 1;

    int tHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, placement.position, speed * Time.deltaTime);

        if (tHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.manager.targets--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tHealth--;
    }
}
