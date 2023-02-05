using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#region Variables
    private Transform player;
    private Seed s;
    public int speed = 5;
    public int jumpForce = 5;
    public bool interactInput;
    public bool grabInput;
    private bool onGround;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private GameObject grabbedOjb;
    private bool isGrabbed = false;
    private float rotemp;
    [SerializeField]
    public ParticleSystem[] ps;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float lookat;
    private int rotate;
    private bool playing;
#endregion

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
            lookat = 1.1f;
            rotate = -20;
        }
        if (horizontalInput < 0)
        {
            sr.flipX = true;
            lookat = -1.1f;
            rotate = 20;
        }

        bool jumpInput = Input.GetButton("Jumping");
        if (jumpInput && onGround)
        {
            onGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        grabInput = Input.GetButtonDown("Grab");
        interactInput = Input.GetButton("Interact");
        if (grabInput && !interactInput)
        {
            if (isGrabbed)
            {
                grabbedOjb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedOjb = null;
                isGrabbed = false;
            }
            else Grab();
        }
        if (isGrabbed) grabbedOjb.transform.position = new Vector3(transform.position.x + lookat, transform.position.y + 0.6f, transform.position.z);
        
        if (interactInput && grabbedOjb != null) Interact();
        if (Input.GetButtonUp("Interact") && grabbedOjb != null)
        {
            grabbedOjb.transform.rotation = new Quaternion(0, 0, 0, 0);
            foreach (ParticleSystem particules in ps) particules.Stop(true);
            playing = false;
        }
        foreach (ParticleSystem particules in ps) particules.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    private void Grab()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * lookat, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), lookat, layerMask);
        if (hit)
        {
            grabbedOjb = hit.collider.gameObject;
            grabbedOjb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            isGrabbed = true;
        }
    }

    private void Interact()
    {
        string goName = grabbedOjb.name;
        switch (goName)
        {
            case "Watercan":
                if (!playing)
                {
                    ps[0].Play(true);
                    playing = true;
                }
                grabbedOjb.transform.rotation = Quaternion.Euler(0, 0, rotate);
                break;
            case "Fertilizer":
                if (!playing)
                {
                    ps[1].Play(true);
                    playing = true;
                }
                grabbedOjb.transform.rotation = Quaternion.Euler(0, 0, rotate);
                break;
            case "Nuclear":
                if (!playing)
                {
                    ps[2].Play(true);
                    playing = true;
                }
                grabbedOjb.transform.rotation = Quaternion.Euler(0, 0, rotate);
                break;
            case "Cigarette":
                if (!playing)
                {
                    ps[3].Play(true);
                    playing = true;
                }
                grabbedOjb.transform.rotation = Quaternion.Euler(0, 0, rotate);
                break;
            case "Jerrycan":
                if (!playing)
                {
                    ps[4].Play(true);
                    playing = true;
                }
                grabbedOjb.transform.rotation = Quaternion.Euler(0, 0, rotate);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) onGround = true;
    }
}
