using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Todd_Schedule : Schedule
{

    public override void childStart(){
        start = Location.blacksmithToddBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Go to market
        if(hour == 7 && minute == 40 && meridiem == "am"){
            queue.Enqueue(Location.blacksmithToddBedPath1);
            queue.Enqueue(Location.blacksmithToddBedPath2);
            queue.Enqueue(Location.blacksmithHallHigh);
            queue.Enqueue(Location.blacksmithHallLow);
            queue.Enqueue(Location.blacksmithDoorPath);
            queue.Enqueue(Location.blacksmithDoorInside);
            queue.Enqueue(Location.blacksmithDoorOutside);
            queue.Enqueue(Location.blacksmithPath1);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.rightStallPath);
            queue.Enqueue(Location.rightStall);
        }

        //Go to tavern
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.rightStallPath);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innCenter1);
        }

        //Go home
        if(hour == 10 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.blacksmithPath1);
            queue.Enqueue(Location.blacksmithDoorOutside);
            queue.Enqueue(Location.blacksmithDoorInside);
            queue.Enqueue(Location.blacksmithDoorPath);
            queue.Enqueue(Location.blacksmithHallLow);
            queue.Enqueue(Location.blacksmithHallHigh);
            queue.Enqueue(Location.blacksmithToddBedPath2);
            queue.Enqueue(Location.blacksmithToddBedPath1);
            queue.Enqueue(Location.blacksmithToddBed);

        }

              
    }
}

