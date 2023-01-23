using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emilio_Schedule : Schedule
{

    public override void childStart(){
        start = Location.tenantEmilioBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){
        //Work the fields
        if(hour == 7 && minute == 20 && meridiem == "am"){
            queue.Enqueue(Location.tenantDoorPath);
            queue.Enqueue(Location.tenantDoorInside);
            queue.Enqueue(Location.tenantDoorOutside);
            queue.Enqueue(Location.tenantPath1);
            queue.Enqueue(Location.tenantPath2);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.vintiusFarmPath3);
            queue.Enqueue(Location.vintiusFarm9.withWait(30));
            queue.Enqueue(Location.vintiusFarm8.withWait(30));
            queue.Enqueue(Location.vintiusFarm1.withWait(30));
            queue.Enqueue(Location.vintiusFarm2.withWait(30));
            queue.Enqueue(Location.vintiusFarm3.withWait(30));
            queue.Enqueue(Location.vintiusFarm4.withWait(30));
            queue.Enqueue(Location.vintiusFarm5.withWait(30));
            queue.Enqueue(Location.vintiusFarm6.withWait(30));
            queue.Enqueue(Location.vintiusFarm7.withWait(30));
            queue.Enqueue(Location.vintiusFarm6.withWait(30));
            queue.Enqueue(Location.vintiusFarm5.withWait(30));
            queue.Enqueue(Location.vintiusFarm4.withWait(30));
            queue.Enqueue(Location.vintiusFarm3.withWait(30));
            queue.Enqueue(Location.vintiusFarm2.withWait(30));
            queue.Enqueue(Location.vintiusFarm1.withWait(30));
        }

        //Go to market
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.vintiusFarmPath2);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketBottomSpotPath);
            queue.Enqueue(Location.marketRightSpot3);
        }

        //Go home
        if(hour == 9 && minute == 5 && meridiem == "pm"){
            queue.Enqueue(Location.marketBottomSpotPath);
            queue.Enqueue(Location.tenantPath2);
            queue.Enqueue(Location.tenantPath1);
            queue.Enqueue(Location.tenantDoorOutside);
            queue.Enqueue(Location.tenantDoorInside);
            queue.Enqueue(Location.tenantDoorPath);
            queue.Enqueue(Location.tenantEmilioBed);
        }
              
    }
}
