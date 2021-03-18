
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PuzzleSection : MonoBehaviour {
	Vector2 m_goodOffset;
	Vector2 m_offset;
	Vector2 m_scale;
	GameBoard m_gameBoard;

	void Start()
	{
		m_gameBoard = (GameBoard)GameObject.FindObjectOfType<Canvas> ().GetComponentInChildren<GameBoard> ();
	}

	public void CreatePuzzlePiece(int size)
	{
		transform.localScale = new Vector3 (0.9f * transform.localScale.x /size, 0.9f * transform.localScale.z / size, 1);
        transform.position = new Vector3(150 + transform.position.x, 150 + transform.position.y, 1);
    }

	public void AssignImage(Vector2 scale, Vector2 offset)
	{
		m_goodOffset = offset;
		m_scale = scale;
		AssignImage (offset);

	}

	public void AssignImage(Vector2 offset)
	{
		m_offset = offset;
		GetComponent<RawImage> ().uvRect = new Rect ((offset.x), (offset.y), m_scale.x, m_scale.y);
     
	}

	public void OnClick()
	{
		PuzzleSection previousSelection = m_gameBoard.GetSelection ();
       

        if (previousSelection != null) {
            m_gameBoard.callSelection(this);
            PuzzleSection nowSelection = m_gameBoard.postSelection2();
            Vector2 Offset = nowSelection.postImageOffset2();
            previousSelection.GetComponent<RawImage> ().color = Color.white;
            
            Vector2 tempOffset = previousSelection.GetImageOffset ();
			previousSelection.AssignImage (m_offset);

            int raw = (int)((Offset.x) / (1f / m_gameBoard.m_size));
            int col = (int)((Offset.y) / (1f / m_gameBoard.m_size));
            //print("第二歌raw:" + raw);
            //print("第二歌col:" + col);
            m_gameBoard.audioraw[raw, col] = 1;
            AssignImage(tempOffset);
			m_gameBoard.SetSelection (null);
          
            Savedata.count++;
            for (int i = 0; i < m_gameBoard.m_size; i++)
            {
                for (int j = 0; j < m_gameBoard.m_size; j++)
                {
                    if (m_gameBoard.audioraw[i, j] == 1)
                    {
                        Savedata.audioraw = i;
                        //print("第二歌:" + Savedata.audioraw);
                      
                    }
                    m_gameBoard.audioraw[i, j] = 0;
                }
            }
            m_gameBoard.clickSound();
            if (m_gameBoard.CheckBoard () == true)
				m_gameBoard.Win ();
            
        } else {
			GetComponent<RawImage> ().color = Color.gray;
            
            m_gameBoard.SetSelection (this);
            PuzzleSection findSelection = m_gameBoard.postSelection();
            Vector2 Offset = findSelection.postImageOffset();
            int raw1 = (int)((Offset.x) / (1f / m_gameBoard.m_size));
            int col1 = (int)((Offset.y) / (1f / m_gameBoard.m_size));
           // print("第1歌raw:" + raw1);
           // print("第1歌col:" + col1);
            m_gameBoard.audioraw[raw1, col1] = 1;
            for (int i = 0; i < m_gameBoard.m_size; i++)
            {
                for (int j = 0; j < m_gameBoard.m_size; j++)
                {
                    if (m_gameBoard.audioraw[i, j] == 1)
                    {
                        Savedata.audioraw = i;
                      // print("第一歌:"+Savedata.audioraw);
                        
                    }
                    m_gameBoard.audioraw[i, j] = 0;
                }
            }
            m_gameBoard.clickSound();
            Savedata.audioraw = 0;
        }
    }
	public Vector2 GetImageOffset()
	{
		return m_offset;
	}
    public Vector2 postImageOffset()
    {
        return m_offset;
    }
    public Vector2 postImageOffset2()
    {
        return m_offset;
    }
    public bool CheckGoodPlacement()
	{
		return (m_goodOffset == m_offset);
	}

    public static implicit operator Vector2(PuzzleSection v)
    {
        throw new NotImplementedException();
    }
}
