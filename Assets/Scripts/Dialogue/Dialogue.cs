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

    public Dialogue(string name, List<string> lines, Sprite icon){
        this.icon = icon;
        this.name = name;
        this.sentences = lines;
    }


    //Returns a NEW dialogue with the greeting
    public Dialogue AddGreeting(string greeting){
        List<string> lines = new List<string>();
        lines.Add(greeting);
        foreach(string line in sentences){
            lines.Add(line);
        }
        Dialogue ret = new Dialogue(name, lines, icon);
        return ret;
    }

}
