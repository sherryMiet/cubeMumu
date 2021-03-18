using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoverControl : MonoBehaviour {
    GM gm;
   public GameObject cover;
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GM").GetComponent<GM>();
    }
	
	// Update is called once per frame
	void Update () {
        cover.SetActive(gm.coveropen);
	}
}
