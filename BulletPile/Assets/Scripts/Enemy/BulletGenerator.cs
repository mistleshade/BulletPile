using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;
/// <summary>
/// 弾を発射するクラス
/// </summary>
public class BulletGenerator : MonoBehaviour
{
  
    /// <summary>
    /// 弾を発射するエネミー
    /// </summary>
    protected Enemy parentEnemy;
     /// <summary>
    /// 空けられた穴の大きさ
    /// </summary>
    protected Radius radius;
    protected BulletManager bulletManager;
    
    // Start is called before the first frame update
    virtual protected void Start()
    {
        parentEnemy=transform.parent.GetComponent<Enemy>();
        bulletManager=BulletManager.Instance;
    }
    public void SetRadius(Radius r){
        radius=r;
    }
    virtual public void ControledUpdate(){
       
    }
    protected void Shot(float speed,float angle,float accel){
        Bullet bullet= bulletManager.GetPooledObject();
        bullet.SetParam(speed,angle,accel);
        bullet.lifeCount=240;
        bullet.SetPosition(transform.position);

        parentEnemy.useBullet();
    }
    protected T depends<T>(T x,T y,T z){
        if(radius==Radius.Small)return x;
        else if(radius==Radius.Medium)return y;
        else return z;
    } 
}
