using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graham_Schedule : Schedule
{

    public override void childStart(){
        start = Location.blacksmithGrahamBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Go to forge
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.blacksmithDoorPath);
            queue.Enqueue(Location.blacksmithForgePath2);
            queue.Enqueue(Location.blacksmithForgePath1);
            queue.Enqueue(Location.blacksmithForge);

        }
        //Go to market
        if(hour == 5 && minute == 50 && meridiem == "pm"){
            queue.Enqueue(Location.blacksmithForgePath1);
            queue.Enqueue(Location.blacksmithForgePath2);
            queue.Enqueue(Location.blacksmithDoorInside);
            queue.Enqueue(Location.blacksmithDoorOutside);
            queue.Enqueue(Location.blacksmithPath1);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.marketRightSpot1);
        }

        //Go home
        if(hour == 9 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.blacksmithPath2);
            queue.Enqueue(Location.blacksmithPath1);
            queue.Enqueue(Location.blacksmithDoorOutside);
            queue.Enqueue(Location.blacksmithDoorInside);
            queue.Enqueue(Location.blacksmithDoorPath);
            queue.Enqueue(Location.blacksmithGrahamBed);
        }
              
    }
}

