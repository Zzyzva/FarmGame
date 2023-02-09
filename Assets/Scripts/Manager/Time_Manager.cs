using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Month {Spring, Summer, Fall, Winter}

[System.Serializable]
public class Date{
    public int date;
    public Month month = Month.Spring;
    public int year = 1;

    public Date(int date, Month month, int year){
        this.date = date;
        this.month = month;
        this.year = year;
    }

    public void NextDay(){
        date++;
        if(date == 29){
            date = 1;
            if(month == Month.Spring){
                month = Month.Summer;
            } else if(month == Month.Summer){
                month = Month.Fall;
            } else if(month == Month.Fall){
                month = Month.Winter;
            } else if(month == Month.Winter){
                month = Month.Spring;
                year++;
            }
        }
    }

    //1 if this date comes after given date
    //0 if same
    //-1 if this date comes before given one
    public int CompareDate(Date otherDate){
        //Compare year
        if(this.year < otherDate.year){
            return -1;
        }
        if(this.year > otherDate.year){
            return 1;
        }
        //Compare month
        if(this.month < otherDate.month){
            return -1;
        }
        if(this.month > otherDate.month){
            return 1;
        }
        //Compare date
        if(this.date < otherDate.date){
            return -1;
        }
        if(this.date > otherDate.date){
            return 1;
        }
        return 0;
    }
}

public class Time_Manager : MonoBehaviour
{
    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI yearText;
    public Light sun;
    public List<Schedule> schedules;
    public List<Script> scripts;
    public CanvasGroup HUD;


    public int minutes;
    public int hours;
    public string meridiem;
    public string day;
    public Date date;




    public float lastTick;

    public bool pause;
    private float pauseTime;
    private float unpauseTime;
    private bool justUnpaused;

    public bool canPause = true; //set false by things like fishing minigame, or if you are using an item

    public static Time_Manager instance;

    void Awake()
    {
        if(instance == null){
            
            instance = this;
            schedules = new List<Schedule>();
            scripts = new List<Script>();
            date = new Date(1, Month.Spring, 1);
            minutes = 0;
            hours = 7;
            meridiem = "am";
        } else{
            Destroy(gameObject);
        }
        
    }

    public void StartGame(){
        day = "Mon";
        date = new Date(1, Month.Spring, 1);
        pause = true;
    }


    // Update is called once per frame
    void Update()
    {
        //Update Time


        if(!pause){
            if(Time.time - lastTick > 2.5f){
                minutes += (int) (5 * (Time.time - lastTick) / 2.5f);
                lastTick = Time.time;
                 
                //Check valid time
                if(minutes > 59){
                    minutes -= 60;
                    hours++;
                    if(hours == 12){
                        if(meridiem.Equals("am")){
                            meridiem = "pm";
                        } else {
                            meridiem = "am";
                            date.NextDay();
                            ChangeDay();
                        }
                    }
                }
                if(hours > 12){
                    hours -= 12;
                }
                

                //Print Time
                UpdateTimeText();

                //Alert Schedules of time change
                foreach(Schedule s in schedules){
                    s.UpdateSchedule(hours, minutes, meridiem, day);
                }

                //Only update fishing on each tick
                Fishing_Manager.instance.UpdateFishing();
                Mines_Manager.instance.UpdateLight();
                Vendor_Manager.instance.UpdateVendors(hours, minutes, meridiem, day);

                //Change sun brightness
                if(hours > 3 && hours < 8 && meridiem == "pm" ){
                    sun.intensity -= .01f;
                }
                if(hours > 3 && hours < 8 && meridiem == "am"){
                    sun.intensity += .01f;
                }
            }

            if(hours == 2 && minutes == 0 && meridiem == "am"){
                Sleep();
            }
        }    
    }

    public void UpdateTimeText(){
        if(minutes > 9){
            timeText.text = hours + ":" + minutes + " " + meridiem;
        } else {
            timeText.text = hours + ":0" + minutes + " " + meridiem;
        }

        yearText.text = date.month + " Year " + date.year;
        dateText.text = day + " " + date.date;
    }

    //returns the time as one in in military format
    //12:30 pm would be 1230
    //2:45 pm would be 1445
    //STRANGE THING
    //12:00 am will be 24, 1am=25, 2am=26
    //This will make checking times late at night easier
    public int GetTime(){
        int ret = 0;
        ret += minutes;
        ret += hours * 100;
        if(meridiem == "pm" && hours != 12){
            ret += 1200;
        }
        if(meridiem == "am" && hours == 12){
            ret += 1200;
        }
        if(meridiem == "am" && hours < 3){
            ret += 2400;
        }
        return ret;  
    }



