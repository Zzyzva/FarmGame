using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadSaveButtons : MonoBehaviour
{

    public SaveData data;
    public string path;
    

    public void OnLoadClick(){
        Save_Manager.instance.LoadGame(data);
    }

    public void OnDeleteClick(){
        Save_Manager.instance.OnDeleteClick(this);
    }

    public void DeleteSave(){
        File.Delete(path);
        Destroy(gameObject);
    }

}
