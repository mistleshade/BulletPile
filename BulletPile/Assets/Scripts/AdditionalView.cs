using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdditionalView : MonoBehaviour,IProgressListner
{   
    const int WAIT_GRAZE_COUNT=65;
    int timeCount;
    ///<summary>
    ///現在のグレイズ数。追加分の計算用に使用
    ///</summary>
    int currentGraze;
    float sumTime;
    float currentTime;
    [SerializeField]Text textEffect;
    bool isTotalizing;
    // Start is called before the first frame update
    void Start()
    {
        GameProgressManager.Instance.AddProgressListner(this);
        currentTime=GameProgressManager.INIT_TIME;   
        timeCount=0; 
        sumTime=0;   
        isTotalizing=false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeCount>0){
            timeCount--;
            textEffect.color=new Color(0,255,0,(float)timeCount/(float)WAIT_GRAZE_COUNT);
            if(timeCount==0){
                setTextEffect(string.Format("{0:n1}",sumTime));
              
            }
        }
    }
    void setTextEffect(string t){
        textEffect.text=t;

    }
    public void OnUpdatedTime(float t){
        var diff=currentTime-t;
        currentTime=t;
        
        if(Mathf.Abs(diff)<=0.09f)return;
        
        timeCount=WAIT_GRAZE_COUNT;
        sumTime+=diff;
    }
    public void OnUpdatedScore(int s){}
  
    public void OnUpdatedGraze(int g){}
}
