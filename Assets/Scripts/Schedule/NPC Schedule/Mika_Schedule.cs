using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mika_Schedule : Schedule
{

    public override void childStart(){
        start = Location.chickenMikaBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem, string day){

        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.chickenMikaBedPath1);
            queue.Enqueue(Location.chickenMikaBedPath2);
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenChair1);
        }

        //Feed the chickens
        if(hour == 9 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenBackDoorPath);
            queue.Enqueue(Location.chickenBackDoor);
            queue.Enqueue(Location.chickenYardEnter);
            queue.Enqueue(Location.chickenYardPath);
            queue.Enqueue(Location.chickenCoop1.withWait(30));
            queue.Enqueue(Location.chickenCoopPath1);
            queue.Enqueue(Location.chickenCoopPath2);
            queue.Enqueue(Location.chickenCoop2.withWait(30));
            queue.Enqueue(Location.chickenCoopPath2);
            queue.Enqueue(Location.chickenCoopPath1);
            queue.Enqueue(Location.chickenYardPath);
            queue.Enqueue(Location.chickenYardEnter);
            queue.Enqueue(Location.chickenBackDoor);
            queue.Enqueue(Location.chickenBackDoorPath);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenChair1);

        }
        //Check the chickens
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenBackDoorPath);
            queue.Enqueue(Location.chickenBackDoor);
            queue.Enqueue(Location.chickenYardEnter);
            queue.Enqueue(Location.chickenYardPath);
            queue.Enqueue(Location.chickenCoop1.withWait(60));
            queue.Enqueue(Location.chickenCoopPath1);
            queue.Enqueue(Location.chickenCoopPath2);
            queue.Enqueue(Location.chickenCoop2);
        }
        //Return Home
         if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.chickenCoopPath2);
            queue.Enqueue(Location.chickenCoopPath1);
            queue.Enqueue(Location.chickenYardPath);
            queue.Enqueue(Location.chickenYardEnter);
            queue.Enqueue(Location.chickenBackDoor);
            queue.Enqueue(Location.chickenBackDoorPath);
            queue.Enqueue(Location.chickenHallLow);
            queue.Enqueue(Location.chickenHallHigh);
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenChair1);
         }

         if(hour == 9 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.chickenChair1Path);
            queue.Enqueue(Location.chickenMikaBedPath2);
            queue.Enqueue(Location.chickenMikaBedPath1);
            queue.Enqueue(Location.chickenMikaBed);
         }  
    }
}
