using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed = 10;
    public float acceleration = 1;

	// Use this for initialization
	void Start () {
        InvokeRepeating("IncreasedSpeed", 20f, 20f);
	}
	
	// Update is called once per frame
	void Update ()
    { 
        transform.position += Vector3.left * speed * Time.deltaTime;
                
    }

    public void IncreaseSpeed()
    {
        speed += acceleration;
    }
    
   //TODO me he quedado aquí, hay que ver si funciona IncreaseSpeed y en caso de uqe si toquetearlo.       
}
