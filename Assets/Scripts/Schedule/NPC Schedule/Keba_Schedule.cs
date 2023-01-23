using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keba_Schedule : Schedule
{

    public override void childStart(){
        start = Location.chickenKebaBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenChair2Path);
            queue.Enqueue(Location.chickenChair2);
        }
        //Go to school
        if(hour == 9 && minute == 5 && meridiem == "am"){
            queue.Enqueue(Location.chickenChair2Path);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenDoorPath);
            queue.Enqueue(Location.chickenDoorInside);
            queue.Enqueue(Location.chickenDoorOutside);
            queue.Enqueue(Location.chickenPath);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchAisle1Spot5);
        }
        //Go to field
        if(hour == 3 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.kebaSpotPath);
            queue.Enqueue(Location.kebaSpot);
        }

        //Go home
        if(hour == 6 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.kebaSpotPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.chickenPath);
            queue.Enqueue(Location.chickenDoorOutside);
            queue.Enqueue(Location.chickenDoorInside);
            queue.Enqueue(Location.chickenDoorPath);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenChair2Path);
            queue.Enqueue(Location.chickenChair2);
        }

        if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.chickenChair2Path);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenKebaBed);
        }

              
    }
}

