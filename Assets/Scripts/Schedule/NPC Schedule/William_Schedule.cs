using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class William_Schedule : Schedule
{

    public override void childStart(){
        start = Location.woodsmanWilliamBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Head to Forest
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.woodsmanWilliamBedPath1);
            queue.Enqueue(Location.woodsmanWilliamBedPath2);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanDoorPath);
            queue.Enqueue(Location.woodsmanDoorInside);
            queue.Enqueue(Location.woodsmanDoorOutside);
            queue.Enqueue(Location.woodsmanPath1);
            queue.Enqueue(Location.woodsmanPath2);
            queue.Enqueue(Location.houseRoadTopCorner);
            queue.Enqueue(Location.forestRoadEnter);
            queue.Enqueue(Location.forestPathTownEnter );
            queue.Enqueue(Location.forestPathForestEnter);
        }

        //Head to Tavern
        if(hour == 5 && minute == 5 && meridiem == "pm"){
            queue.Enqueue(Location.forestPathTownEnter);
            queue.Enqueue(Location.forestRoadEnter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innTable4Chair1Path);
            queue.Enqueue(Location.innTable4Chair1);
        }

        //Return Home
        if(hour == 10 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.innTable4Chair1Path);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.houseRoadTopCorner);
            queue.Enqueue(Location.woodsmanPath2);
            queue.Enqueue(Location.woodsmanPath1);
            queue.Enqueue(Location.woodsmanDoorOutside);
            queue.Enqueue(Location.woodsmanDoorInside);
            queue.Enqueue(Location.woodsmanDoorPath);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanWilliamBedPath2);
            queue.Enqueue(Location.woodsmanWilliamBedPath1);
            queue.Enqueue(Location.woodsmanWilliamBed);
        }

              
    }
}
