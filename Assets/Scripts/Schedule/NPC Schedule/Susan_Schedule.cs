using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susan_Schedule : Schedule
{

    public override void childStart(){
        start = Location.bakerySusanBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Bed - Table
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.bakerySusanBedPath1);
            queue.Enqueue(Location.bakerySusanBedPath2);
            queue.Enqueue(Location.bakeryChair1Path);
            queue.Enqueue(Location.bakeryChair1);
        }

        //Table - Market
        if(hour == 12 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.bakeryChair1Path);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryDoorPath);
            queue.Enqueue(Location.bakeryDoorInside);
            queue.Enqueue(Location.bakeryDoorOutside);
            queue.Enqueue(Location.bakeryPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.marketLeftSpot1);
        }

        //Market - table
        if(hour == 3 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.bakeryPath);
            queue.Enqueue(Location.bakeryDoorOutside);
            queue.Enqueue(Location.bakeryDoorInside);
            queue.Enqueue(Location.bakeryDoorPath);
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryChair1Path);
            queue.Enqueue(Location.bakeryChair1);
        }

        //Table - bed
        if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.bakeryChair1Path);
            queue.Enqueue(Location.bakerySusanBedPath2);
            queue.Enqueue(Location.bakerySusanBedPath1);
            queue.Enqueue(Location.bakerySusanBed);

        }

              
    }
}
