using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2Script : MonoBehaviour
{

    [SerializeField]
    Transform[] placements;
    int index = 0;
    Transform currentPlace;

    int speed = 1;
    int distance = 1;

    int tHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlacement();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentPlace.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPlace.position) < distance)
        {
            index++;

            if (index >= placements.Length)
            {
                index = 0;
            }

            UpdatePlacement();
        }

        if (tHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.manager.targets--;
        }
    }

    void UpdatePlacement()
    {
        currentPlace = placements[index];

    }

    private void OnTriggerEnter(Collider other)
    {
        tHealth--;
    }
}
