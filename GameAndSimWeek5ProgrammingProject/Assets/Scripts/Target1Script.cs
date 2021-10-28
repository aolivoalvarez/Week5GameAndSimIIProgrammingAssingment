using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1Script : MonoBehaviour

{
    [SerializeField]
    Transform[] placements;
    int index = 0;
    Transform currentPlace;

    int speed = 1;
    int distance = 1;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlacement();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentPlace.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPlace.position) < distance)
        {
            index++;

            if (index >= placements.Length)
            {
                index = 0;
            }

            UpdatePlacement();
        }
    }

    void UpdatePlacement()
    {
        currentPlace = placements[index];

    }
}
