using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = .5f;
    public static LevelLoader instance;
    public bool outside;

    //This object has a unique instance on every scene, so we use to to reset various things
    private void Start() {
        Menu_Manager.instance.CloseLoadMenu();
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName != "New Day" && !Cutscene_Manager.instance.cutsceneIsRunning && sceneName != "Title" && sceneName != "Start"){
            Time_Manager.instance.Unpause();
        }

        if(Mines_Manager.instance.inMines == true && sceneName != "Mines"){
            Mines_Manager.instance.ExitMines();
        }

        if(!outside){
            Time_Manager.instance.sun.enabled = false;
        } else{
            Time_Manager.instance.sun.enabled = true; 
        }

        if(sceneName == "New Day"){
            Menu_Manager.instance.OpenNewDay();
        }

        
        
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    

    public void LoadLevel(string newScene, Vector2 newPosition){
        StartCoroutine(LoadLevelRoutine(newScene, newPosition));
        
    }



    IEnumerator LoadLevelRoutine(string name, Vector2 newPosition){
        Cutscene_Manager.instance.HideUI();
        Time_Manager.instance.Pause();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
       
        Player_Manager.player.transform.position = newPosition;
        SceneManager.LoadScene(name);
        if(name != "New Day" && !Cutscene_Manager.instance.cutsceneIsRunning && name != "Title"){
            Time_Manager.instance.HUD.alpha = 1f;
        }


        //Cutscene
        if(Cutscene_Manager.instance.cutsceneIsRunning){
            Cutscene_Manager.instance.ShowUI();
            Cutscene_Manager.instance.cutsceneContinue = true;
        }else{
            Cutscene_Manager.instance.CheckForCutscene(name, newPosition);
        }

        if(Cutscene_Manager.instance.cutsceneEnding){
            Cutscene_Manager.instance.cutsceneCanBeCleared = true;
        }

        
    }
}
