using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPooled 
{
    ///<summary>
    ///使用を停止する際に実行される関数
    ///</summary>
    void OnReleasedUsing();
    
    void OnSetActive();
    void ControledUpdate();

}


