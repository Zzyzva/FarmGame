using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vintius_Schedule : Schedule
{

    public override void childStart(){
        start = Location.vintiusBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){

        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.vintiusBedPath1);
            queue.Enqueue(Location.vintiusBedPath2);
            queue.Enqueue(Location.vintiusChair1Path);
            queue.Enqueue(Location.vintiusChair1);
        }


        //Head to tavern
        if(hour == 10 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.vintiusChair1Path);
            queue.Enqueue(Location.vintiusHallHigh);
            queue.Enqueue(Location.vintiusHallLow);
            queue.Enqueue(Location.vintiusDoorPath);
            queue.Enqueue(Location.vintiusDoorInside);
            queue.Enqueue(Location.vintiusDoorOutside);
            queue.Enqueue(Location.vintiusPath1);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innTable3Chair1Path);
            queue.Enqueue(Location.innTable3Chair1);
        }

        //Check storage
        if(hour == 1 && minute == 35 && meridiem == "pm"){
            queue.Enqueue(Location.innTable3Chair1Path);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.northRoadEnter);
            queue.Enqueue(Location.northFarmTownEnter);
            queue.Enqueue(Location.vintiusPath2);
            queue.Enqueue(Location.vintiusStorage1);
            queue.Enqueue(Location.vintiusStorage2);
        }

        //Go home
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.vintiusStorage1);
            queue.Enqueue(Location.vintiusPath1);
            queue.Enqueue(Location.vintiusDoorOutside);
            queue.Enqueue(Location.vintiusDoorInside);
            queue.Enqueue(Location.vintiusDoorPath);
            queue.Enqueue(Location.vintiusHallLow);
            queue.Enqueue(Location.vintiusHallHigh);
            queue.Enqueue(Location.vintiusChair1Path);
            queue.Enqueue(Location.vintiusChair1);

        }

        if(hour == 11 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.vintiusChair1Path);
            queue.Enqueue(Location.vintiusBedPath2);
            queue.Enqueue(Location.vintiusBedPath1);
            queue.Enqueue(Location.vintiusBed);
        }
              
    }
}
