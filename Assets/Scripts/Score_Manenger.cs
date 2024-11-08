using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class Score_Manenger : MonoBehaviour

{

    public int score = 0;

    public int highScore;

    public static int lastScore = 0;



    public Text scoreText;

    public Text highScoreText;

    public Text lastScoreText;





    // Start is called before the first frame update

    void Start()

    {

        StartCoroutine(Score());



        highScore = PlayerPrefs.GetInt("high_score", 0);



        highScoreText.text = "HighScore: " + highScore.ToString();

        lastScoreText.text = "LastScore: " + lastScore.ToString();

    }



    // Update is called once per frame

    void Update()

    {

        scoreText.text = score.ToString();



        if (score > highScore)

        {

            highScore = score;

            PlayerPrefs.SetInt("high_score", highScore);

        }

    }



    IEnumerator Score()

    {

        while (true)

        {

            yield return new WaitForSeconds(0.8f);

            score = score + 1;

            lastScore = score;

        }

    }

}