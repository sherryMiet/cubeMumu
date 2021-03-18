using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //#1


public class TimeControl : MonoBehaviour {
    public Text time;
    public float temp;
    GameBoard m_gameBoard;
    // Use this for initialization
    void Start () {
        m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<GameBoard>();
    }
	
	// Update is called once per frame
	void Update () {
        
        TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4

        if (m_gameBoard.CheckBoard() == false)
        {
         temp += Time.deltaTime; //#3
         Savedata.time = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
         time.text = Savedata.time; //#6
        }
        
    }
}
