using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameConn : MonoBehaviour
{


    public int m_size;
    public record record;
    public GameObject m_puzzlePiece;
    public int m_randomPasses = 12;
    public GameObject youwin;
    public GameObject Next;
    public GameObject home;
    public PuzzleSection[,] m_puzzle;
    PuzzleSection m_puzzleSection;
    public Text count;
    public Text show_time;
    public int[,] audioraw;
    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;
    void Update()
    {
        count.text = "交換次數:" + Savedata.count;
    }
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        Savedata.count = 0;
        GameObject temp;
        m_size = 3;
        audioraw = new int[m_size, m_size];
        m_puzzle = new PuzzleSection[m_size, m_size];
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {

                temp = (GameObject)Instantiate(m_puzzlePiece, new Vector2((i * 700 / m_size), (j * 700 / m_size)), Quaternion.identity);
                temp.transform.SetParent(transform);
                m_puzzle[i, j] = (PuzzleSection)temp.GetComponent("PuzzleSection");
                m_puzzle[i, j].CreatePuzzlePiece(m_size);
            }
        }


        SetupBoard();

        RandomizePlacement();
    }

    public void clickSound()
    {

        int index = Random.Range(0, shoot.Length);
        shootClip = shoot[Savedata.audioraw];
        audioSource.clip = shootClip;
        audioSource.Play();
    }
    public void RandomizePlacement()
    {
        VectorInt2[] puzzleLocation = new VectorInt2[2];
        Vector2[] puzzleOffest = new Vector2[2];
        do
        {
            for (int i = 0; i < m_randomPasses; i++)
            {
                puzzleLocation[0].x = Random.Range(0, m_size);
                puzzleLocation[0].y = Random.Range(0, m_size);
                puzzleLocation[1].x = Random.Range(0, m_size);
                puzzleLocation[1].y = Random.Range(0, m_size);

                puzzleOffest[0] = m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].GetImageOffset();
                puzzleOffest[1] = m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].GetImageOffset();
                m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].AssignImage(puzzleOffest[1]);
                m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].AssignImage(puzzleOffest[0]);

            }
        } while (CheckBoard() == true);


    }
    void SetupBoard()
    {
        Vector2 offset;
        Vector2 m_scale = new Vector2(0.95f / m_size, 0.95f / m_size);
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                offset = new Vector2(i * (1f / m_size), j * (1f / m_size));
                m_puzzle[i, j].AssignImage(m_scale, offset);
            }
        }
    }

    public PuzzleSection GetSelection()
    {
        return m_puzzleSection;
    }
    public PuzzleSection postSelection2()
    {
        return m_puzzleSection;
    }
    public PuzzleSection postSelection()
    {
        return m_puzzleSection;
    }
    public void callSelection(PuzzleSection selection)
    {
        m_puzzleSection = selection;
    }
    public void SetSelection(PuzzleSection selection)
    {
        m_puzzleSection = selection;
    }
    public void findSelection(PuzzleSection selection)
    {
        m_puzzleSection = selection;
    }
    public bool CheckBoard()
    {
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {

                if (m_puzzle[i, j].CheckGoodPlacement() == false)
                    return false;
            }
        }
        return true;
    }

    public void Win()
    {
        //GetComponent<Animator> ().SetTrigger ("moveUp");
        youwin.SetActive(true);
        Next.SetActive(true);
        saverecord();
    }
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


}