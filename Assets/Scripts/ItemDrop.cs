using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDrop : MonoBehaviour
{

    public Item item;
    public string sceneName;

    void Start(){
        gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        sceneName = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this);
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.name == sceneName){
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        } else{
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(scene.name == "New Day"){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            if(Inventory_Manager.instance.CanAddItem(item, 1)){
                Inventory_Manager.instance.AddItem(item, 1);
                Destroy(gameObject);
            }
            
       }
   }
}
