using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartGame : MonoBehaviour
{
    
    public void OnClickStartButton()
    {
       SceneTransitionToGame();
    }
    public void OnClickManualButton(){

    }
    private void SceneTransitionToGame(){
        SceneTransitionManager.Instance.SceneTransition("Game");
    }
    void i(){
        
    }
}
