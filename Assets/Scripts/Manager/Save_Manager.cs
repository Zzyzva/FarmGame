using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_Manager : MonoBehaviour
{

    public static Save_Manager instance;

    public string saveFile;

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
        //Create a new save name
        if(saveFile == ""){
            do{
                saveFile = Inventory_Manager.instance.playerName + "_";
                int saveExtension = Random.Range(0, 99999999);
                saveFile = saveFile + saveExtension + ".mike";
                path = Path.Combine(Application.persistentDataPath, saveFile);
                
            } while(File.Exists(path));        
        }
        path = Path.Combine(Application.persistentDataPath, saveFile);

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

    public void StartGame(){
        Inventory_Manager.instance.UpdateSlots();
        Inventory_Manager.instance.UpdateChestSlots();
        Time_Manager.instance.UpdateTimeText();
        LevelLoader.instance.LoadLevel("Barracks", new Vector2(3,3));
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
