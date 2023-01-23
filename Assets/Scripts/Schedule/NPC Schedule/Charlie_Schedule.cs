using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charlie_Schedule : Schedule
{

    public override void childStart(){
        start = Location.innCenter1;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Check barrels
        if(hour == 9 && minute == 0 && meridiem == "am"){
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
            queue.Enqueue(Location.innCenter1);
        }          
    }
}