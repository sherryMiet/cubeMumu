using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConToSQL : MonoBehaviour {
    public InputField AccountingField;//註冊帳號
    public InputField AgeField;//年齡
    public InputField NameField;//註冊帳號
    public Text feedmsg;

    public void isLoad()
    {
        Savedata.accounting = AccountingField.text;
        string age = AgeField.text;
        string name = NameField.text;

        StartCoroutine(LoginToDB(Savedata.accounting,age,name));
      
    }
    IEnumerator LoginToDB(string accounting,string age,string name)
    {
        WWWForm form = new WWWForm();//上傳unity使用者所輸入的資料
        form.AddField("accounting", accounting);
        form.AddField("age", age);
        form.AddField("name", name);

        WWW www = new WWW("http://localhost/pigmumu/signup.php", form);//下載connection.php所回傳的資訊

        yield return www;
        string b = www.text;
        b = b.Replace(" ", "");
        b = b.Replace("\r", "");
        b = b.Replace("\n", "");
        b = b.Replace("\t", "");
        b = b.Replace("</br>", "");
        if (b == "error")
        {
            feedmsg.text = "你已經註冊過囉!";
        }
        else
        {
            feedmsg.text = "";
            Savedata.id = b;
            print(Savedata.id);
            SceneManager.LoadScene("main");
           
        }
    }
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
