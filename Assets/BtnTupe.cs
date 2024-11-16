using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BtnTupe : MonoBehaviour
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    bool isSound;
    public CanvasGroup MenuIn;
    public CanvasGroup MenuQuit;

    public void OnBthClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                SceneManager.LoadScene("GameScene");
                break;

            case BTNType.Title:
                SceneManager.LoadScene("TitleScene");
                break;

            case BTNType.Operation:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Progress:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Back:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;
                

            case BTNType.Quit:
                Application.Quit();
                Debug.Log("╬ша╬╥А");
                break;

         
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
