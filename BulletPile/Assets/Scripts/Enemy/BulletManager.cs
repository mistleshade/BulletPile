using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : BasePoolManager<BulletManager, Bullet>
{
    ///<summary>
    ///複製元となるインスタンス
    ///</summary>
    [SerializeField]
    private Bullet instance;
    void Start(){
        usingObjectList=new List<Bullet>();
        waitingObjectList=new List<Bullet>();
        for(int i=0;i<NUM;i++){
            GenerateObject();
        }
    }
    override public Bullet GenerateObject(){
        Bullet bullet=GameObject.Instantiate(instance);
        bullet.transform.SetParent(this.transform);
        instance.Init();
        waitingObjectList.Add(bullet);
        return bullet;
    }
    void Update(){
        var tmpList=new List<Bullet>();
        foreach(Bullet p in usingObjectList){
            tmpList.Add(p);
        }
        foreach(Bullet p in tmpList){
            p.ControledUpdate();
        }
    }
}
