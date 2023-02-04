using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sophia_Schedule : Schedule
{


    public override void childStart(){
        start = Location.churchSophiaBed;
        
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){

        //Altar
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.churchSophiaBedPath1);
            queue.Enqueue(Location.churchSophiaBedPath2);
            queue.Enqueue(Location.churchHallLow);
            queue.Enqueue(Location.churchDoorPath);
            queue.Enqueue(Location.churchAltarPath3);
            queue.Enqueue(Location.churchAltarPath2);
            queue.Enqueue(Location.churchAltarPath1);
            queue.Enqueue(Location.churchAltar);
        }


        //Go to field
        if(hour == 2 && minute == 50 && meridiem == "pm"){
            queue.Enqueue(Location.churchAltarPath1);
            queue.Enqueue(Location.churchAltarPath2);
            queue.Enqueue(Location.churchAltarPath3);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.sophiaSpotPath);
            queue.Enqueue(Location.sophiaSpot);
        }


        //Go to tavern
        if(hour == 6 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.sophiaSpotPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innBarHallMid);
            queue.Enqueue(Location.innTable1Chair1Path);
            queue.Enqueue(Location.innTable1Chair1);
        }

        //Go home
        if(hour == 12 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.innTable1Chair1Path);
            queue.Enqueue(Location.innBarHallMid);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorPath);
            queue.Enqueue(Location.churchHallLow);
            queue.Enqueue(Location.churchSophiaBedPath2);
            queue.Enqueue(Location.churchSophiaBedPath1);
            queue.Enqueue(Location.churchSophiaBed);
        }
        
    }

    

    
}
