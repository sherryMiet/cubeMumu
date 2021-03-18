
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections.Generic;
using UnityEngine.Networking.Types;

public class NetworkUI : NetworkManager
{
    public Text text;
    private NetworkMatch networkMatch;
    void Start()
    {
        NetworkManager.singleton.StartMatchMaker();

    }
    //void Update()
    //{
    //    if ( networkMatch == null )
    //    {
    //        var nm = GetComponent < NetworkMatch > ();
    //        if (nm != null)
    //        {
    //            networkMatch = nm as NetworkMatch;
    //            UnityEngine.Networking.Types.AppID appid = (UnityEngine.Networking.Types.AppID)8242053;
    //            networkMatch.SetProgramAppID(appid);
    //        }
    //    }
    //}
    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void SetIPAddress()
    {
        string IP = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = IP;

    }

    public void JoinGame()
    {
        SetPort();
        SetIPAddress();
        NetworkManager.singleton.StartClient();
    }

    //call this method to request a match to be created on the server
    public void CreateInternetMatch(string matchName)
    {
        NetworkManager.singleton.matchMaker.CreateMatch(matchName, 2, true, "", "", "", 0, 0, OnInternetMatchCreate);
       
    }

    //this method is called when your request for creating a match is returned
    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            //Debug.Log("Create match succeeded");

            MatchInfo hostInfo = matchInfo;
            NetworkServer.Listen(hostInfo, 9000);

            NetworkManager.singleton.StartHost(hostInfo);
        }
        else
        {
            Debug.LogError("Create match failed");
            text.text = "創建房間失敗";
        }
    }
    //call this method to find a match through the matchmaker
    public void FindInternetMatch(string matchName)
    {
        NetworkManager.singleton.matchMaker.ListMatches(0, 10, matchName, true, 0, 0, OnInternetMatchList);
    }

    //this method is called when a list of matches is returned
    private void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (success)
        {
            if (matches.Count != 0)
            {
                //Debug.Log("A list of matches was returned");

                //join the last server (just in case there are two...)
                NetworkManager.singleton.matchMaker.JoinMatch(matches[matches.Count - 1].networkId, "", "", "", 0, 0, OnJoinInternetMatch);
            }
            else
            {
                Debug.Log("No matches in requested room!");
                text.text = "找不到相符合的房間";
            }
        }
        else
        {
            Debug.LogError("Couldn't connect to match maker");
            text.text = "無法連接!";
        }
    }

    //this method is called when your request to join a match is returned
    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            //Debug.Log("Able to join a match");

            MatchInfo hostInfo = matchInfo;
            NetworkManager.singleton.StartClient(hostInfo);
        }
        else
        {
            text.text = "加入失敗";
            Debug.LogError("Join match failed");
        }
    }
    public void CreateRoom()
    {
        string IP = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        CreateInternetMatch(IP);

    }
    public void JoinRoom()
    {
        string IP = GameObject.Find("InputIP").transform.FindChild("Text").GetComponent<Text>().text;
        FindInternetMatch(IP);
       text.text = "再次點擊\"加入房間\"進入遊玩";
    }
}