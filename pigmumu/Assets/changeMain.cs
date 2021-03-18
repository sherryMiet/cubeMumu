using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeMain : MonoBehaviour {
    GameBoard m_gameBoard;
    // Use this for initialization
    void Start () {

        m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<GameBoard>();
    }
	
	// Update is called once per frame
	void Update () {
      
    }
    public void single() {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadToGame() {
        SceneManager.LoadScene("square_pig1");
    }
    public void backtomain()
    {
        SceneManager.LoadScene("main");
    }
    public void backtolevel()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void backtosignup()
    {
        SceneManager.LoadScene("signup");
    }
    public void backtosignup1()
    {
        SceneManager.LoadScene("signUP 1");
    }
    public void backtosignin()
    {
        SceneManager.LoadScene("signin");
    }
    public void backtoonline()
    {
        SceneManager.LoadScene("online");
    }
 
    public void returnRandom()
    {
        m_gameBoard.RandomizePlacement();
    }
   
}
