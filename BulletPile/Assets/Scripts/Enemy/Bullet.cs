using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IPooled 
{
    [SerializeField]
    private float speed{ get; set; }
    private float angle{ get; set; }
    private float accel{ get; set; }
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    Renderer targetRenderer;
    [SerializeField]
    private Transform thisTransform;
    [SerializeField]
    BulletManager bulletManager;
    public int lifeCount{ get; set; }
    public void Init(){
        speed=0;
        angle=0;
        accel=0;
        lifeCount=0;
        spriteRenderer=GetComponent<SpriteRenderer>();
        thisTransform=GetComponent<Transform>();
        
        bulletManager=BulletManager.Instance;
    
        gameObject.SetActive(false);
    }
    public void OnReleasedUsing(){
        
        BulletManager.Instance.ReleaseBullet(this);
        gameObject.SetActive(false);
       
    
    }
    
    public void OnSetActive(){
        gameObject.SetActive(true);
    }
    public void ControledUpdate(){
        
        //if(lifeCount==0||!spriteRenderer.isVisible)OnReleasedUsing();
        if(lifeCount==0&&gameObject.activeSelf){
            OnReleasedUsing();
            return;
        }
        Move();
        lifeCount--;
    }
    private void Move(){
        thisTransform.Translate(0,-speed,0);
        speed+=accel;
    }
    public void SetPosition(Vector2 p){
        thisTransform.position=p;
    }
    public void SetParam(float speed,float angle,float accel){
        this.speed=speed;
        this.angle=angle;
        this.accel=accel;
        thisTransform.rotation=Quaternion.Euler(0,0,angle);
    }
    

}
