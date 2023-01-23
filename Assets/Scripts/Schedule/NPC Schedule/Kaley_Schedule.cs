using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaley_Schedule : Schedule
{

    public override void childStart(){
        start = Location.eastFarmHutKaleyBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Go to school
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutKaleyBedPath);
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
            queue.Enqueue(Location.churchRoom);


        }
        //Go to field
        if(hour == 3 && minute == 20 && meridiem == "pm"){
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.kebaSpotPath);
            queue.Enqueue(Location.kaleySpot);

        }

        //Go home
        if(hour == 6 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.kebaSpot);
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
            queue.Enqueue(Location.eastFarmHutChair1);
        }

        if(hour == 8 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.eastFarmHutChair3Path);
            queue.Enqueue(Location.eastFarmHutKaleyBedPath);
            queue.Enqueue(Location.eastFarmHutKaleyBed);
        }

              
    }
}
