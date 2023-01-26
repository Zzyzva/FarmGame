using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lana_Schedule : Schedule
{

    public override void childStart(){
        start = Location.woodsmanLanaBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){

        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanChair2Path);
            queue.Enqueue(Location.woodsmanChair2);
        }


        //Go to tree
        if(hour == 10 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.woodsmanChair2Path);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanDoorPath);
            queue.Enqueue(Location.woodsmanDoorInside);
            queue.Enqueue(Location.woodsmanDoorOutside);
            queue.Enqueue(Location.woodsmanPath1);
            queue.Enqueue(Location.leftTreePath);
            queue.Enqueue(Location.leftTreeSpot);
        }

        //Go home
        if(hour == 2 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.leftTreePath);
            queue.Enqueue(Location.woodsmanPath1);
            queue.Enqueue(Location.woodsmanDoorOutside);
            queue.Enqueue(Location.woodsmanDoorInside);
            queue.Enqueue(Location.woodsmanDoorPath);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanChair2Path);
            queue.Enqueue(Location.woodsmanChair2);
        }

        if(hour == 9 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.woodsmanChair2Path);
            queue.Enqueue(Location.woodsmanHallHigh);
            queue.Enqueue(Location.woodsmanHallLow);
            queue.Enqueue(Location.woodsmanLanaBed);
        }

    }
}
