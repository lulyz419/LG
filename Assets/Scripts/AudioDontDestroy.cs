using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioDontDestroy : MonoBehaviour { 


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
    
		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}
}
