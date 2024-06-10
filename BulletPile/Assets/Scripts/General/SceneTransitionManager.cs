using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : SingletonMonoBehaviour<SceneTransitionManager>
{
    
    void Awake(){
         var currentScene = SceneManager.GetActiveScene();
        // Sceneの名前を表示。
        Debug.Log(currentScene.name);
    }
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    static void InitializeSingleton(){
        var manager = new GameObject( "SceneTransitionManager", typeof( SceneTransitionManager ) );
        DontDestroyOnLoad(Instance);
        //SceneTransition("");
    }

    public void SceneTransition(string sceneName){
         SceneManager.LoadScene(sceneName);
    }

    public string getCurrentSceneName(){
        return SceneManager.GetActiveScene().name;
    }
    
}
