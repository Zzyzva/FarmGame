using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public string npc;
    public bool active;
    public bool mainQuest;
    public List<QuestItem> items;
    public int timeToComplete;
    public Date deadline;


    public Quest(string name, string npc, int timeToComplete){
        items = new List<QuestItem>();
        questName = name;
        this.npc = npc;
        this.timeToComplete = timeToComplete;
    }

    public void SetActive(){
        active = true;
        Date d = Time_Manager.instance.date;
        deadline = new Date(d.date, d.month, d.year);
        for(int i = 0; i < timeToComplete; i++){
            deadline.NextDay();
        }
    }
}

[System.Serializable]
public class QuestItem{
    public string name;
    public int count;

    public QuestItem(string name, int count){
        this.name = name;
        this.count = count;
    }
}

