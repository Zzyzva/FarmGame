using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benji_Schedule : Schedule
{

    public override void childStart(){
        start = Location.bakeryBenjiBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){
        //Bed to table
        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryChair2Path);
            queue.Enqueue(Location.bakeryChair2);
        }

        //Go to school
        if(hour == 8 && minute == 50 && meridiem == "am"){
            queue.Enqueue(Location.bakeryChair2Path);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryDoorPath);
            queue.Enqueue(Location.bakeryDoorInside);
            queue.Enqueue(Location.bakeryDoorOutside);
            queue.Enqueue(Location.bakeryPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchAisle1Spot4);

        }


        //Go to field
        if(hour == 3 && minute == 15 && meridiem == "pm"){
            queue.Enqueue(Location.churchAisle1);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.jimmySpotPath);
            queue.Enqueue(Location.benjiSpot);
        }


        //Field - table
        if(hour == 6 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.jimmySpotPath);
            queue.Enqueue(Location.houseRoadRightCorner);
            queue.Enqueue(Location.bakeryPath);
            queue.Enqueue(Location.bakeryDoorOutside);
            queue.Enqueue(Location.bakeryDoorInside);
            queue.Enqueue(Location.bakeryDoorPath);
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryChair2Path);
            queue.Enqueue(Location.bakeryChair2);

        }

        //Table - bed
        if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.bakeryChair2Path);
            queue.Enqueue(Location.bakeryHallHigh);
            queue.Enqueue(Location.bakeryHallLow);
            queue.Enqueue(Location.bakeryBenjiBed);

        }

              
    }
}