    //Returns the time after a given interval
    //interval - the number of MINUTES to be add, less than a day
    //return - the time in miltary format (with with STRANGE THING defined above)

    public int GetTimeAfterInterval(int interval){
        //Convert interval
        int tempMinutes = interval % 60;
        int tempHours = interval / 60;
        string tempMeridiem = meridiem;

        tempMinutes += minutes;
        tempHours += hours;

        //Check valid time
        if(tempMinutes > 59){
            tempMinutes -= 60;
            tempHours++;
        }
                
        //Check for meridiem
        if(tempHours >= 12 && hours < 12){
            if(tempMeridiem.Equals("am")){
                    tempMeridiem = "pm";
            } else {
                tempMeridiem = "am";
            }
        }
            
        //check hours
        if(tempHours > 12){
            tempHours -= 12;
        }

        //Convert time to military
        int ret = 0;
        ret += tempMinutes;
        ret += tempHours * 100;
        if(tempMeridiem == "pm" && tempHours != 12){
            ret += 1200;
        }
        if(tempMeridiem == "am" && tempHours == 12){
            ret += 1200;
        }
        if(meridiem == "am" && hours < 3){
            ret += 2400;
        }
        return ret;

    }



    //Advances the the day. Probably should have been an enum
    void ChangeDay(){
        if(day == "Mon"){
            day = "Tue";
        } else if(day == "Tue"){
            day = "Wed";
        } else if(day == "Wed"){
            day = "Thu";
        } else if(day == "Thu"){
            day = "Fri";
        } else if(day == "Fri"){
            day = "Sat";
        }else if(day == "Sat"){
            day = "Sun";
        } else if(day == "Sun"){
            day = "Mon";
        }
    }


    //Pauses the game
    public bool Pause(){
        if(canPause && !pause){
            pause = true;
            pauseTime = Time.time;
            return true;
        } else{
            return false;
        }
        
    }

    //Unpauses the game
    public void Unpause(){
        if(pause){
            pause = false;
            unpauseTime = Time.time;
            lastTick += (unpauseTime - pauseTime);
        }
        
    }

    //Loads the new day scene and hides UI
    public void Sleep(){
        Fishing_Manager.instance.EndMinigame(false); //If you were fishing, you failed
        LevelLoader.instance.LoadLevel("New Day", new Vector2(0,0));
        Pause();
        //Hide UI
        HUD.alpha = 0f;
        Player_Manager.player.gameObject.SetActive(false);

        //Update quests, happens before wake up in case of game over
        Quest_Manager.instance.NewDay();
        Skills_Manager.instance.CheckSkillRanks();

    }

    //Updates the time and NPC locations for a new day
    public void WakeUp(){
        Menu_Manager.instance.CloseNewDay();
        //Change time
        if(!(hours < 3 && meridiem == "am")){
            ChangeDay();
            date.NextDay();
        }

        hours = 7;
        minutes = 0;
        meridiem = "am";
        //Print Time
                if(minutes > 9){
                    timeText.text = hours + ":" + minutes + " " + meridiem;
                } else {
                    timeText.text = hours + ":0" + minutes + " " + meridiem;
                }
                yearText.text = date.month + " Year " + date.year;
                dateText.text = day + " " + date.date;

        

        //Move npc
        foreach(Schedule s in schedules){
            s.NewDay();
        }
        foreach(Script s in scripts){
            s.NewDay();
        }

        //Update Farming
        Farming_Manager.instance.NewDay();

        //Update Forest
        Forest_Manager.instance.NewDay();

        
        //Get gold
        foreach(Item item in Inventory_Manager.instance.toSell){
            Inventory_Manager.instance.gold += item.count * item.value;
        }
        Inventory_Manager.instance.toSell.Clear();

        //Refill Energy
        Inventory_Manager.instance.energy = Inventory_Manager.instance.maxEnergy;

        //Reset Sun
        sun.intensity = .6f;

        Player_Manager.player.gameObject.SetActive(true);

        //Reset Mines Light
        Mines_Manager.instance.RefillLight();

        //Save Game
        Save_Manager.instance.SaveGame();
        Save_Manager.instance.SaveBackup();

        Time_Manager.instance.Unpause();
        canPause = true;
        LevelLoader.instance.LoadLevel("Player House", new Vector2(5,5));
    }

}
