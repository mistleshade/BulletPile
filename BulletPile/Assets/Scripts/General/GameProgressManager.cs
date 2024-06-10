using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : SingletonMonoBehaviour<GameProgressManager>
{
    
   
    public const float INIT_TIME=60;
    private float time{get;set;}
    private static int graze{get;set;}
    private static int score{get;set;}
     SceneTransitionManager sceneTransition;
    List<IProgressListner> progressListners;
    void Awake(){
        progressListners=new List<IProgressListner>();
    }
    void Start(){
        OnSceneTransition();
        sceneTransition=SceneTransitionManager.Instance;
        AddScore(0);
        SoundManager.setBGM();
    }
    void Update(){
        if(!sceneTransition.getCurrentSceneName().Equals("Game")){
            Debug.Log(sceneTransition.getCurrentSceneName());
            return;
        }
        AddTime(-Time.deltaTime);
        if(time<=0){
            SoundManager.stopBGM();
            sceneTransition.SceneTransition("Result");
        }
        
    }
    public void OnSceneTransition(){
        time=INIT_TIME;
        score=0;
    }
    public void AddTime(float t){
        time+=t;
        foreach(IProgressListner ip in progressListners)ip.OnUpdatedTime(time);
    }
    public void AddScore(int s){
        score+=s;
        foreach(IProgressListner ip in progressListners)ip.OnUpdatedScore(score);
    }
    public void AddGraze(){
        graze++;
        foreach(IProgressListner ip in progressListners)ip.OnUpdatedGraze(graze);
    }
    public void AddProgressListner(IProgressListner ip){
        progressListners.Add(ip);
    }
    public static int GetScore(){
        return score;
    }
}