using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Simply holds all the npcs (currently just their scripts)
public class NPC_Manager : MonoBehaviour
{

    public static NPC_Manager instance;

    public List<Script> npcs =  new List<Script>();

    void Awake()
    {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    public void StartGame(){
        foreach(Script npc in npcs){
            npc.metPlayer = false;
            npc.relationship = 0;
        }
    }

    public Script GetNPCByName(string name){
        foreach(Script npc in npcs){
            if(npc.npcName == name){
                return npc;
            }
        }
        return null;
    }

    public void HideNPCs(){
        foreach(Script npc in npcs){
            npc.GetComponentInParent<SpriteRenderer>().enabled = false;
        }
    }

    public void ShowNPCs(){
        foreach(Script npc in npcs){
            npc.GetComponentInParent<SpriteRenderer>().enabled = true;
        }
    }
}
