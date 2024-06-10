using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManager;
using static Constant;
public class Player : MonoBehaviour
{
    
    public float highSpeed;
    public float lowSpeed;
    ///<summary>
    ///パイルのクールタイム
    ///</summary>
    public int pileCoolCount;
    private int currentPileCount;
    ///<summary>
    ///被弾後のくーるたいむ
    ///</summary>
    public int damagedCoolCount;
    private int currentDamageCount;
    const float LEFT = -6.4f;
    const float RIGHT = 3.4f;
    const float TOP = 4.6f;
    const float BOTTOM = -4.6f;
    SpriteRenderer spriteRenderer;
    PileMarker pileMarker;
    SpriteMask gageMask;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        pileMarker=transform.Find("PileMarker").GetComponent<PileMarker>();
        gageMask=transform.Find("GageMask").GetComponent<SpriteMask>();
        currentDamageCount=0;
        currentPileCount=0;
    }

    // Update is called once per frame
    void Update()
    {

       Vector2 vec = Move();
        if(currentDamageCount>0){
            currentDamageCount--;
            if(currentDamageCount==0) GetComponent<Collider2D>().enabled=true; 
        }
        if(currentPileCount>0){
            currentPileCount--;
            gageMask.alphaCutoff=Easing(1f-(float)currentPileCount/(float)pileCoolCount);
            if(currentPileCount==0)SoundManager.setSE("setup");
            if(currentPileCount==0&&Button_Enter()){
                pileMarker.OnPileSet();
            }
        }else if(currentPileCount==0){
                PileSet(vec*2.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
       
       
        if(other.GetComponent<Bullet>()!=null&&currentDamageCount==0){
            var bu=other.GetComponent<Bullet>();
            OnDamaged();
            bu.OnReleasedUsing();
        }
    }
    void OnDamaged(){
        currentDamageCount=damagedCoolCount;
        GameProgressManager.Instance.AddTime(-10f);
        CameraManager.Vibration(1f);
        SoundManager.setSE("hidan");
    }
    Vector2 Move(){
        bool slow = Button_Function();
        
        float deltaX=0,deltaY=0;
        if (Button_Up())
        {
           // transform.Translate(0, (slow ? lowSpeed : highSpeed), 0);
            deltaY=(slow ? lowSpeed : highSpeed);
        }
        else if (Button_Down())
        {
           // transform.Translate(0, -1 * (slow ? lowSpeed : highSpeed), 0);
            deltaY=-1*(slow ? lowSpeed : highSpeed);
        }
        if (Button_Left())
        {
            //transform.Translate(-1 * (slow ? lowSpeed : highSpeed), 0, 0);
            deltaX=-1 * (slow ? lowSpeed : highSpeed);
        }
        else if (Button_Right())
        {
            //transform.Translate((slow ? lowSpeed : highSpeed), 0, 0);
            deltaX= (slow ? lowSpeed : highSpeed);
        }
        Vector2 delta=new Vector2(deltaX,deltaY);
        //if(!Button_Enter())transform.Translate(delta);
        transform.Translate(delta*(Button_Enter()?0.25f:1));

        var pos =transform.position;
        if (pos.x < LEFT) transform.position = new Vector2(LEFT, transform.position.y);
        if (pos.x > RIGHT) transform.position = new Vector2(RIGHT, transform.position.y);
        if (pos.y > TOP) transform.position = new Vector2(transform.position.x, TOP);
        if (pos.y < BOTTOM) transform.position = new Vector2(transform.position.x, BOTTOM);
        return delta;
    }
    void PileSet(Vector2 p){
        bool enter = Button_Enter();
        if(Button_Enter_Down()){
            pileMarker.OnPileSet();
        }
        if(Button_Enter_Up()){
            pileMarker.OnShot();
            currentPileCount=pileCoolCount;
        }
        if(Button_Enter()){
            pileMarker.MoveMarker(p);
        }
    }
}
