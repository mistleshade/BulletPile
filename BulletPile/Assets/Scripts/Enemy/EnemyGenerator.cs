using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount%120==0){
            GenerateEnemy();
        }
    }
    void GenerateEnemy(){
        GameObject e=Instantiate(enemies[Random.Range(0,enemies.Length)]);
        e.transform.position=new Vector2(Random.Range(-6f,3f),5.7f);
    }
}
