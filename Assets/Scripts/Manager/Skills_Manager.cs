using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills_Manager : MonoBehaviour
{
    public static Skills_Manager instance;

    public static int[] levelThresholds = new int[] {30, 60, 120, 250, 500, 1000};

    public int farmingXP;
    public int farmingLevel;
    public bool farmingNovice;
    public bool farmingIntermediate;
    public bool farmingAdvanced;
    public bool farmingExpert;
    public bool farmingMaster;
    public bool farmingLegendary;

    public int miningXP;
    public int miningLevel;
    public bool miningNovice;
    public bool miningIntermediate;
    public bool miningAdvanced;
    public bool miningExpert;
    public bool miningMaster;
    public bool miningLegendary;

    public int fishingXP;
    public int fishingLevel;
    public bool fishingNovice;
    public bool fishingIntermediate;
    public bool fishingAdvanced;
    public bool fishingExpert;
    public bool fishingMaster;
    public bool fishingLegendary;

    public int forestryXP;
    public int forestryLevel;
    public bool forestryNovice;
    public bool forestryIntermediate;
    public bool forestryAdvanced;
    public bool forestryExpert;
    public bool forestryMaster;
    public bool forestryLegendary;

    public List<SkillRankUp> rankUps;

    void Awake()
    {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    public void StartGame(){
        farmingXP = 0;
        farmingLevel = 0;
        farmingNovice = false;
        farmingIntermediate = false;
        farmingAdvanced = false;
        farmingExpert = false;
        farmingMaster = false;
        farmingLegendary = false;

        miningXP = 0;
        miningLevel = 0;
        miningNovice = false;
        miningIntermediate = false;
        miningAdvanced = false;
        miningExpert = false;
        miningMaster = false;
        miningLegendary = false;

        fishingXP = 0;
        fishingLevel = 0;
        fishingNovice = false;
        fishingIntermediate = false;
        fishingAdvanced = false;
        fishingExpert = false;
        fishingMaster = false;
        fishingLegendary = false;

        forestryXP = 0;
        forestryLevel = 0;
        forestryNovice = false;
        forestryIntermediate = false;
        forestryAdvanced = false;
        forestryExpert = false;
        forestryMaster = false;
        forestryLegendary = false;

        rankUps = new List<SkillRankUp>();
    }

    public void AddFarmingXP(int xp){
        farmingXP += xp;
        int newLevel = CalculateLevel(farmingXP);
        if(farmingLevel < newLevel){
            farmingLevel = newLevel;
            Emote_Manager.instance.SpawnEmoteOnPlayer("SkillUp");
        }
        
    }

    public void AddFishingXP(int xp){
        fishingXP += xp;
        int newLevel = CalculateLevel(fishingXP);
        if(fishingLevel < newLevel){
            fishingLevel = newLevel;
            Emote_Manager.instance.SpawnEmoteOnPlayer("SkillUp");
        }
    }

    public void AddForestryXP(int xp){
        forestryXP += xp;
        int newLevel = CalculateLevel(forestryXP);
        if(forestryLevel < newLevel){
            forestryLevel = newLevel;
            Emote_Manager.instance.SpawnEmoteOnPlayer("SkillUp");
        }
    }

    public void AddMiningXP(int xp){
        miningXP += xp;
        int newLevel = CalculateLevel(miningXP);
        if(miningLevel < newLevel){
            miningLevel = newLevel;
            Emote_Manager.instance.SpawnEmoteOnPlayer("SkillUp");
        }
    }

    public static int GetXPToLevel(int xp){
        int tempXP = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 6; j++){
                tempXP += levelThresholds[i];
                if(xp < tempXP){
                    return tempXP - xp;
                }
            }
            
        }
        return 0;
    }

    public void CalculateAllLevels(){
        farmingLevel = CalculateLevel(farmingXP);
        fishingLevel = CalculateLevel(fishingXP);
        forestryLevel = CalculateLevel(forestryXP);
        miningLevel = CalculateLevel(miningXP);
    }

    public static int GetLevelsMaxXP(int level){
        return levelThresholds[level / 5];
    }

    private static int CalculateLevel(int xp){
        int level = 0;
        int tempXP = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 6; j++){
                tempXP += levelThresholds[i];
                if(xp < tempXP){
                    return level;
                } else{
                    level++;
                }
            }
            
        }
        return 30;
    }

    public bool CheckSkillRanks(){
        bool ret = false;
        //Farming
        if(farmingLevel >= 5 && !farmingNovice){
            farmingNovice = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Novice Farmer", "New seeds available for purchase!"));
        }
        if(farmingLevel >= 10 && !farmingIntermediate){
            farmingIntermediate = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Intermediate Farmer", "New seeds available for purchase!"));
        }
        if(farmingLevel >= 15 && !farmingAdvanced){
            farmingAdvanced = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Advanced Farmer", "TBD"));
        }
        if(farmingLevel >= 20 && !farmingExpert){
            farmingExpert = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Expert Farmer", "TBD"));
        }
        if(farmingLevel >= 25 && !farmingMaster){
            farmingMaster = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Master Farmer", "TBD"));
        }
        if(farmingLevel >= 30 && !farmingLegendary){
            farmingLegendary = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Legendary Farmer", "TBD"));
        }
        //Fishing
        if(fishingLevel >= 5 && !fishingNovice){
            fishingNovice = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Novice Fisher", "TBD"));
        }
        if(fishingLevel >= 10 && !fishingIntermediate){
            fishingIntermediate = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Intermediate Fisher", "TBD"));
        }
        if(fishingLevel >= 15 && !fishingAdvanced){
            fishingAdvanced = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Advanced Fisher", "TBD"));
        }
        if(fishingLevel >= 20 && !fishingExpert){
            fishingExpert = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Expert Fisher", "TBD"));
        }
        if(fishingLevel >= 25 && !fishingMaster){
            fishingMaster = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Master Fisher", "TBD"));
        }
        if(fishingLevel >= 30 && !fishingLegendary){
            fishingLegendary = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Legendary Fisher", "TBD"));
        }
        //Forestry
        if(forestryLevel >= 5 && !forestryNovice){
            forestryNovice = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Novice Forester", "New areas to explore in the forest!"));
        }
        if(forestryLevel >= 10 && !forestryIntermediate){
            forestryIntermediate = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Intermediate Forester", "TBD"));
        }
        if(forestryLevel >= 15 && !forestryAdvanced){
            forestryAdvanced = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Advanced Forester", "TBD"));
        }
        if(forestryLevel >= 20 && !forestryExpert){
            forestryExpert = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Expert Forester", "TBD"));
        }
        if(forestryLevel >= 25 && !forestryMaster){
            forestryMaster = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Master Forester", "TBD"));
        }
        if(forestryLevel >= 30 && !forestryLegendary){
            forestryLegendary = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Legendary Forester", "TBD"));
        }
        //Mining
        if(miningLevel >= 5 && !miningNovice){
            miningNovice = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Novice Miner", "New upgrades available for mines!"));
        }
        if(miningLevel >= 10 && !miningIntermediate){
            miningIntermediate = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Intermediate Miner", "TBD"));
        }
        if(miningLevel >= 15 && !miningAdvanced){
            miningAdvanced = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Advanced Miner", "TBD"));
        }
        if(miningLevel >= 20 && !miningExpert){
            miningExpert = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Expert Miner", "TBD"));
        }
        if(miningLevel >= 25 && !miningMaster){
            miningMaster = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Master Miner", "TBD"));
        }
        if(miningLevel >= 30 && !miningLegendary){
            miningLegendary = true;
            ret = true;
            rankUps.Add(new SkillRankUp("Legendary Miner", "TBD"));
        }
        return ret;
    }
}

public class SkillRankUp{
    public string title;
    public string rewards;

    public SkillRankUp(string title, string rewards){
        this.title = title;
        this.rewards = rewards;
    }
}
