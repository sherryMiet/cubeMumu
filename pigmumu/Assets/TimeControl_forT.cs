using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //#1

public class TimeControl_forT : MonoBehaviour {
    public Text time;
    public float temp;
    GameBoard m_gameBoard;
    GM gm;
    public GameObject ls;
    void Start()
    {
        m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<GameBoard>();
        gm = GameObject.Find("GM").GetComponent<GM>();
    }

    // Update is called once per frame
    void Update()
    {    
        time.text = gm.stime; //#
        ls.SetActive(gm.lose);
    }

}
