using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System; //#1

public class TimeConForMu : NetworkBehaviour
{
    [SyncVar]
    public int count;
    public float temp;
    GameBoard m_gameBoard;
    GM gm;
    [SyncVar]
    public string stime;



    // Use this for initialization

    void Start()
    {
        m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<GameBoard>();
        gm = GameObject.Find("GM").GetComponent<GM>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }


        // handle player input for movement
        //print(a);

}
  
}
