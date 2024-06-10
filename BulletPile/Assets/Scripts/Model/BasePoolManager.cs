using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SingletonMonoBehaviour<BasePoolManager>
/// <summary>
/// Tクラスのプールを管理するクラス
/// </summary>
/// <typeparam name="T">PooledObjectを継承しているクラス</typeparam>
public abstract class BasePoolManager<S,T>:MonoBehaviour where S : MonoBehaviour where T:IPooled{
    private static S instance;
    public static S Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (S)FindObjectOfType(typeof(S));

                if (instance == null)
                {
                    Debug.LogError(typeof(S) + "is nothing");
                }
            }
            
            return instance;
        }
    }
    ///<summary>
    ///
    ///</summary>
    public int NUM;
        [SerializeField]
    
    protected List<T> usingObjectList;
        [SerializeField]
    protected List<T> waitingObjectList;
    protected void Awake(){
       
    }
    // Use this for initialization
    public T GetPooledObject()
    {
        T ip;
       
        if(waitingObjectList.Count==0){
            GenerateObject();
        }
            ip=waitingObjectList[0];
            usingObjectList.Add(ip);
            
            ip.OnSetActive();
            waitingObjectList.RemoveAt(0);
            return ip;
        
      
    }
    public void AddWaitingList(T t){

        waitingObjectList.Add(t);
    } 
    public void ReleaseBullet(T t){
        waitingObjectList.Add(t);
        usingObjectList.Remove(t);
       
        
        
    }
    abstract public T GenerateObject();
}