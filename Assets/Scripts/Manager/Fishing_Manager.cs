using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fishing_Manager : MonoBehaviour
{
    public bool fishing = false;
    public bool canCatch = false;
    public bool minigameActive = false;

    int fishTime = 0;
    int fishGoal = 8; //Time to hook fish
    float hookedTime;
    int hookedGoal = 2; //Seconds while fish is hooked until release
    public static Fishing_Manager instance;

    public GameObject hookSymbol;
    GameObject hookSymbolObject;

    public GameObject minigame;
    GameObject minigameObject;

    public Item seaweed;
    public Item bait;

    public float minigameGoal = 150;
    public float minigameDownTick;
    public float minigameDownTickHover;
    float minigameScore = 20;
    Transform fishingBar;



    public Fish[] fishTable;
    Fish hookedFish;

    void Awake()
    {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    public void StartGame(){
        foreach(Fish fish in fishTable){
            fish.numCaught = 0;
        }
    }


    //Counts time until fish bite and time while fish on line
    public void UpdateFishing()
    {
        if(fishing){
            //Increment by random amount, more if player has bait
            int rand;
            if(Inventory_Manager.instance.CheckForItemInHotbar(bait, 1)){
                rand = Random.Range(1,6);
            } else{
                rand = Random.Range(0,5);
            }
            
            fishTime += rand;
            //If we have reached goal
            if(fishTime >= fishGoal){
                fishing = false;
                canCatch = true;
                hookSymbolObject = Instantiate(hookSymbol);
                Vector3 symbolPos = Player_Manager.player.transform.position;
                symbolPos.y += 1;
                hookSymbolObject.transform.position = symbolPos;
                hookedTime = Time.time;
            }
        }
    }

    //Called when the player first hooks a fish
    public void AttemptCatch(Water.Type waterType){
        fishTime = 0;
        fishing = false;
        
        if(hookSymbolObject){
            Destroy(hookSymbolObject);
        }
        if(canCatch){
            canCatch = false;

            int trashChance;
            //If bait, remove it and reduce trash chance
            if(Inventory_Manager.instance.CheckForItemInHotbar(bait, 1)){
                Inventory_Manager.instance.RemoveItem("Bait", 1);
                trashChance = Random.Range(0, 10);
            } else{
                trashChance = Random.Range(0, 5);
            }
            if(trashChance == 0){
                Inventory_Manager.instance.AddItem(seaweed, 1);
                return;
            }
            Time_Manager.instance.canPause = false;
            minigameActive = true;
            minigameObject = Instantiate(minigame);
            minigameObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 10));
            fishingBar = minigameObject.transform.GetChild(0).GetChild(1);

            

            //Pick fish
            int total = 0;
            //Check time
            int time = Time_Manager.instance.GetTime();
            foreach(Fish fishInTable in fishTable){
                if(fishInTable.waterTypes.Contains(waterType)){
                    if(fishInTable.time == Fish.CatchTime.any || (time < 1800 && fishInTable.time == Fish.CatchTime.day) || (time >= 1800 && fishInTable.time == Fish.CatchTime.night)){
                        total += fishInTable.probability;
                    }
                }  
            }
            int rand = Random.Range(0, total);
            foreach(Fish fishInTable in fishTable){
                if(fishInTable.waterTypes.Contains(waterType)){
                    if(rand < fishInTable.probability){
                        if(fishInTable.time == Fish.CatchTime.any || (time < 1800 && fishInTable.time == Fish.CatchTime.day) || (time >= 1800 && fishInTable.time == Fish.CatchTime.night)){
                            hookedFish = fishInTable;
                            break;
                        }
                    } else{
                        rand -= fishInTable.probability;
                    }
                }
            }


            //Set fish stats
            MinigameFish miniFish = minigameObject.transform.GetChild(1).gameObject.GetComponent<MinigameFish>();
            miniFish.type = hookedFish.type;
            miniFish.SetMaxSpeed(hookedFish.speed);
            miniFish.difficulty = hookedFish.difficulty;

            
        } else{
            Player_Manager.player.GetComponent<Player_Movement>().canMove = true;
        }
    }

    //Called when the player successfully catches a fish
    public void EndMinigame(bool success){
        Time_Manager.instance.canPause = true;
        minigameActive = false;
        minigameScore = 20;
        if(success){
            Inventory_Manager.instance.AddItem(hookedFish, 1);
            hookedFish.numCaught++;
            Skills_Manager.instance.AddFishingXP(hookedFish.xp);
        }
        
        if(minigameObject){
            Destroy(minigameObject);
        }
        Player_Manager.CanMove(true);
       
    }


    public void Reel(int amount){
        minigameScore += 11 - amount;
        
        if(minigameScore >= minigameGoal){
            EndMinigame(true);
            
        }

    }

    void Update(){
        if(minigameActive){
            if(minigameObject.GetComponentInChildren<MinigameFish>().hover){
                minigameScore -= minigameDownTickHover * Time.deltaTime;
            } else{
                minigameScore -= minigameDownTick * Time.deltaTime;
            }
            if(minigameScore < 0){
                EndMinigame(false);
            }
            fishingBar.localScale = new Vector3(minigameScore / minigameGoal, 1, 1);
        }
        if(canCatch){
            if(Time.time - hookedTime > hookedGoal){
                canCatch = false;
                fishing = true;
                Destroy(hookSymbolObject);
                fishTime = 0;
            }
        }
    }
}
