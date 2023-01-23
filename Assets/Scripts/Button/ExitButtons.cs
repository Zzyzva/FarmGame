using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtons : MonoBehaviour
{
    public CanvasGroup exitTitleWarning;
    public CanvasGroup exitDesktopWarning;

    public void OnExitToTitleClick(){
        Menu_Manager.instance.canClose = false;
        exitTitleWarning.alpha = 1;
        exitTitleWarning.interactable = true;
        exitTitleWarning.blocksRaycasts = true;
        Menu_Manager.instance.PauseMenuInteractable(false);
    }

    public void OnExitToDesktopClick(){
        Menu_Manager.instance.canClose = false;
        exitDesktopWarning.alpha = 1;
        exitDesktopWarning.interactable = true;
        exitDesktopWarning.blocksRaycasts = true;
        Menu_Manager.instance.PauseMenuInteractable(false);
    }

    public void OnCancel(){
        Menu_Manager.instance.canClose = true;
        exitTitleWarning.alpha = 0;
        exitTitleWarning.interactable = false;
        exitTitleWarning.blocksRaycasts = false;
        exitDesktopWarning.alpha = 0;
        exitDesktopWarning.interactable = false;
        exitDesktopWarning.blocksRaycasts = false;
        Menu_Manager.instance.PauseMenuInteractable(true);
    }

    public void OnTitleQuit(){
        Menu_Manager.instance.canClose = true;
        exitTitleWarning.alpha = 0;
        exitTitleWarning.interactable = false;
        exitTitleWarning.blocksRaycasts = false;
        Menu_Manager.instance.ClosePauseMenu();
        Time_Manager.instance.Pause();
        Time_Manager.instance.HUD.alpha = 0f;
        LevelLoader.instance.LoadLevel("Title", new Vector2(-100,-100));
    }

    public void OnDesktopQuit(){
        Application.Quit();
    }
}
