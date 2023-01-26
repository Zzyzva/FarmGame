using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zes_Schedule : Schedule
{

    public override void childStart(){
        start = Location.mountainHutBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Go to chair
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.mountainHutBedPath);
            queue.Enqueue(Location.mountainHutChairPath);
            queue.Enqueue(Location.mountainHutChair);

        }

        //Leave House
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.mountainHutChairPath);
            queue.Enqueue(Location.mountainHutDoorInside);
            queue.Enqueue(Location.mountainHutDoorOutside);
            queue.Enqueue(Location.mountainHutPath);
            queue.Enqueue(Location.mountainLake);
        }

        //Return to House
        if(hour == 11 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.mountainHutPath);
            queue.Enqueue(Location.mountainHutDoorOutside);
            queue.Enqueue(Location.mountainHutDoorInside);
            queue.Enqueue(Location.mountainHutBedPath);
            queue.Enqueue(Location.mountainHutBed);
        }
              
    }
}
