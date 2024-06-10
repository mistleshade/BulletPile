using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgressListner 
{
  void OnUpdatedTime(float t);

  
  void OnUpdatedScore(int s);
  
  void OnUpdatedGraze(int g);
}
