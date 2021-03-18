using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class member : MonoBehaviour {

    public Text member_txt;
	// Use this for initialization
	void Start () {
		if (Savedata.id != "")
        {
            member_txt.text = "MID: "+Savedata.id;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
