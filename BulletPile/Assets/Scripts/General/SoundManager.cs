using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    //static AudioClip[] audioClips;
    static Dictionary<string,AudioSource> soundResources;
    static AudioSource musicSource;

    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    static void InitializeSingleton(){
        var manager = new GameObject( "SoundManager", typeof(SoundManager ) );
        DontDestroyOnLoad(Instance);
        
        var audioClips= Resources.LoadAll("Audio/SE", typeof(AudioClip)) ;
        soundResources=new Dictionary<string, AudioSource>();

        foreach(AudioClip s in audioClips){
            var ins=new GameObject(s.name);
            ins.transform.parent=Instance.transform;
            var audio=ins.AddComponent<AudioSource>();
            audio.clip=s;
            soundResources.Add(s.name,audio);
        }
        
        var bgm=new GameObject("BGM");
        var bgmClip=Resources.Load("Audio/BGM/bgm",typeof(AudioClip)) as AudioClip;
        bgm.transform.parent=Instance.transform;
        musicSource=bgm.AddComponent<AudioSource>();
        musicSource.clip=bgmClip;
        musicSource.loop=true;
        musicSource.playOnAwake=false;
        
    }   
    
    public static void setSE(string _name){
        try{}catch{}
        soundResources[_name].PlayOneShot(soundResources[_name].clip);
         
    }
    public static void setBGM(){
        musicSource.Play();
    }
    public static void stopBGM(){
         musicSource.Stop();
    }
}
