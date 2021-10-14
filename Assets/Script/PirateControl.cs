using System.Collections;
using UnityEditor;
using UnityEngine;

public class PirateControl : MonoBehaviour
{
    // Movement
    private Rigidbody2D rb;
    public float movementSpeed;
    private float horiz, verti;
    private Vector2 movement;

    private Animator anim;
    GameManager gm;

    public SpriteMask black;

    public GameObject deathEffect;
    public GameObject wonEffect;

    private bool game;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetBool("isIdling", true);

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        game = true;
    }

    private void Update()
    {
        if (!gm.IsGamePause())
        {
            if (game)
            {
                horiz = Input.GetAxisRaw("Horizontal");
                verti = Input.GetAxisRaw("Vertical");
            }
           
            movement = new Vector2(horiz, verti) * movementSpeed;
            if (horiz < -0.5f || horiz > 0.5f || verti < -0.5f || verti > 0.5f)
            {
                anim.SetBool("isMoving", true);
                anim.SetBool("isIdling", false);
            }
            else
            {
                anim.SetBool("isMoving", false);
                anim.SetBool("isIdling", true);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && game)
        {
            // Ded
            foreach(Collider2D coll in GetComponents<Collider2D>())
            {
                coll.enabled = false;
            }
            foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = false;
            }
            game = false;
            horiz = verti = 0f;
            black.enabled = true;
            StartCoroutine(deathScene(collision.gameObject));
        }
        else if (collision.gameObject.CompareTag("Key") && game)
        {
            foreach (Collider2D coll in GetComponents<Collider2D>())
            {
                coll.enabled = false;
            }
            game = false;
            horiz = verti = 0f;
            black.enabled = true;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(wonScene());
        }
    }

    IEnumerator deathScene(GameObject coll)
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        Instantiate(coll, transform.position, Quaternion.identity);
        

        yield return new WaitForSeconds(2f);
        Destroy(effect);
        gm.EndGame(false);

    }

    IEnumerator wonScene()
    {
        GameObject effect = Instantiate(wonEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        gm.EndGame(true);
    }
}
