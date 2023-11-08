using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;
    private Text txtCom;

    // Start is called before the first frame update
    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();
    }

    static public int SCORE
    {
        get { return _SCORE;}
        private set
        {
            _SCORE = value;
            if (_UI_TEXT != null)
            { 
                if (_UI_TEXT.text != null)
                {

                    _UI_TEXT.text = "High Score: " + value.ToString("#,0");

                }
            }
        }
    }

    // Update is called once per frame
    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return;

        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the High Score in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs High Score reset to 1000.");
        }
    }
}
