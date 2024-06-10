using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;
using static UnityEngine.Mathf;
using static UnityEngine.Random;
public class TargetGenerator : BulletGenerator
{
    Transform playerTransform;
    override protected void Start()
    {
        base.Start();
        
        playerTransform=GameObject.Find("Player").transform;
        
    }
     public override void ControledUpdate()
    {
        
        if(Time.frameCount%30==0){
            var ang=Atan2(playerTransform.position.y-transform.position.y,
            playerTransform.position.x - transform.position.x)*Rad2Deg;
            for(float n=depends(5,10,15),i=0;i<n;i++){
                Shot(0.05f+0.08f*i/n,ang+90,0);
           }
        }
    }
}
