using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills_Manager : MonoBehaviour
{
    public static Skills_Manager instance;

    public static int[] levelThresholds = new int[] {30, 60, 120, 250, 500, 1000};

    public int farmingXP;
    public int farmingLevel;

    public int miningXP;
    public int miningLevel;

    public int fishingXP;
    public int fishingLevel;

    public int forestryXP;
    public int forestryLevel;

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

        miningXP = 0;
        miningLevel = 0;

        fishingXP = 0;
        fishingLevel = 0;

        forestryXP = 0;
        forestryLevel = 0;
    }

    public void AddFarmingXP(int xp){
        farmingXP += xp;
        farmingLevel = CalculateLevel(farmingXP);
    }

    public void AddFishingXP(int xp){
        fishingXP += xp;
        fishingLevel = CalculateLevel(fishingXP);
    }

    public void AddForestryXP(int xp){
        forestryXP += xp;
        forestryLevel = CalculateLevel(forestryXP);
    }

    public void AddMiningXP(int xp){
        miningXP += xp;
        miningLevel = CalculateLevel(miningXP);
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
}
