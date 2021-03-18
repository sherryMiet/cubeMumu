using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class player : NetworkBehaviour
{
    GM gm;
    GameBoard m_gameBoard;

    public int Getid;
    [SyncVar]
    public bool win;
    void Start()
    {
       // if (isServer)
     //   {
            gm = GameObject.Find("GM").GetComponent<GM>();
            m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<GameBoard>();
        gm.Login(this);
      //  }
    }
    private void Update()
    {
        win = m_gameBoard.CheckBoard();
        if(win == true)
        {

           CmdSetWin();
        }
        print(win);
        print(Getid);
    }

    [ClientRpc]
    public void RpcSetPlayer(int id)
    {
        if (isLocalPlayer)
        {
            switch (id)
            {
                case 1:
                    print("1");
                    break;
                case 2:
                    print("2");
                    break;
            }
        }
    }
    [ClientRpc]
    public void RpcSetTimeStop(bool win)
    {
        if (isLocalPlayer)
        {
            gm.SetLose();

        }
    }
    [Command]
    public void CmdSetWin()
    {
      
          gm.WhoWin(true);

       
    }
   
}