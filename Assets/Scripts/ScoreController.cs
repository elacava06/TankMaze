using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text[] scoreTexts;
    public int collectibleValue;
    public Dictionary<int, int> teamScores = new Dictionary<int, int>();
    public string[] teamNames;
    public int startingScore;
    private string scoreText;

    // Use this for initialization
    void Start()
    {
        for (int i = 1; i <= teamNames.Length; i++)
        {
            teamScores[i] = startingScore;
        }
        updateScores();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateScores()
    {
        scoreText = "";
        for (int i = 1; i <= teamNames.Length; i++)
        {
            scoreText = teamNames[i-1] + ": \n" + teamScores[i];
            scoreTexts[i - 1].text = scoreText;
        }
    }
}
