using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark_Schedule : Schedule
{

    public override void childStart(){
        start = Location.bakeryMarkBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Bed to Table
        if(hour == 12 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.bakeryMarkBedPath);
            queue.Enqueue(Location.bakeryChair3Path);
            queue.Enqueue(Location.bakeryChair3);
        }

        //Go to barracks
        if(hour == 11 && minute == 15 && meridiem == "pm"){
            queue.Enqueue(Location.bakeryChair3Path);
            queue.Enqueue(Location.bakeryDoorPath);
            queue.Enqueue(Location.bakeryDoorInside);
            queue.Enqueue(Location.bakeryDoorOutside);
            queue.Enqueue(Location.bakeryPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksStoragePath);
            queue.Enqueue(Location.barracksStorage);
            
        }

        //Patrol farms and forest
        if(hour == 2 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.barracksStoragePath);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.nekPath1.withWait(5));
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.forestRoadEdge);
            queue.Enqueue(Location.forestRoadPost);
        }    
              
    }
}

