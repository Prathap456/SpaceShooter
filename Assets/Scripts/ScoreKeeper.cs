using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class ScoreKeeper : MonoBehaviour
{
    public Text scoretext;
    int score = 0;
    // Update is called once per frame
    public void Scorer(int value)
    {
        score = score + value;
        scoretext.text = score.ToString();
        if(score >= 30)
        {
            SceneManager.LoadScene(2);
        }
    }
}
