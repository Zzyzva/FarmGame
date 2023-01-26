using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Derrick_Schedule : Schedule
{


    public override void childStart(){
        start = Location.barracksBed;
        
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Patrol town
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.barracksBedPath1);
            queue.Enqueue(Location.barracksBedPath2);
            queue.Enqueue(Location.barracksHallHigh);
            queue.Enqueue(Location.barracksHallLow);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.marketCenter.withWait(15));
            queue.Enqueue(Location.northRoadEdge.withWait(15));
            queue.Enqueue(Location.houseRoadRightCorner.withWait(15));
            queue.Enqueue(Location.houseRoadLeftCorner.withWait(15));
            queue.Enqueue(Location.houseRoadTopCorner);
            queue.Enqueue(Location.forestRoadEdge.withWait(15));
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksChair1Path);
            queue.Enqueue(Location.barracksChair1);
        }

        //Go to tavern
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.barracksChair1Path);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innTable3Chair1Path);
            queue.Enqueue(Location.innTable3Chair1);

        }

        //Go home
        if(hour == 9 && minute == 15 && meridiem == "pm"){
            queue.Enqueue(Location.innTable3Chair1Path);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.barracksPath);
            queue.Enqueue(Location.barracksDoorOutside);
            queue.Enqueue(Location.barracksDoorInside);
            queue.Enqueue(Location.barracksDoorPath);
            queue.Enqueue(Location.barracksHallLow);
            queue.Enqueue(Location.barracksHallHigh);
            queue.Enqueue(Location.barracksBedPath2);
            queue.Enqueue(Location.barracksBedPath1);
            queue.Enqueue(Location.barracksBed);


        }
        
        
    }

    

    
}
