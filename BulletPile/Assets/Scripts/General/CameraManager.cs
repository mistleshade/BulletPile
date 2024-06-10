using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager> {
	public static float vibration_t;
	// Use this for initialization
	void Start () {
		vibration_t=0;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position=new Vector3(vibration_t*Random.Range(-1f,1),vibration_t*Random.Range(-1f,1),-10);
		vibration_t*=0.9f;
	}
	///<summary>
	///画面を揺らす
	///</summay>
	public static void Vibration(float t){
		vibration_t=t;
	}
}
