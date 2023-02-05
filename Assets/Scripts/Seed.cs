using System.Collections;
using System.Collections.Generic;
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
    private Scene current;
    // Start is called before the first frame update
    void Start()
    {
        flowerBound = new Bounds(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
        flowerBound.extents = new Vector2(2, 2);
        waiterTimer = 1;
        current = SceneManager.GetActiveScene();
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

        if (grow == 2) SceneManager.LoadScene(current.buildIndex);
    }
}
