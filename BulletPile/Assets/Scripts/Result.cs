using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    public Text scoreText;
    public Text grazeText;
    void Start(){
        scoreText.text=GameProgressManager.GetScore().ToString();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (GameProgressManager.GetScore());
    }
    public void OnClickReturnButton()
    {
       SceneTransitionToGame();
    }

    private void SceneTransitionToGame(){
        SceneTransitionManager.Instance.SceneTransition("Title");
    }

}
