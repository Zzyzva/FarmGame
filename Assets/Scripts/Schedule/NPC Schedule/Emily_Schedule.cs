using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emily_Schedule : Schedule
{

    public override void childStart(){
        start = Location.tenantEmilyBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){
        //Work the fields
        if(hour == 7 && minute == 15 && meridiem == "am"){
            queue.Enqueue(Location.tenantEmilyBedPath1);
            queue.Enqueue(Location.tenantEmilyBedPath2);
            queue.Enqueue(Location.tenantHallHigh);
            queue.Enqueue(Location.tenantHallLow);
            queue.Enqueue(Location.tenantDoorPath);
            queue.Enqueue(Location.tenantDoorInside);
            queue.Enqueue(Location.tenantDoorOutside);
            queue.Enqueue(Location.tenantPath1);
            queue.Enqueue(Location.tenantPath2);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.vintiusFarmPath1);
            queue.Enqueue(Location.vintiusFarm1.withWait(30));
            queue.Enqueue(Location.vintiusFarm2.withWait(30));
            queue.Enqueue(Location.vintiusFarm3.withWait(30));
            queue.Enqueue(Location.vintiusFarm4.withWait(30));
            queue.Enqueue(Location.vintiusFarm5.withWait(30));
            queue.Enqueue(Location.vintiusFarm6.withWait(30));
            queue.Enqueue(Location.vintiusFarm7.withWait(30));
            queue.Enqueue(Location.vintiusFarm8.withWait(30));
            queue.Enqueue(Location.vintiusFarm9.withWait(30));
            queue.Enqueue(Location.vintiusFarm8.withWait(30));
            queue.Enqueue(Location.vintiusFarm7.withWait(30));
            queue.Enqueue(Location.vintiusFarm6.withWait(30));
            queue.Enqueue(Location.vintiusFarm5.withWait(30));
            queue.Enqueue(Location.vintiusFarm4.withWait(30));
            queue.Enqueue(Location.vintiusFarm3.withWait(30));
        }


        //Go to market
        if(hour == 5 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.vintiusFarmPath1);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.marketRightSpot2);
        }

        //Go home
        if(hour == 9 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.marketTopSpotPath);
            queue.Enqueue(Location.tenantPath2);
            queue.Enqueue(Location.tenantPath1);
            queue.Enqueue(Location.tenantDoorOutside);
            queue.Enqueue(Location.tenantDoorInside);
            queue.Enqueue(Location.tenantDoorPath);
            queue.Enqueue(Location.tenantHallLow);
            queue.Enqueue(Location.tenantHallHigh);
            queue.Enqueue(Location.tenantEmilyBedPath2);
            queue.Enqueue(Location.tenantEmilyBedPath1);
            queue.Enqueue(Location.tenantEmilyBed);
        }

              
    }
}

