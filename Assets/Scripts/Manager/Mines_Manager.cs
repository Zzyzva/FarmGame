using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mines_Manager : MonoBehaviour
{
    public static Mines_Manager instance;

    public CanvasGroup mineUI;
    public TextMeshProUGUI floorText;
    public Slider lightSlider;
    public Light ambientLight;

    public int floor = 0;
    public bool inMines = false;

    int maxLight = 40;
    int currentLight;
    public bool currentFloorLit;

    //Mine Upgrades
    public int lightFloors; //All floors <= are lit
    public int startingFloors; //Each ++ adds one button on "What Level?" Menu

    private void Awake() {
        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
        }
    }

    void Start(){
        RefillLight();
    }

    public void StartGame(){
        lightFloors = 0;
        startingFloors = 0;
    }

    //Called every time time updates 
    public void UpdateLight(){
        if(inMines && !currentFloorLit){
            currentLight--;
            lightSlider.value = currentLight;
            if(currentLight == 0){
                NoLight();
            }
        }
    }

    public void EnterMines(){
        
        if(!Cutscene_Manager.instance.cutsceneIsRunning){
            inMines = true;
            mineUI.alpha = 1;
            lightSlider.maxValue = maxLight;
            lightSlider.value = currentLight;
        }
    }

    public void MoveDeeper(){
        if(!inMines){
            EnterMines();
        }
        floor++;
        floorText.text = floor.ToString();
        if(floor <= lightFloors){
            currentFloorLit = true;
            Instantiate(ambientLight);
        } else {
            currentFloorLit = false;
        }
    }

    public void ExitMines(){
        inMines = false;
        floor = 0;
        mineUI.alpha = 0;
    }

    public void NoLight(){
        ExitMines();
        Time_Manager.instance.Sleep();
    }

    public void RefillLight(){
        currentLight = maxLight;
    }
}
