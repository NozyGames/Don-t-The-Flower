using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private bool locked = false;
    [SerializeField]
    private float countDown;
    public int x;
    // Update is called once per frame
    private void Start()
    {
        countDown = 4.2f;
        x = 3;
        transform.position = new Vector3(-60, x, -10);
    }
    void Update()
    {
        if (locked == false) transform.position = new Vector3(transform.position.x, x, -10);
        else
        {
            transform.position = new Vector3(pc.transform.position.x, x, -10);
            pc.speed = 5;
            pc.jumpForce = 7;
        }
        if (countDown <= 0) locked = true;
        if (pc.transform.position.x >= -53 && locked == false)
        {
            pc.speed = 0;
            pc.jumpForce = 0;
            countDown -= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, pc.transform.position, Time.deltaTime);
        }
    }
}
