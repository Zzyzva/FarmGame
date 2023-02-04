using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dirt : Interactable
{


    public bool tilled = false;
    public bool watered = false;
    public bool planted = false;
    public bool ready = false;

    public Sprite tilledDirt;
    public Sprite wateredDirt;
    public Sprite normalDirt;

    public GameObject readySprite;


    public Crop crop;
    public Crop.GrowthPeriod period;
    public int growthDays;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "Player Farm"){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        } else{
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            SetSprites();
        }
    }


    // Start is called before the first frame update


    public void HoeHit(){
            tilled = true;
            SetSprites();
    }

    public void WaterHit(){
        if(tilled && Farming_Manager.instance.waterInCan > 0){
            watered = true;
            SetSprites();
        }
    }

    public void NewDay(){
        if(watered){
            watered = false;
            if(planted && !ready){
                growthDays++;
                if(growthDays == crop.growth[crop.growth.Count - 1].day){
                    ready = true;
                }
            }
        }
        SetSprites();
    }

    public bool PlantSeeds(Crop crop){
        if(!planted && tilled){
            planted = true;
            this.crop = crop;
            period = crop.growth[0];
            growthDays = 0;
            SetSprites();
            return true;
        }
        return false;
        
    }

    public override void Interact(){
        if(ready){
            Inventory_Manager.instance.AddItem(crop.item, crop.numDrops);
            Skills_Manager.instance.AddFarmingXP(crop.xp);
            if(crop.repeatGrowthDays == 0){
                growthDays = 0;
                crop = null;
                planted = false;
            } else{
                growthDays -= crop.repeatGrowthDays;
            }
            readySprite.SetActive(false);
            ready = false;
            
            SetSprites();
        }
    }

    public void SetSprites(){
        if(tilled && !watered){
            gameObject.GetComponent<SpriteRenderer>().sprite = tilledDirt;
        } else if(tilled && watered){
            gameObject.GetComponent<SpriteRenderer>().sprite = wateredDirt;
        } else if(!tilled){
            gameObject.GetComponent<SpriteRenderer>().sprite = normalDirt;
        }
        if(ready){
            readySprite.SetActive(true);
        } else{
            readySprite.SetActive(false);
        }
        if(planted){
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = crop.seeds;
            for(int i = 0; i < crop.growth.Count; i++){
                if(growthDays >= crop.growth[i].day){
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = crop.growth[i].sprite;
                }
            }
        }else{
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
