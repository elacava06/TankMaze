using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{

    public GUIText scoreText;
    private int redScore;
    private int blueScore;
    public int pointsForClaim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void scoreChange(int teamNumber, int changeAmount)
    {
        if (teamNumber == 1)
        {
            redScore += pointsForClaim * changeAmount;
        }
        if (teamNumber == 2)
        {
            blueScore += pointsForClaim * changeAmount; 
        }
    }
}
