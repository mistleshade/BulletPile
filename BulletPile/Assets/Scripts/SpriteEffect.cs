using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int currentNumber;
    int count;
    [SerializeField]int rate;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        count=0;
        currentNumber=0;
        spriteRenderer.sprite=sprites[0];
        if(rate==0)rate=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(count%rate==0){
            if(currentNumber==sprites.Length){
                Destroy(gameObject);
                return;
            }
            spriteRenderer.sprite=sprites[currentNumber];
            currentNumber++;
        }
        count++;
        
    }
}
