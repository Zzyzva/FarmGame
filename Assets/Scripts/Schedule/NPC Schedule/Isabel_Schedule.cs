using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isabel_Schedule : Schedule
{

    public override void childStart(){
        start = Location.eastFarmHutIsabelBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutTopBedPath1);
            queue.Enqueue(Location.eastFarmHutTopBedPath2);
            queue.Enqueue(Location.eastFarmHutChair2Path);
            queue.Enqueue(Location.eastFarmHutChair2);

        }

        //Go to market
        if(hour == 11 && minute == 15 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutChair2Path);
            queue.Enqueue(Location.eastFarmHutHallHigh);
            queue.Enqueue(Location.eastFarmHutHallLow);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.marketLeftSpot2);
        }

        //Go home
        if(hour == 3 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutHallLow);
            queue.Enqueue(Location.eastFarmHutHallHigh);
            queue.Enqueue(Location.eastFarmHutChair2Path);
            queue.Enqueue(Location.eastFarmHutChair2);
        }

        if(hour == 9 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.eastFarmHutChair2Path);
            queue.Enqueue(Location.eastFarmHutTopBedPath2);
            queue.Enqueue(Location.eastFarmHutTopBedPath1);
            queue.Enqueue(Location.eastFarmHutIsabelBed);
        }

              
    }
}

