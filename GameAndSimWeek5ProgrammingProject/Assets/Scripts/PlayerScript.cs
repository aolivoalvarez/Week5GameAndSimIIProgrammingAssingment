using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 5;
    float jumpForce = 5;

    bool onGround;

    Rigidbody rb;

    [SerializeField]
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * playerSpeed) + (camRight * h * playerSpeed);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        //rb.velocity = new Vector3(h * playerSpeed, rb.velocity.y, v * playerSpeed);

        Ray groundSearch = new Ray(transform.position, Vector3.down);

        Debug.DrawLine(groundSearch.origin, groundSearch.origin + (Vector3.down * 5));

        RaycastHit gHit;

        if (Physics.Raycast(groundSearch, out gHit, 10))
        {
            if (gHit.transform != null)
            {
                if (gHit.transform.GetComponent<GroundScript>() != null)
                {
                    onGround = true;
                }

                else
                {
                    onGround = false;
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }

    void Jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

}
