using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    float bulletSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire1")) && (GameManager.manager.ammo > 0))
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed;
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            b.GetComponent<Rigidbody>().velocity = bulletDirection;

            GameManager.manager.ammo--;
            
        }
    }
}
