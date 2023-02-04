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

    protected List<string> greetingDialogue = new List<string>();
    protected List<string> zeroHeartsDialogue = new List<string>();
    protected List<string> twoHeartsDialogue = new List<string>();
    public string npcName;
    public Sprite icon;

    public bool metPlayer = false;
    public bool talkedToday = false;
    public bool noGreeting = false;
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

            greetingDialogue.AddRange(data[7].Split(new char[] { '|'}));
            zeroHeartsDialogue.AddRange(data[8].Split(new char[] { '|'}));
            twoHeartsDialogue.AddRange(data[9].Split(new char[] { '|'}));

            greetingDialogue = TrimList(greetingDialogue);
            zeroHeartsDialogue = TrimList(zeroHeartsDialogue);
            twoHeartsDialogue = TrimList(twoHeartsDialogue);
        }

        //Add to list of npcs
        NPC_Manager.instance.npcs.Add(this);
        Time_Manager.instance.scripts.Add(this);
    }

    //This method cleans up some of the funky stuff that the csv files do
    //There is a hidden character in the string of the last value on each line that I can't figure out, so just cleat those and the empty strings all at once
    public List<string> TrimList(List<string> lines){
        List<string> ret = new List<string>();
        foreach(string line in lines){
            if(line.Length >= 2){
                ret.Add(line);
            }
        }
        return ret;
    }


    public override void Interact() {
        if(canTalk){
            Dialogue_Manager.instance.StartDialogue(GetDialogue(), this);
        }
    }

    public Dialogue GetDialogue(){
        //Get greeting
        string greeting;
        if(greetingDialogue.Count > 2){
            int hours = Time_Manager.instance.hours;
            string meridiem = Time_Manager.instance.meridiem;
            if(hours > 6 && meridiem =="am"){
                greeting = greetingDialogue[1];
            } else if((hours < 5 || hours == 12) && meridiem =="pm"){
                greeting = greetingDialogue[2];
            } else{
                greeting = greetingDialogue[3];
            }
            
        } else{
            greeting = greetingDialogue[1];
        }
        if(!talkedToday){
            talkedToday = true;
            relationship++;

            //Check unique dialogue
            if(!metPlayer){
                metPlayer = true;
                currentDialogue = new Dialogue(npcName, introDialogue, icon);
                noGreeting = true;
                return currentDialogue;
            }

            

            //Standard dialogue
            string lines;
            //if(relationship < relationshipPerHeart * 2){
                int rand = Random.Range(1, zeroHeartsDialogue.Count); //Starts at 1 to skip label
                lines = zeroHeartsDialogue[rand]; 
            //} else{
            //    int rand = Random.Range(1, twoHeartsDialogue.Count); //Starts at 1 to skip label
            //    lines = twoHeartsDialogue[rand];
            //}

            currentDialogue = new Dialogue(npcName, lines, icon);

            

        }
        if(noGreeting){
            return currentDialogue;
        }
        return currentDialogue.AddGreeting(greeting);

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
        noGreeting = false;
    }

    public int GetRelationshipHearts(){
        return relationship / relationshipPerHeart;
    }

}
