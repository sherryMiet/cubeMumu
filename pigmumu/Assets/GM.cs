using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System; //#1

public class GM : NetworkBehaviour
{
    public List<player> allPlayer = new List<player>();
    public int count;
    public float temp;
    public string stime;
    public bool lose = false;
    public GameObject panel;
    public CoverControl cc;
    public GameObject loseCover;
    public bool coveropen;
    [SyncVar]
    public bool win;
    public void Login(player player)
    { 
        allPlayer.Add(player);
         count = allPlayer.Count;
        player.RpcSetPlayer(allPlayer.Count);
    }
    public void WhoWin(bool getwin)
    {
            allPlayer[1].RpcSetTimeStop(win);
            allPlayer[0].RpcSetTimeStop(win);
    }
    public void SetLose()
    {
        win = true;
        loseCover.SetActive(true);
        lose = true;

    }
    void Update()
    {
    if (allPlayer.Count == 2)
        {
            coveropen = false;
            TimeSpan timeSpan = TimeSpan.FromSeconds(temp); //#4
            if (win==false)
                {
                temp += Time.deltaTime; //#3
                stime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
                }
            else
            {
                stime = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); //#5
            }
           
        }
        else
        {
            stime = "00:00:00"; //#5
            coveropen = true;
        }

    
    }

}
