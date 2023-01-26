using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trulian_Schedule : Schedule
{

    public override void childStart(){
        start = Location.churchTrulianBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Go to Church
        if(hour == 8 && minute == 0 && meridiem == "am"){
            
        }

        //Go to Tavern
        if(hour == 10 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.churchTrulianBedPath);
            queue.Enqueue(Location.churchHallHigh);
            queue.Enqueue(Location.churchHallLow);
            queue.Enqueue(Location.churchDoorPath);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innTable3Chair2Path);
            queue.Enqueue(Location.innTable3Chair2);
        }

        //Watch Sunset
        if(hour == 1 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.innTable3Chair2Path);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchYard1);
            queue.Enqueue(Location.churchYard2);   
        }

        //Go to bed
        if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.churchYard1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorPath);
            queue.Enqueue(Location.churchHallLow);
            queue.Enqueue(Location.churchHallHigh);
            queue.Enqueue(Location.churchTrulianBedPath);
            queue.Enqueue(Location.churchTrulianBed);

        }
        
    }
}
