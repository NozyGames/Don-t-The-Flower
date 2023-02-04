using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    private GameObject[] point;
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private Bounds flowerBound;
    [SerializeField]
    private int grow;
    [SerializeField]
    private int root;
    [SerializeField]
    private bool waiter;
    [SerializeField]
    private float waiterTimer;
    // Start is called before the first frame update
    void Start()
    {
        flowerBound = new Bounds(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
        flowerBound.extents = new Vector2(2, 2);
        waiterTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiter)
        {
            waiterTimer = 1;
            if (point[0] != null && flowerBound.Contains(point[0].transform.position) && pc.interactInput || point[1] != null && flowerBound.Contains(point[1].transform.position) && pc.interactInput && pc.grabInput)
            {
                grow += 1;
                waiter = true;
            }
            if (point[2] != null && flowerBound.Contains(point[2].transform.position) && pc.interactInput && pc.grabInput || point[3] != null && flowerBound.Contains(point[3].transform.position) && pc.interactInput && pc.grabInput || point[4] != null && flowerBound.Contains(point[4].transform.position) && pc.interactInput && pc.grabInput)
            {
                root += 1;
                waiter = true;
            }
        }
        else waiterTimer -= Time.deltaTime;
        if (waiterTimer <= 0) waiter = false;
    }
}
