using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeCounter : MonoBehaviour
{
    GameProgressManager gameProgressManager;
    void Start()
    {
        gameProgressManager=GameProgressManager.Instance;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<Bullet>()!=null){
            gameProgressManager.AddTime(0.1f);
            gameProgressManager.AddGraze();
            SoundManager.setSE("graze");
        }
    }
    
}
