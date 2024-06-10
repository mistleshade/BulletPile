using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;
using static UnityEngine.Mathf;
using static UnityEngine.Random;
public class ScatterGenerator : BulletGenerator
{
    public override void ControledUpdate()
    {
        if(Time.frameCount%depends(10,8,2)==0){
            for(int i=0;i<2;i++)Shot(Range(0.06f,0.08f),Range(-1f,1f)*depends(30f,45,120),0);
        }
    }
    
}
