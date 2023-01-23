using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming_Manager : MonoBehaviour
{
    public static Farming_Manager instance;
    public List<GameObject> dirt;
    public GameObject dirtObject;

    int plotHeight = 15;
    int plotWidth = 15;
    float plotHeightOffset = 4;
    float plotWidthOffset = 4;

    public float waterInCan;

    public GameObject[] crops;

    private void Awake() {
        if(instance == null){
            instance = this;
            
        } else{
            Destroy(gameObject);
        }
    }

    public void StartGame(){
        foreach(GameObject dirt in dirt){
            Destroy(dirt);
        }
        dirt = new List<GameObject>();
        crops = Resources.LoadAll<GameObject>("Crops");
        for(int i = 0; i < plotWidth; i++){
            for(int j = 0; j < plotHeight; j++){
                GameObject temp = Instantiate(dirtObject, new Vector3(i + plotWidthOffset,j + plotHeightOffset,0), Quaternion.identity);
                temp.transform.parent = gameObject.transform;
                dirt.Add(temp);
                temp.GetComponent<SpriteRenderer>().enabled = false;
                temp.GetComponent<BoxCollider2D>().enabled = false;
                temp.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        waterInCan = 10;
    }



    public void NewDay(){
        foreach(GameObject tile in dirt){
            tile.GetComponent<Dirt>().NewDay();
        }
    }

    public void RefillCan(float maxWater){
        waterInCan = maxWater;
    }
}
