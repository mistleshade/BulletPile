using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;
public class PileMarker : MonoBehaviour
{
    ///<summary>
    ///判定の持続フレーム
    ///</summary>
    public int sustainFrameCount;
    ///<summary>
    ///表示する半径と対応した自機との距離
    ///
    ///</summary>
    public Vector3 radiusSet;
    ///<summary>
    ///表示する半径と対応したマーカー。
    ///0:small,1:medium,2:large
    ///</summary>
    public Sprite[] markers;
    Radius currentRadius;
    [SerializeField] GameObject stingEffect;
    private int count;
    SpriteRenderer spriteRenderer;
    Collider2D thisCollider;

    void Start(){
        thisCollider=GetComponent<Collider2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.enabled=false;
    }
    void Update(){
        if(count >0){
            count--;
            if(count==0){
                thisCollider.enabled=false;
            }
        }
        SetRadius();

    }
    public void MoveMarker(Vector2 p){
         spriteRenderer.enabled=true;
        transform.Translate(p);
    }
    ///<summary>
    ///パイルがセットされたときに呼ばれる
    ///</summary>
    public void OnPileSet(){
        transform.localPosition=new Vector2(0,0);
        spriteRenderer.enabled=true;
    }
    
    ///<summary>
    ///パイルが打ち込まれたときに呼ばれる
    ///</summary>
    public void OnShot(){
        thisCollider.enabled=true;
        spriteRenderer.enabled=false;
        count=sustainFrameCount;
        SoundManager.setSE("sting");
        CameraManager.Vibration(0.1f);

    }
    ///<summary>
    ///自機との距離で半径を変化させる関数
    ///</summary>
    public void SetRadius(){
        var dist=Vector2.SqrMagnitude(transform.localPosition);
        var douRadiusSet=new Vector3(Mathf.Pow(radiusSet[0],2),Mathf.Pow(radiusSet[1],2),Mathf.Pow(radiusSet[2],2));
        if(dist<=douRadiusSet[0]){
            if(currentRadius!=Radius.Large)OnSetRadius(Radius.Large);
        }else if(dist<douRadiusSet[1]){
            if(currentRadius!=Radius.Medium)OnSetRadius(Radius.Medium);
        }else{
            if(currentRadius!=Radius.Small)OnSetRadius(Radius.Small);
        }
    }
    private void OnSetRadius(Radius radius){
        currentRadius=radius;
        spriteRenderer.sprite=markers[(int)radius];
    }
    public void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<IPunchable>()!=null){
            other.GetComponent<IPunchable>().OnPunched(transform.position,currentRadius);
            var ef= Instantiate(stingEffect);
            ef.transform.position=this.transform.position;
        }
    }
   
}
