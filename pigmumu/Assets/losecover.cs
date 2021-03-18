using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losecover : MonoBehaviour {
    GM gm;
    public GameObject cover;
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GM").GetComponent<GM>();
    }
	
	// Update is called once per frame
	void Update () {

        cover.SetActive(gm.lose);
    }
   

}
