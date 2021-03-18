using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loginin : MonoBehaviour {
    public InputField AccountingField;//帳號
    public Text feedmsg;
    public void logining()
    {
        Savedata.accounting = AccountingField.text;
        

        StartCoroutine(LoginToDB(Savedata.accounting));

    }
    IEnumerator LoginToDB(string accounting)
    {
        WWWForm form = new WWWForm();//上傳unity使用者所輸入的資料
        form.AddField("accounting", accounting);
       
        WWW www = new WWW("http://localhost/pigmumu/signin.php", form);//下載connection.php所回傳的資訊

        yield return www;
        yield return www;
        string b = www.text;
        b = b.Replace(" ", "");
        b = b.Replace("\r", "");
        b = b.Replace("\n", "");
        b = b.Replace("\t", "");
        b = b.Replace("</br>", "");
        if (b == "error")
        {
            feedmsg.text = "沒有這個人喔!";
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
