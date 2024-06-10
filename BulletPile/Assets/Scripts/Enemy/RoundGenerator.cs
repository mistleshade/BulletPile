using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Mathf;
public class RoundGenerator :BulletGenerator
{
  

    public override void ControledUpdate()
    {
        if(Time.frameCount%60==0){
            var r=Range(0,50f);
            for(float i=0,n=depends(6,8,16);i<n;i++){
                Shot(0.03f,i/n*360+r,0.001f);
            }
        }
    }
}
