using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Animator starshipLanding;

	// Use this for initialization
	void Start () {
        OnReset();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// OnReset is triggered by the speech manager.
    /// </summary>
    void OnReset ()
    {
        //starshipLanding.Play("StarshipLanding");
    }
}
