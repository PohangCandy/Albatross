using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDirector : MonoBehaviour
{
    
    private GUIStyle TitleguiStyle = new GUIStyle(); 
    private GUIStyle ProviderguiStyle = new GUIStyle(); 
    private GUIStyle ScreenguiStyle = new GUIStyle();

    private void Start()
    {
       // Screen.SetResolution(1920, 1080, true);
    }
    void OnGUI()
    {
        TitleguiStyle.fontSize = 250; 
        ProviderguiStyle.fontSize = 40; 
        ScreenguiStyle.fontSize = 40; 
        TitleguiStyle.normal.textColor = Color.yellow; 
        ProviderguiStyle.normal.textColor = Color.black; 
        ScreenguiStyle.normal.textColor = Color.blue; 
        GUI.Label(new Rect(Screen.width / 10, Screen.height/16, 128, 32), "Go to Mars", TitleguiStyle); 
        GUI.Label(new Rect(Screen.width / 10, Screen.height/7 * 6, 128, 32), "C177041 mkc", ProviderguiStyle); 
        GUI.Label(new Rect(Screen.width / 10*8, Screen.height/7 * 6 , 128, 32), "1920 X 1080", ScreenguiStyle); 

    }
}


