using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constant;
public class Enemy : MonoBehaviour,IPunchable
{
    /// <summary>
    /// 保持しているスコア
    /// </summary>
    public int ownScore;
     /// <summary>
    /// スピード
    /// </summary>
    public float speed;
    /// <summary>
    /// 弾数の初期値
    /// </summary>
    public int initializeBulletCount;
    /// <summary>
    /// 残りの弾数。0になったら状態：空に遷移。後で非表示
    /// </summary>
    public int currentBulletCount;
    /// <summary>
    /// 現在の状態
    /// </summary>
    public State currentState;
    private int count;
    /// <summary>
    /// 状態Dischargingで使用する生成元のプレハブ
    /// </summary>
    [SerializeField]BulletGenerator baseBulletGenerator;
    /// <summary>
    /// 状態Dischargingで使用する生成元
    /// </summary>
    List<BulletGenerator> BulletGenerators;
    /// <summary>
    /// 残弾表示に使うマスクのTransform。これのスケールを操作して表示
    /// </summary>
    public Transform maskTransform;
    public GameObject emptyEffect;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        count=0;
        currentState=State.Fill;
        BulletGenerators=new List<BulletGenerator>();
        //AddBulletGenerator(transform.position,0);
       currentBulletCount=initializeBulletCount;
        maskTransform=transform.Find("MaskSprite");
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState==State.Fill){
            transform.Translate(0,-speed,0);
        }else if(currentState==State.Discharging){
            transform.Translate(0,speed*1.5f,0);
            var tmpList=new List<BulletGenerator>();
            foreach(BulletGenerator bg in BulletGenerators){
                tmpList.Add(bg);
            }
            foreach(BulletGenerator bg in tmpList){
                bg.ControledUpdate();
            }
        }
        
        maskTransform.localScale=new Vector3(1,GetBulletRate(),1);
        if(count>60&&!spriteRenderer.isVisible)Dead();
        count++;
    }

    public void OnPunched(Vector2 p,Radius radius){
        if(currentState==State.Fill)currentState=State.Discharging;
        AddBulletGenerator(p,radius);
        SoundManager.setSE("breaking");
    }
    public void useBullet(){
        currentBulletCount--;
        if(currentBulletCount==0)OnEmpty();
    }
     /// <summary>
    /// 初期弾数と残り弾数の割合
    /// </summary>
    private float GetBulletRate(){
        return (float)currentBulletCount/(float)initializeBulletCount;
    }

    private void OnEmpty(){
        currentState=State.Empty;
        GameProgressManager.Instance.AddScore(ownScore);
        var ef= Instantiate(emptyEffect);
        ef.transform.position=transform.position;
        SoundManager.setSE("empty");
        GameProgressManager.Instance.AddTime(2f);
        Dead();
    }
    private void Dead(){
        
        float score=ownScore*(1f-GetBulletRate())*Mathf.Pow(1.5f,BulletGenerators.Count);
        GameProgressManager.Instance.AddScore((int)score);
        if(currentState!=State.Fill)SoundManager.setSE("score");
        Destroy(gameObject);
    }
    private void AddBulletGenerator(Vector2 p,Radius radius){
        BulletGenerator bg=Instantiate(baseBulletGenerator.gameObject).GetComponent<BulletGenerator>();
        bg.transform.position=p;
        bg.transform.SetParent(transform);
        bg.SetRadius(radius);
        BulletGenerators.Add(bg);
    }
     /// <summary>
    /// 残りの弾数。0になったら空にする
    /// </summary>
    
    public enum State{
        /// <summary>
        /// 満たされている状態。下降する
        /// </summary>
        Fill=0,
        /// <summary>
        /// 弾を放出している状態。上昇する
        /// </summary>
        Discharging,
        /// <summary>
        /// 空の状態。止まってイベント発生
        /// </summary>
        Empty
    }
}
