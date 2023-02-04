using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public int speed = 5;
    public int jumpForce = 5;
    [SerializeField]
    private bool onGround;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private GameObject grabbedOjb;
    [SerializeField]
    private bool isGrabbed = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int lookat;
    private int rotate;
    [SerializeField]
    private float rotemp;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime, 0);

        if (horizontalInput > 0)
        {
            sr.flipX = false;
            lookat = 1;
            rotate = -20;
        }
        if (horizontalInput < 0)
        {
            sr.flipX = true;
            lookat = -1;
            rotate = 20;
        }

        bool jumpInput = Input.GetButton("Jumping");
        if (jumpInput && onGround)
        {
            onGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        bool grabInput = Input.GetButtonDown("Grab");
        if (grabInput)
        {
            if (isGrabbed)
            {
                grabbedOjb = null;
                isGrabbed = false;
            }
            else Grab();
        }
        if (isGrabbed) grabbedOjb.transform.position = new Vector3(transform.position.x + lookat, transform.position.y + 1, transform.position.z);

        bool interactInput = Input.GetButtonDown("Interact");
        if (interactInput) Interact();

#region Interact
        rotemp -= Time.deltaTime;
        if (rotemp <= 0 && grabbedOjb != null) grabbedOjb.transform.Rotate(0, 0, 0);
#endregion
    }

    private void Grab()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * lookat, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), lookat, layerMask);
        if (hit)
        {
            grabbedOjb = hit.collider.gameObject;
            isGrabbed = true;
        }
    }

    private void Interact()
    {
        string goName = grabbedOjb.name;
        switch (goName)
        {
            case "Arrosoire":
                rotemp = 1;
                bool temp2 = true;
                if (temp2)
                {
                    grabbedOjb.transform.Rotate(0, 0, rotate);
                    temp2 = false;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) onGround = true;
    }
}
