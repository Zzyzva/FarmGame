using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emote_Manager : MonoBehaviour
{

    public static Emote_Manager instance;
    public List<GameObject> emotes = new List<GameObject>();


    private void Awake() {
        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
        }
        
    }


    public void SpawnEmote(string name, Vector3 position, int waiting){
        GameObject emote = Instantiate(emotes.Find((x) => x.name == name), position, Quaternion.identity);
        emote.GetComponent<EmoteScript>().waiting = waiting == 1 ? true : false;
    }

    //Not for cutscene use
    public void SpawnEmoteOnPlayer(string name){
        Vector3 pos = Player_Manager.player.transform.position;
        pos.y += 1;
        GameObject emote = Instantiate(emotes.Find((x) => x.name == name), pos, Quaternion.identity);
        emote.GetComponent<EmoteScript>().followPlayer = true;
    }
}
