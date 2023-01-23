using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Johnson_Schedule : Schedule
{

    public override void childStart(){
        start = Location.shepardJohnsonBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Watch sheep
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.shepardJohnsonBedPath1);
            queue.Enqueue(Location.shepardJohnsonBedPath2);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardBackDoor);
            queue.Enqueue(Location.sheepYardEnter);
            queue.Enqueue(Location.sheepYardPath1);
            queue.Enqueue(Location.sheepYardPath2);
            queue.Enqueue(Location.sheepYard1.withWait(45));
            queue.Enqueue(Location.sheepYard2.withWait(45));
            queue.Enqueue(Location.sheepYard3.withWait(45));
            queue.Enqueue(Location.sheepYard4.withWait(45));
            queue.Enqueue(Location.sheepYard5.withWait(45));
            queue.Enqueue(Location.sheepYard2.withWait(45));
            queue.Enqueue(Location.sheepYard3.withWait(45));
            queue.Enqueue(Location.sheepYard4.withWait(45));
            queue.Enqueue(Location.sheepYard5.withWait(45));
            queue.Enqueue(Location.sheepYard1);
            queue.Enqueue(Location.sheepYardPath2);
            queue.Enqueue(Location.sheepYardPath1);
            queue.Enqueue(Location.sheepYardEnter);
            queue.Enqueue(Location.shepardBackDoor);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardChair1Path);
            queue.Enqueue(Location.shepardChair1);
        }

        if(hour == 6 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.shepardChair1Path);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardDoorPath);
            queue.Enqueue(Location.shepardDoorInside);
            queue.Enqueue(Location.shepardDoorOutside);
            queue.Enqueue(Location.shepardPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innBarHallMid);
            queue.Enqueue(Location.innTable2Chair1Path);
            queue.Enqueue(Location.innTable2Chair1);
        }

        if(hour == 10 && minute == 45 && meridiem == "pm"){
            queue.Enqueue(Location.innTable2Chair1Path);
            queue.Enqueue(Location.innBarHallMid);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.shepardPath);
            queue.Enqueue(Location.shepardDoorOutside);
            queue.Enqueue(Location.shepardDoorInside);
            queue.Enqueue(Location.shepardDoorPath);
            queue.Enqueue(Location.shepardHallLow);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardJohnsonBedPath2);
            queue.Enqueue(Location.shepardJohnsonBedPath1);
            queue.Enqueue(Location.shepardJohnsonBed);
        }
            

              
    }
}

