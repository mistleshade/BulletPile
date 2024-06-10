using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonMonoBehaviour<InputManager>{
    const string Z = "Enter";
    const string X = "Cancel";
    const string C = "Curse";
    const string Shift = "Function";
    public static bool Button_Up(){return Input.GetAxis("Vertical")>0;}
    public static bool Button_Down(){return Input.GetAxis("Vertical")<0;}
    public static bool Button_Right(){return Input.GetAxis("Horizontal")>0;}
    public static bool Button_Left(){return Input.GetAxis("Horizontal")<0;}
    public static bool Button_Enter(){return Input.GetButton(Z);} 
	public static bool Button_Enter_Down(){return Input.GetButtonDown(Z);}
    public static bool Button_Enter_Up() { return Input.GetButtonUp(Z);}
	public static bool Button_Cancel(){return Input.GetButton(X);} 
	public static bool Button_Cancel_Down(){return Input.GetButtonDown(X);}
    public static bool Button_Cansel_Up() { return Input.GetButtonUp(X); }
	public static bool Button_Curse(){return Input.GetButton(C);} 
	public static bool Button_Curse_Down(){return Input.GetButtonDown(C);}
    public static bool Button_Curse_Up() { return Input.GetButtonUp(C); }
    public static bool Button_Function() { return Input.GetButton(Shift); }
	public static bool Button_Funcion_Down(){return Input.GetButtonDown(Shift);}
    public static bool Button_Function_Up() { return Input.GetButtonUp(Shift); }
	
    //  public static bool Button_Function() { return Input.GetButton("Function") || Input.GetAxis("Function") > 0; }

}