using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class record : MonoBehaviour {

    public void saverecord()
    { 
        StartCoroutine(LoginToDB(Savedata.id));

    }
    IEnumerator LoginToDB(string id)
    {
        WWWForm form = new WWWForm();//上傳unity使用者所輸入的資料
        form.AddField("id", id);
        form.AddField("time", Savedata.time);
        form.AddField("count", Savedata.count);
        form.AddField("size", Savedata.size);
        form.AddField("level", Savedata.level);
        WWW www = new WWW("http://localhost/pigmumu/record.php", form);//下載connection.php所回傳的資
        yield return www;
        string b = www.text;
        b = b.Replace(" ", "");
        b = b.Replace("\r", "");
        b = b.Replace("\n", "");
        b = b.Replace("\t", "");
        b = b.Replace("</br>", "");
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
