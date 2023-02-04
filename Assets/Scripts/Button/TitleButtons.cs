using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TitleButtons : MonoBehaviour
{

    public CanvasGroup nameEnter;

    public CanvasGroup menuButtons;

    public bool newGameOpen = false;

    public void OnNewClick(){
        newGameOpen = true;

        nameEnter.alpha = 1;
        nameEnter.interactable = true;
        nameEnter.blocksRaycasts = true;

        menuButtons.alpha = 0;
        menuButtons.interactable = false;
        menuButtons.blocksRaycasts = false;
    }

    public void OnLoadClick(){
        menuButtons.alpha = 0;
        menuButtons.interactable = false;
        menuButtons.blocksRaycasts = false;
        
        Menu_Manager.instance.OpenLoadMenu(Path.Combine(Application.persistentDataPath, "Saves"));
    }


 void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            menuButtons.alpha = 1;
            menuButtons.interactable = true;
            menuButtons.blocksRaycasts = true;

            nameEnter.alpha = 0;
            nameEnter.interactable = false;
            nameEnter.blocksRaycasts = false;
        }
    }
}
