using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public List<string> sentences = new List<string>();
    public string name;
    public Sprite icon;

    public Dialogue(string name, string lines, Sprite icon){
        this.icon = icon;
        this.name = name;

        string[] data = lines.Split(new char[] {'$'});
        foreach(string line in data){
            string tempLine = line.Replace("PLAYER", Inventory_Manager.instance.playerName);
            this.sentences.Add(tempLine);
        }
    }
}
