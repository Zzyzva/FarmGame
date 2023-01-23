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

    public float minigameGoal = 150;
    public float minigameDownTick = 2.5f;
    float minigameScore = 20;
    Transform fishingBar;

    float energyCost = 0;



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
            //Increment by random amount
            int rand = Random.Range(0,5);
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

    //Called when the player hooks a fish
    public void AttemptCatch(float energyCost, Water.Type waterType){
        if(canCatch){
            Time_Manager.instance.canPause = false;
            this.energyCost = energyCost;
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
        fishTime = 0;
        fishing = false;
        canCatch = false;
        if(hookSymbolObject){
            Destroy(hookSymbolObject);
        }
        
    }

    //Called when the player successfully catches a fish
    public void EndMinigame(bool success){
        Time_Manager.instance.canPause = true;
        Inventory_Manager.instance.energy -= energyCost;
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
            minigameScore -= minigameDownTick * Time.deltaTime;
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
