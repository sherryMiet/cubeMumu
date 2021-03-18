using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectLevel : MonoBehaviour {
   
    public void One()
    {
       Savedata.size = 3;
    
    }
    public void two()
    {
        Savedata.size = 4;
    }
    public void three()
    {
        Savedata.size = 5;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
