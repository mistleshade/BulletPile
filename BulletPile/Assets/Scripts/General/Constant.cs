using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
public static  class Constant {
    public static float Easing(float t){
        if(t>=1)return 1;
        if(t<=0)return 0;
        return 1-Pow((t-1),4);
    }
    public enum Radius{
        Small=0,
        Medium,
        Large
    }
}
