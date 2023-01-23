using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_Manager : MonoBehaviour
{

    public List<string> cutsceneCSVs = new List<string>();
    public List<Cutscene> cutscenes = new List<Cutscene>();

    public static Cutscene_Manager instance;

    public bool cutsceneIsRunning = false;

    //Used to continue/start cutscene after a scene change
    public bool cutsceneStart = false;
    public bool cutsceneContinue = false;
    public bool cutsceneEnding = false;
    public bool cutsceneCanBeCleared = false;

    Cutscene currentScene;
    int currentSceneCommand = 1; //Start at 1 to skip trigger

    public CanvasGroup cutsceneUI;

    string[] data;

    public List<GameObject> props = new List<GameObject>();
    public List<GameObject> propsInScene = new List<GameObject>();

    //Data for returning to normal after cutscene
    string gameScene;
    Vector2 playerPosition;



    void Awake()
    {
       if(instance){
           Destroy(this);
       }else{
           instance = this;
       }
    }

    public void Start(){
        LoadProps();
    }

    public void StartGame(){
        foreach(Cutscene cutscene in cutscenes){
            cutscene.hasBeenSeen = false;
        }
    }


    public void LoadProps(){
        Object[] propObjects = Resources.LoadAll("Props", typeof(GameObject));
        foreach(Object prop in propObjects){
            props.Add((GameObject)prop);
        }
    }

    //Reads the csv for triggers to load
    public void LoadCutsceneTriggers(){
        foreach (string cutsceneCSV in cutsceneCSVs){
            if(cutsceneCSV != ""){
                TextAsset textAsset = Resources.Load<TextAsset>(cutsceneCSV);
                data = textAsset.text.Split(new char[] {'\n'});

                Cutscene cutscene = new Cutscene();

                cutscene.csv = cutsceneCSV;

                cutscene.sceneName = data[0].Split(new char[] { '|'})[0];
                cutscene.locationTrigger = data[0].Split(new char[] { '|'})[1];
                cutscene.timeTriggerStart = data[0].Split(new char[] { '|'})[2];
                cutscene.timeTriggerEnd = data[0].Split(new char[] { '|'})[3];
                cutscene.characterTrigger = data[0].Split(new char[] { '|'})[4];
                cutscene.characterHeartsTrigger = data[0].Split(new char[] { '|'})[5];

                cutscenes.Add(cutscene);
            }
        }
        

    }

    //Checks all loaded cutscene triggers and sees if any should play
    public void CheckForCutscene(string scene, Vector2 position){
        //Checks each trigger for each cutscene
        //Exits iteration of loop if any trigger fails
        //If trigger does not exist, skip
        //Priority? currently just first read
        foreach(Cutscene cutscene in cutscenes){
            if(cutscene.hasBeenSeen){
                continue;
            }
            if(cutscene.locationTrigger != null && scene != cutscene.locationTrigger){
                continue;
            }
            int currentTime = Time_Manager.instance.GetTime();
            if(cutscene.timeTriggerStart != null && currentTime < int.Parse(cutscene.timeTriggerStart)){
                continue;
            }
            if(cutscene.timeTriggerEnd != null && currentTime > int.Parse(cutscene.timeTriggerEnd)){
                continue;
            }
            if(cutscene.characterTrigger != null){
                Script npc = NPC_Manager.instance.GetNPCByName(cutscene.characterTrigger);
                if(npc.relationship < int.Parse(cutscene.characterHeartsTrigger)){
                    continue;
                }
            }

            gameScene = scene;
            playerPosition = position;

            currentScene = cutscene;
            cutsceneStart = true;
            return;
            
        }
        
    }

    public void Update(){
        if(cutsceneStart){
            cutsceneStart = false;
            SetupCutscene();
        }
        if(cutsceneContinue){
            cutsceneContinue = false;
            RunCutscene();
        }
        if(cutsceneCanBeCleared){
            cutsceneCanBeCleared = false;
            ClearCutscene();
        }
    }


    public void SetupCutscene(){
        //Initial setup for all scenes
        cutsceneIsRunning = true;
        Time_Manager.instance.Pause();
        Time_Manager.instance.HUD.alpha = 0f;
        NPC_Manager.instance.HideNPCs();
        Player_Manager.HidePlayer();
        cutsceneUI.alpha = 1;
        cutsceneUI.interactable = true;
        cutsceneUI.blocksRaycasts = true;

        TextAsset textAsset = Resources.Load<TextAsset>(currentScene.csv);
        data = textAsset.text.Split(new char[] {'\n'});

        RunCutscene();
    }

    public void RunCutscene(){

        if(cutsceneEnding || !cutsceneIsRunning){
            return;
        }
        //Setup scene specifc props
        while(currentSceneCommand < data.Length){
            string command = data[currentSceneCommand];       
            currentSceneCommand++;
            string[] commandData = command.Split(new char[] { '|'});
            string commandType = commandData[0];
            string objectType = commandData[1];


            

            if(commandType == "Spawn"){
                float x = float.Parse(commandData[3]);
                float y = float.Parse(commandData[4]);
                Vector3 position = new Vector3(x,y,0);
                GameObject prop = Instantiate(props.Find((x) => x.name == objectType), position, Quaternion.identity);
                prop.GetComponent<Prop_Movement>().SetTargetLocation(x,y, 0, 0);
                prop.name = objectType;
                propsInScene.Add(prop);
            } else if(commandType == "Despawn"){
                GameObject prop = propsInScene.Find((x) => x.name == objectType);
                propsInScene.Remove(prop);
                Destroy(prop);  
            } else if(commandType == "Move"){
                float x = float.Parse(commandData[3]);
                float y = float.Parse(commandData[4]);
                if(objectType == "Camera"){
                    Camera.main.GetComponent<CameraScript>().SetTargetLocation(x,y,float.Parse(commandData[5]), int.Parse(commandData[2]));
                } else{
                    GameObject prop = propsInScene.Find((x) => x.name == objectType);
                    prop.GetComponent<Prop_Movement>().SetTargetLocation(x,y,float.Parse(commandData[5]), int.Parse(commandData[2]));
                }
                if(float.Parse(commandData[2]) == 1){
                    return;
                }
            } else if(commandType == "Set"){
                float x = float.Parse(commandData[3]);
                float y = float.Parse(commandData[4]);
                if(objectType == "Camera"){
                    Camera.main.transform.position = new Vector3(x,y, -10);
                    Camera.main.GetComponent<CameraScript>().SetTargetLocation(x,y,0, 0);
                } else{
                    GameObject prop = propsInScene.Find((x) => x.name == objectType);
                    prop.transform.position = new Vector3(x,y, 0);
                    prop.GetComponent<Prop_Movement>().SetTargetLocation(x,y, 0, 0);
                }
            } else if(commandType == "Dialogue"){
                GameObject prop = propsInScene.Find((x) => x.name == objectType);
                Dialogue dialogue = prop.GetComponent<Prop_Dialogue>().BuildDialogue(commandData[2]);
                Dialogue_Manager.instance.StartDialogueBox(dialogue);
                return;
            } else if(commandType == "Choice"){
                GameObject prop = propsInScene.Find((x) => x.name == objectType);
                Dialogue dialogue = prop.GetComponent<Prop_Dialogue>().BuildDialogue(commandData[2]);
                Dialogue_Manager.instance.StartDialogueBox(dialogue);
                Dialogue_Manager.instance.DialogueChoiceStart(commandData[3],commandData[4]);
                return;
            } else if(commandType == "Scene"){
                string newScene = commandData[1];
                foreach(GameObject prop in propsInScene){
                    Destroy(prop);
                }
                propsInScene.Clear();
                LevelLoader.instance.LoadLevel(newScene, new Vector2(0,0));
                return;
            } else if(commandType == "Emote"){
                GameObject prop = propsInScene.Find((x) => x.name == objectType);
                Vector3 position = new Vector3(prop.transform.position.x + .5f, prop.transform.position.y + 1.5f, 0);
                Emote_Manager.instance.SpawnEmote(commandData[3], position, int.Parse(commandData[2]));
                if(float.Parse(commandData[2]) == 1){
                    return;
                }
            } else if(commandType == "Wait"){
                float waitTime = float.Parse(commandData[1]);
                StartCoroutine(CutsceneWait(waitTime));
                return;
            }
                
            else{
                Debug.Log("Invalid Cutscene command " + command);
            }
        }
        EndCutscene();
    }

    public void EndCutscene(){
        cutsceneEnding = true;
        LevelLoader.instance.LoadLevel(gameScene,playerPosition);
    }

    public void ClearCutscene(){
        cutsceneEnding = false;
        cutsceneIsRunning = false;
        Dialogue_Manager.instance.EndDialogue();
        NPC_Manager.instance.ShowNPCs();
        Player_Manager.ShowPlayer();
        cutsceneUI.alpha = 0;
        cutsceneUI.interactable = false;
        cutsceneUI.blocksRaycasts = false;

        foreach(GameObject prop in propsInScene){
            Destroy(prop);
        }
        propsInScene.Clear();
        Time_Manager.instance.Unpause();
        Time_Manager.instance.HUD.alpha = 1f;

        currentSceneCommand = 1;

        currentScene.hasBeenSeen = true;

    }

    IEnumerator CutsceneWait(float waitTime){
        yield return new WaitForSeconds(waitTime);
        RunCutscene();
    }
}
