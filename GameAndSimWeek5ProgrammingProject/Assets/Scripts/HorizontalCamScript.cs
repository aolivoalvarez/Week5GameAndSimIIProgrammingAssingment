using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCamScript : MonoBehaviour
{
    float rotSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, x * rotSpeed, 0));
       
    }
}
