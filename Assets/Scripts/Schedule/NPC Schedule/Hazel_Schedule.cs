using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazel_Schedule : Schedule
{

    public override void childStart(){
        start = Location.innCenter2;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Check garden
        if(hour == 1 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innGarden);
        }


        //Go to tavern
        if(hour == 4 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innCenter2);
        }

              
    }
}
