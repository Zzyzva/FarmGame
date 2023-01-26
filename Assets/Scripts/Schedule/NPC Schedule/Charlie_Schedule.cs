using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charlie_Schedule : Schedule
{

    public override void childStart(){
        start = Location.innCharlieBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){

        //Check barrels
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.innCharlieBedPath1);
            queue.Enqueue(Location.innCharlieBedPath2);
            queue.Enqueue(Location.innCharlieBedPath3);
            queue.Enqueue(Location.innHallHigh);
            queue.Enqueue(Location.innHallLow);
            queue.Enqueue(Location.innBarHallHigh);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innBarrelsPath1);
            queue.Enqueue(Location.innBarrelsPath2);
            queue.Enqueue(Location.innBarrelsPath3);
            queue.Enqueue(Location.innBarrelsPath4.withWait(30));
            queue.Enqueue(Location.innBarrelsPath3);
            queue.Enqueue(Location.innBarrelsPath5);
            queue.Enqueue(Location.innBarrelsPath6.withWait(30));
            queue.Enqueue(Location.innBarrelsPath5);
            queue.Enqueue(Location.innBarrelsPath2);
            queue.Enqueue(Location.innBarrelsPath1);
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innBarHallHigh);
            queue.Enqueue(Location.innBar);
        }


        if(hour == 1 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.innHallLow);
            queue.Enqueue(Location.innHallHigh);
            queue.Enqueue(Location.innCharlieBedPath3);
            queue.Enqueue(Location.innCharlieBedPath2);
            queue.Enqueue(Location.innCharlieBedPath1);
            queue.Enqueue(Location.innCharlieBed);
        }      
    }
}