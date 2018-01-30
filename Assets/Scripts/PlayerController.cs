using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D myRigidBody;
    public float playerJumpForce = 500f;
    private Animator myAnim;
    private float deathTime = -1;
    private Collider2D myCollider;
    public Text scoreText;
    private float startTime;
    private int jumpsLeft = 2;
    public AudioSource jumpSfx;
    public AudioSource deathSfx;
    public AudioSource collectSfx;
    public GameObject sexy;
    public GameObject sexy2;



    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("title");
        }

        if (deathTime == -1)
        {
            //PLAYER JUMP

            if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
            {

                //PLAYER JUMP LESS FORCE ON 2ND JUMP

                if (myRigidBody.velocity.y < 0)
                {
                    myRigidBody.velocity = Vector2.zero;
                }
                else
                {
                    myRigidBody.AddForce(transform.up * playerJumpForce * 0.75f);
                }
                                
                if (jumpsLeft == 1)
                {
                    myRigidBody.AddForce(transform.up * playerJumpForce);
                }

                myRigidBody.AddForce(transform.up * playerJumpForce);
                jumpsLeft--;

                jumpSfx.Play();
            }

            myAnim.SetFloat("vVelocity", myRigidBody.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");
        }
        else
        {
            //RELOAD LEVEL

            if (Time.time > deathTime + 2)
            {
                SceneManager.LoadScene("runner");
            }

        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //PLAYER DEATH ON COLLISION WITH ENEMY

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>() )
            {
                moveLefter.enabled = false;
            }

            deathTime = Time.time;
            myAnim.SetBool("death", true);
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * playerJumpForce);
            myCollider.enabled = false;

            deathSfx.Play();

        }

        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2;
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Collectible"))
            
        {
            Debug.Log("eh que he cogido a la tia");
            collectSfx.Play();
            Destroy(gameObject.GetComponent("sexy"));
            Destroy(gameObject.GetComponent("sexy2"));
           if (myAnim.GetCurrentAnimatorStateInfo (0).IsName("run"))
            {
                myAnim.SetTrigger("getSexy");
            }
        
        }
    }
}
