using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameOverButtons : MonoBehaviour
{

    public void OnRestartDayClick(){
        Menu_Manager.instance.CloseNewDay();
        Save_Manager.instance.LoadRecentSave();
    }

    public void OnLoadPreviousClick(){
        string path = Path.Combine(Application.persistentDataPath, "Saves");
        path = Path.Combine(path, Save_Manager.instance.directoryPath);
        Menu_Manager.instance.OpenLoadMenu(path);
        Menu_Manager.instance.CloseNewDay();
    }
}
