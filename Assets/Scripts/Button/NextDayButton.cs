using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayButton : MonoBehaviour
{
    public void ButtonPress(){
        if(Skills_Manager.instance.rankUps.Count != 0){
            SkillRankUp rankUp = Skills_Manager.instance.rankUps[0];
            Skills_Manager.instance.rankUps.RemoveAt(0);
            Menu_Manager.instance.DisplayRankUp(rankUp);
        } else{
            Time_Manager.instance.WakeUp();
        }
        Menu_Manager.instance.CloseItemsSoldMenu();
        
    }

}
