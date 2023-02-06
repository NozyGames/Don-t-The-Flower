using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loosePlant : MonoBehaviour
{
    [SerializeField]
    private GameObject toilettes;
    private SpriteRenderer toilettes_sprite;
    private SpriteRenderer shrek_sprite;
    [SerializeField]
    private Sprite[] spriteChiottes;
    [SerializeField]
    private Sprite[] spriteShrek;
    [SerializeField]
    private Seed seed;
    [SerializeField]
    private PlayerController pc;
    private Scene current;
    [SerializeField]
    private float temp;
    private bool locked;

    public float tempsDeMarcheDeShrek = 10;

    float beginTime;
    float tempsEcoule;
    int nTours;
    bool countTime;
    bool hasToMove;

    private AudioSource grr;
    public AudioClip gre1;
    public AudioClip gre2;
    public AudioClip gre3;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        locked = false;
        temp = 1.5f;
        current = SceneManager.GetActiveScene();
        toilettes_sprite = toilettes.GetComponent<SpriteRenderer>();
        shrek_sprite= gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        hasToMove = false;
        grr=GetComponent<AudioSource>();
    } 

    // Update is called once per frame
    void Update()
    {
        if (locked) temp -= Time.deltaTime;
        if (temp <= 0) SceneManager.LoadScene(current.buildIndex);
        if (hasToMove)
        {
            transform.position = transform.position + new Vector3(3 * Time.deltaTime, 0, 0);
        }
    }

    public void loose()
    {
        beginTime = Time.fixedTime;
        countTime = true;
        nTours = 0;
        pc.speed = 0;
        pc.jumpForce = 0;
    }

    private void FixedUpdate()
    {
        if (countTime)
        {
            tempsEcoule = Time.fixedTime - beginTime;

            if (nTours == 0)
            {
                grr.PlayOneShot(gre2, 1);
                nTours++;
            }

            if(tempsEcoule >= 2 && nTours == 1)
            {
                toilettes_sprite.sprite = spriteChiottes[1];
                shrek_sprite.enabled = true;
                nTours++;
            }

            if (tempsEcoule >= 4 && nTours == 2)
            {
                toilettes_sprite.sprite = spriteChiottes[0];
                shrek_sprite.sprite = spriteShrek[1];
                nTours++;
            }
            if (tempsEcoule >= 5 && nTours == 3)
            { 
                hasToMove = true;
                anim.SetBool("Marche", true);
                nTours++;
            }
            if (tempsEcoule >= 6+tempsDeMarcheDeShrek && nTours == 4)
            {
                hasToMove = false;
                anim.SetBool("Marche", false);
                nTours++;
            }
            if (tempsEcoule >= 7 + tempsDeMarcheDeShrek && nTours == 5)
            {
                shrek_sprite.sprite = spriteShrek[2];//se baisse
                grr.PlayOneShot(gre3, 1); grr.PlayOneShot(gre3, 1); grr.PlayOneShot(gre3, 1);
                nTours++;
            }
            if (tempsEcoule >= 9 + tempsDeMarcheDeShrek && nTours == 6)
            {
                shrek_sprite.sprite = spriteShrek[3];//arrache
                nTours++;
                countTime = false;
                seed.transform.position = new Vector3(-61.1f, 0.19f, transform.position.z);
                seed.sr.sortingOrder = 0;
                if (seed.seedroot.gameObject.activeSelf == true) seed.seedroot.gameObject.SetActive(false);
                locked = true;
            }
        }
    }
}
