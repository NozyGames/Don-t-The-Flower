using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    public SpriteRenderer sr;
    [SerializeField]
    private Sprite[] states;
    [SerializeField]
    public GameObject seedroot;
    [SerializeField]
    private CameraMove cm;
    [SerializeField]
    private loosePlant lp;
    [SerializeField]
    private float temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = 1;
        flowerBound = new Bounds(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
        flowerBound.extents = new Vector2(2, 2);
        waiterTimer = 1;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiter)
        {
            waiterTimer = 1;
            if (point[0].GetComponentInChildren<ParticleSystem>() != null && flowerBound.Contains(point[0].transform.position) && pc.interactInput && point[0].GetComponentInChildren<ParticleSystem>().gameObject.activeSelf == true)
            {
                grow += 1;
                waiter = true;
                if(point[0] != null) point[0].GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            }
            if (point[1].GetComponentInChildren<ParticleSystem>() != null && flowerBound.Contains(point[1].transform.position) && pc.interactInput && point[1].GetComponentInChildren<ParticleSystem>().gameObject.activeSelf == true)
            {
                grow += 1;
                waiter = true;
                if(point[1] != null) point[1].GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            }
            if (point[2].GetComponentInChildren<ParticleSystem>() != null && flowerBound.Contains(point[2].transform.position) && pc.interactInput && point[2].GetComponentInChildren<ParticleSystem>().gameObject.activeSelf == true)
            {
                root += 1;
                waiter = true;
                if(point[2] != null) point[2].GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            }
            if (point[3].GetComponentInChildren<ParticleSystem>() != null && flowerBound.Contains(point[3].transform.position) && pc.interactInput && point[3].GetComponentInChildren<ParticleSystem>().gameObject.activeSelf == true)
            {
                root += 1;
                waiter = true;
                if(point[3] != null) point[3].GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            }
            if (point[4].GetComponentInChildren<ParticleSystem>() != null && flowerBound.Contains(point[4].transform.position) && pc.interactInput && point[4].GetComponentInChildren<ParticleSystem>().gameObject.activeSelf == true)
            {
                root += 1;
                waiter = true;
                if(point[4] != null) point[4].GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            }
        }
        else waiterTimer -= Time.deltaTime;
        if (waiterTimer <= 0) waiter = false;

        if (grow == 1)
        {
            sr.sprite = states[0];
            transform.position = new Vector3(-62.72f, -0.96f, transform.position.z);
        }
        if (grow == 2)
        {
            sr.sprite = states[1];
            lp.loose();
            grow++;
        }
        if (grow == 4)
        {
            sr.sprite = states[5];
            seedroot.gameObject.GetComponent<SpriteRenderer>().sprite = states[6];
            transform.position = new Vector3(-62.98f, 1.23f, transform.position.z);
            seedroot.transform.position = new Vector3(-62.98f, -6.2f, transform.position.z);
        }
        if (root == 1)
        {
            cm.x = 1;
            seedroot.gameObject.GetComponent<SpriteRenderer>().sprite = states[2];
            if (cm.gameObject.transform.position.x <= -59) cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, cm.x, cm.gameObject.transform.position.z);
            else cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, 2, cm.gameObject.transform.position.z);
        }
        if (root == 2)
        {
            cm.x = 0;
            seedroot.gameObject.GetComponent<SpriteRenderer>().sprite = states[3];
            seedroot.transform.position = new Vector3(seedroot.transform.position.x, -2.18f, transform.position.z);
            if (cm.gameObject.transform.position.x <= -59) cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, cm.x, cm.gameObject.transform.position.z);
            else cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, 2, cm.gameObject.transform.position.z);
        }
        if (root == 3)
        {
            cm.x = -2;
            seedroot.gameObject.GetComponent<SpriteRenderer>().sprite = states[4];
            seedroot.transform.position = new Vector3(-62.67f, -6.93f, transform.position.z);
            if (cm.gameObject.transform.position.x <= -59) cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, cm.x, cm.gameObject.transform.position.z);
            else cm.gameObject.transform.position = new Vector3(cm.gameObject.transform.position.x, 2, cm.gameObject.transform.position.z);
            if(pc.grabbedOjb != null) pc.grabbedOjb.gameObject.SetActive(false);
            pc.speed = 0;
            pc.jumpForce = 0;
            temp -= Time.deltaTime;
            if (temp <= 0) pc.sr.sprite = states[7];
            if (temp <= -2)
            {
                pc.gameObject.SetActive(false);
                grow = 4;
            }
        }
    }
}
