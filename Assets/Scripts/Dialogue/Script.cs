using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : Interactable
{

    public string dialogueCSV = "";
    
    protected string introDialogue;
    protected string hateGiftDialogue;
    protected string dislikeGiftDialogue;
    protected string neutralGiftDialogue;
    protected string likeGiftDialogue;
    protected string loveGiftDialogue;
    protected string questDialogue;

    protected string[] zeroHeartsDialogue;
    protected string[] twoHeartsDialogue;
    public string npcName;
    public Sprite icon;

    public bool metPlayer = false;
    public bool talkedToday = false;
    Dialogue currentDialogue;

    public bool canTalk = false;


    public int relationship = 0;

    [HideInInspector]
    public int relationshipPerHeart = 10;



    void Start() {
        //Read dialogue csv and save it
        if(dialogueCSV != ""){
            TextAsset textAsset = Resources.Load<TextAsset>(dialogueCSV);
            string[] data = textAsset.text.Split(new char[] {'\n'});

            introDialogue = data[0].Split(new char[] { '|'})[1];
            hateGiftDialogue = data[1].Split(new char[] { '|'})[1];
            dislikeGiftDialogue = data[2].Split(new char[] { '|'})[1];
            neutralGiftDialogue = data[3].Split(new char[] { '|'})[1];
            likeGiftDialogue = data[4].Split(new char[] { '|'})[1];
            loveGiftDialogue = data[5].Split(new char[] { '|'})[1];
            questDialogue = data[6].Split(new char[] { '|'})[1];

            zeroHeartsDialogue = data[7].Split(new char[] { '|'});
            twoHeartsDialogue = data[8].Split(new char[] { '|'});

        }

        //Add to list of npcs
        NPC_Manager.instance.npcs.Add(this);
        Time_Manager.instance.scripts.Add(this);
    }


    public override void Interact() {
        if(canTalk){
            Dialogue_Manager.instance.StartDialogue(GetDialogue(), this);
        }
    }

    public Dialogue GetDialogue(){
        if(!talkedToday){
            talkedToday = true;
            relationship++;
            Dialogue ret;

            //Check unique dialogue
            if(!metPlayer){
                metPlayer = true;
                ret = new Dialogue(npcName, introDialogue, icon);
                currentDialogue = ret;
                return ret;
            }

            //Standard dialogue
            if(relationship < relationshipPerHeart * 2){
                int rand = Random.Range(1, zeroHeartsDialogue.Length); //Starts at 1 to skip label
                ret = new Dialogue(npcName, zeroHeartsDialogue[rand], icon);
            } else{
                int rand = Random.Range(1, twoHeartsDialogue.Length); //Starts at 1 to skip label
                ret = new Dialogue(npcName, twoHeartsDialogue[rand], icon);
            }
            currentDialogue = ret;
            return ret;
        } else{
            return currentDialogue;
        }
    }

    public virtual Dialogue GetQuestCompleteDialogue(Quest quest){
        //Create object
        Dialogue ret = new Dialogue(npcName, questDialogue, icon);
        return ret;
    }

    public Dialogue GetGiftDialogue(Item item){
        Dialogue ret = null;

        if(item.favor == Item.Favor.hate){
            relationship -= 5;
            ret = new Dialogue(npcName, hateGiftDialogue, icon);
        } else if(item.favor == Item.Favor.dislike){
            relationship -= 1;
            ret = new Dialogue(npcName, dislikeGiftDialogue, icon);
        } else if(item.favor == Item.Favor.neutral){
            relationship += 1;
            ret = new Dialogue(npcName, neutralGiftDialogue, icon);
        } else if(item.favor == Item.Favor.like){
            relationship += 4;
            ret = new Dialogue(npcName, likeGiftDialogue, icon);
        }else if(item.favor == Item.Favor.love){
            relationship += 8;
            ret = new Dialogue(npcName, hateGiftDialogue, icon);
        }
        
        return ret;
    }

    public void NewDay(){
        talkedToday = false;
    }

}
