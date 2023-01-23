using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dialogue_Manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public CanvasGroup textBox;
    public CanvasGroup giftMenu;
    public Button questButton;
    public Button nextButton;
    public Button giftButton;

    public CanvasGroup responseBox;
    public Button response1;
    public Button response2;

    public Image characterImage;

    public static Dialogue_Manager instance;

    public Script activeScript;

    private Queue<string> sentences;
    private Quest completableQuest;

    public bool dialogueActive = false;

    private void Start() {
        if(instance == null){
            instance = this;
            sentences = new Queue<string>();  
        } else{
            Destroy(gameObject);
        }
    }

    public static Dialogue_Manager getInstance(){
        if(instance == null){
                return new Dialogue_Manager();
            }
            return instance;
    }


    public void StartDialogueBox(Dialogue dialogue){
        nameText.text = dialogue.name;
        characterImage.sprite = dialogue.icon;

        textBox.alpha = 1;
        textBox.interactable = true;
        textBox.blocksRaycasts = true;

        if(Cutscene_Manager.instance.cutsceneIsRunning){
            giftButton.gameObject.SetActive(false);
        } else{
            giftButton.gameObject.SetActive(true);
        }
        
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    

    public void StartDialogue(Dialogue dialogue, Script script){
        if(Time_Manager.instance.Pause()){
            dialogueActive = true;
            activeScript = script;

            completableQuest = Quest_Manager.instance.CheckQuests(dialogue.name);
            if(completableQuest != null){
                questButton.gameObject.SetActive(true);
            }
            
            StartDialogueBox(dialogue);
        }
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        if(sentences.Count == 1 && !Cutscene_Manager.instance.cutsceneIsRunning){
            nextButton.GetComponentInChildren<Text>().text = "Exit";
        } else{
            nextButton.GetComponentInChildren<Text>().text = "Next";
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    public void CompleteQuest(){
        Quest_Manager.instance.CompleteQuest(completableQuest);
        questButton.gameObject.SetActive(false);
        
        Dialogue dialogue = activeScript.GetQuestCompleteDialogue(completableQuest);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void EndDialogue(){
        textBox.alpha = 0;
        textBox.interactable = false;
        textBox.blocksRaycasts = false;

        giftMenu.alpha = 0;
        giftMenu.interactable = false;
        giftMenu.blocksRaycasts = false;

        questButton.gameObject.SetActive(false);
        completableQuest = null;
        activeScript = null;

        responseBox.alpha = 0;
        responseBox.interactable = false;
        responseBox.blocksRaycasts = false;

        if(!Cutscene_Manager.instance.cutsceneIsRunning){
            Time_Manager.instance.Unpause();
        } else{
            Cutscene_Manager.instance.RunCutscene();
        }
        dialogueActive = false;
    }


    public void AcceptGift(Item item){
        Dialogue dialogue = activeScript.GetGiftDialogue(item);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

        giftMenu.alpha = 0;
        giftMenu.interactable = false;
        giftMenu.blocksRaycasts = false;
    }

    public void DialogueChoiceStart(string option1, string option2){
        responseBox.alpha = 1;
        responseBox.interactable = true;
        responseBox.blocksRaycasts = true;

        nextButton.gameObject.SetActive(false);

        response1.GetComponentInChildren<Text>().text = option1;
        response2.GetComponentInChildren<Text>().text = option2;
    }

    public void DialogueChoiceEnd(){
        responseBox.alpha = 0;
        responseBox.interactable = false;
        responseBox.blocksRaycasts = false;

        nextButton.gameObject.SetActive(true);
        EndDialogue();
    }

}
