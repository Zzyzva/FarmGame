using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olivia_Schedule : Schedule
{

    public override void childStart(){
        start = Location.woodsmanOliviaBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.woodsmanWilliamBedPath1);
            queue.Enqueue(Location.woodsmanWilliamBedPath2);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanChair3Path);
            queue.Enqueue(Location.woodsmanChair3);
        }


        //Go to fishing spot
        if(hour == 10 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.woodsmanChair3Path);
            queue.Enqueue(Location.woodsmanDoorPath);
            queue.Enqueue(Location.woodsmanDoorInside);
            queue.Enqueue(Location.woodsmanDoorOutside);
            queue.Enqueue(Location.woodsmanPath1);
            queue.Enqueue(Location.woodsmanPath2);
            queue.Enqueue(Location.houseRoadTopCorner);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northFarmFishingSpotPath);
            queue.Enqueue(Location.northFarmFishingSpot);
        }

        //Go to tavern
        if(hour == 5 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.northFarmFishingSpotPath);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innTable4Chair2Path);
            queue.Enqueue(Location.innTable4Chair2);

        }

        //Return Home
        if(hour == 10 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.innTable4Chair2Path);
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
            queue.Enqueue(Location.woodsmanOliviaBed);
        }

    }
}
