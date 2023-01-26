using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avery_Schedule : Schedule
{

    public override void childStart(){
        start = Location.eastFarmHutAveryBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Go to school
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutAveryBedPath);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchAisle1Spot1);


        }
        //Go to field
        if(hour == 3 && minute == 10 && meridiem == "pm"){
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.averySpotPath);
            queue.Enqueue(Location.averySpot);

        }

        //Go home
        if(hour == 6 && minute == 10 && meridiem == "pm"){
            queue.Enqueue(Location.averySpot);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutChair4Path);
            queue.Enqueue(Location.eastFarmHutChair4);
        }

        if(hour == 8 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.eastFarmHutChair4Path);
            queue.Enqueue(Location.eastFarmHutAveryBedPath);
            queue.Enqueue(Location.eastFarmHutAveryBed);
        }
              
    }
}
