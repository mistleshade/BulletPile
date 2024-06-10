using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameProgressView : MonoBehaviour ,IProgressListner
{
    GameProgressManager gameProgressManager;
    public Text timeText;
    public Text scoreText;
    public Text grazeText;
   
    // Start is called before the first frame update
    void Start()
    {
        gameProgressManager=GameProgressManager.Instance;
        gameProgressManager.AddProgressListner(this);

   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUpdatedTime(float t){
        timeText.text=string.Format("{0:n1}",  t);
    }
    public void OnUpdatedTimeByEvent(float t){
        OnUpdatedTime(t);
    }

    public void OnUpdatedScore(int s){
        scoreText.text=s.ToString();
    }
  
    public void OnUpdatedGraze(int g){
        grazeText.text=g.ToString();
    }
}
