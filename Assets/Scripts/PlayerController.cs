using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D myRigidBody;
    public float playerJumpForce = 500f;
    private Animator myAnim;

    // Use this for initialization
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Jump"))
        {
            myRigidBody.AddForce(transform.up * playerJumpForce);
        }

        myAnim.SetFloat("vVelocity", myRigidBody.velocity.y);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            SceneManager.LoadScene("runner");
        }
        
    }
}
