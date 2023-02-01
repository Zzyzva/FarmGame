using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

public class Save_Manager : MonoBehaviour
{

    public static Save_Manager instance;

    public string saveFile;
    public string directoryPath;

    public LoadSaveButtons currentSave;
    public CanvasGroup deleteWarning;


    void Awake()
    {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    public void SaveGame(){
        string path;
        string backupDirectory;
        //Create a new save name
        if(saveFile == ""){
            do{
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string safePlayerName = rgx.Replace(Inventory_Manager.instance.playerName, "");
                saveFile = safePlayerName + "_";
                int saveExtension = Random.Range(0, 99999999);
                directoryPath = saveFile + saveExtension;
                saveFile = saveFile + saveExtension + ".mike";
                path = Path.Combine(Application.persistentDataPath, saveFile);
                
                backupDirectory = Path.Combine(Application.persistentDataPath, directoryPath);
                
            } while(File.Exists(path) || Directory.Exists(backupDirectory));
            Directory.CreateDirectory(backupDirectory);
        }
        path = Path.Combine(Application.persistentDataPath, saveFile);

        SaveData data = new SaveData();
        data.Save();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public void SaveBackup(){
        string path;
        //Create a new save name
        if(saveFile == ""){
            return;       
        }
        path = Path.Combine(Application.persistentDataPath, directoryPath);
        string backupFile = Time_Manager.instance.date.year.ToString() + Time_Manager.instance.date.month + Time_Manager.instance.date.date.ToString() + saveFile;
        path = Path.Combine(path, backupFile);

        SaveData data = new SaveData();
        data.Save();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public void LoadGame(SaveData data){
        data.Load();
        Menu_Manager.instance.CloseLoadMenu();
        StartGame();
    }

    public void LoadRecentSave(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, saveFile);
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData data = formatter.Deserialize(stream) as SaveData;
        stream.Close();
        LoadGame(data);
    }

    public void StartGame(){
        Inventory_Manager.instance.UpdateSlots();
        Inventory_Manager.instance.UpdateChestSlots();
        Time_Manager.instance.UpdateTimeText();
        Player_Manager.player.SetActive(true);
        LevelLoader.instance.LoadLevel("Player House", new Vector2(3,3));
        
    }

    public void StartNewGame(){
        saveFile = "";
        Cutscene_Manager.instance.StartGame();
        Farming_Manager.instance.StartGame();
        Fishing_Manager.instance.StartGame();
        Inventory_Manager.instance.StartGame();
        Mines_Manager.instance.StartGame();
        NPC_Manager.instance.StartGame();
        Quest_Manager.instance.StartGame();
        Skills_Manager.instance.StartGame();
        Time_Manager.instance.StartGame();


        StartGame();
    }

    public void OnDeleteClick(LoadSaveButtons save){
        currentSave = save;
        deleteWarning.alpha = 1;
        deleteWarning.interactable = true;
        deleteWarning.blocksRaycasts = true;
        Menu_Manager.instance.LoadMenuInteractable(false);

    }

    public void OnDeleteCancel(){
        currentSave = null;
        deleteWarning.alpha = 0;
        deleteWarning.interactable = false;
        deleteWarning.blocksRaycasts = false;
        Menu_Manager.instance.LoadMenuInteractable(true);
        
    }

    public void OnDeleteConfirm(){
        deleteWarning.alpha = 0;
        deleteWarning.interactable = false;
        deleteWarning.blocksRaycasts = false;
        currentSave.DeleteSave();
        currentSave = null;
        Menu_Manager.instance.LoadMenuInteractable(true);
    }


}
