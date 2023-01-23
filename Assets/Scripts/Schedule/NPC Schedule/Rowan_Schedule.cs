using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowan_Schedule : Schedule
{

    public override void childStart(){
        start = Location.shepardRowanBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardChair2Path);
            queue.Enqueue(Location.shepardChair2);

        }

        //Go to tree
        if(hour == 9 && minute == 55 && meridiem == "am"){
            queue.Enqueue(Location.shepardChair2Path);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardDoorPath);
            queue.Enqueue(Location.shepardDoorInside);
            queue.Enqueue(Location.shepardDoorOutside);
            queue.Enqueue(Location.shepardPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.rightTreePath);
            queue.Enqueue(Location.rightTreeSpot);
        }

        //Go Home
        if(hour == 2 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.rightTreePath);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.shepardPath);
            queue.Enqueue(Location.shepardDoorOutside);
            queue.Enqueue(Location.shepardDoorInside);
            queue.Enqueue(Location.shepardDoorPath);
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardChair2Path);
            queue.Enqueue(Location.shepardChair2);
        }


        if(hour == 9 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.shepardChair2Path);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardRowanBed);

        }
                
    }
}

