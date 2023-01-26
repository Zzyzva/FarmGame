using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jimmy_Schedule : Schedule
{

    public override void childStart(){
        start = Location.eastFarmHutJimmyBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Go to school
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutJimmyBedPath);
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
            queue.Enqueue(Location.churchAisle1Spot2);


        }
        //Go to field
        if(hour == 3 && minute == 5 && meridiem == "pm"){
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.jimmySpotPath);
            queue.Enqueue(Location.jimmySpot);

        }

        //Go home
        if(hour == 6 && minute == 5 && meridiem == "pm"){
            queue.Enqueue(Location.jimmySpot);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northFarmCorner);
            queue.Enqueue(Location.northFarmEastFarmEnter);
            queue.Enqueue(Location.eastFarmEnter);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutChair3Path);
            queue.Enqueue(Location.eastFarmHutChair3);
        }

        if(hour == 8 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.eastFarmHutChair3Path);
            queue.Enqueue(Location.eastFarmHutJimmyBedPath);
            queue.Enqueue(Location.eastFarmHutJimmyBed);
        }
              
    }
}
