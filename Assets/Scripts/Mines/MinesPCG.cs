using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinesPCG : MonoBehaviour
{


    public string[,] map;
    int height;
    int width;

    int totalRocks;
    int totalCoal;
    int totalCopper;

    public Tile background;
    public Tilemap tilemap;

    public GameObject wall;
    public GameObject ladderWall;
    public GameObject rock;
    public GameObject coalRock;
    public GameObject copperRock;

    void Start()
    {
        Mines_Manager.instance.MoveDeeper();

        GetStartingMap();
        GenerateRocks();
        BuildMap();
    }

    public void GetStartingMap(){
        int mapType = Random.Range(0,9);
        string mapName = "Cave" + mapType.ToString();

        ReadCSVMap(mapName);
        totalRocks = Random.Range(40, 75);

    }

    void ReadCSVMap(string csv){
        TextAsset textAsset = Resources.Load<TextAsset>(csv);
        string[] rows = textAsset.text.Split(new char[] {'\n'});
        string[] rowTemp = rows[0].Split(new char[] { ','});
        width = rowTemp.Length;
        height = rows.Length;
        map = new string[width,height];
        for(int i = 0; i < rows.Length; i++){
            string[] rowData = rows[i].Split(new char[] { ','});
            
            int y = rows.Length - i - 1;
            for(int x = 0; x < rowData.Length; x++){
                string cell = rowData[x];
                if(cell == ""){
                    map[x,y] = "void";
                } else if(cell == "X"){
                    map[x,y] = "wall";
                } else if(cell == "O"){
                    tilemap.SetTile(new Vector3Int(x,y,0), background);
                } else if(cell == "L"){
                    map[x,y] = "ladder wall";
                } else if(cell == "P"){
                    map[x,y] = "player";
                     Player_Manager.player.transform.position = new Vector3(x,y,0);
                     tilemap.SetTile(new Vector3Int(x,y,0), background);
                }
            }
        }
    }

    public void GenerateRocks(){
        totalCopper = 0;
        if(Mines_Manager.instance.floor >= 5){
            totalCopper = Random.Range(1,2);
        }

        
        totalCoal = Random.Range(0,5);
        int totalLadders = totalRocks / 12;
        int count = 0;
        while(count < totalLadders){
            int x = Random.Range(1, width - 2);
            int y = Random.Range(1, height - 2);
            if(map[x,y] ==  null ){
                map[x,y] = "ladder rock";
                count++;
            }
        }

        count = 0;
        while(count < totalCopper){
            int x = Random.Range(1, width - 2);
            int y = Random.Range(1, height - 2);
            if(map[x,y] ==  null ){
                map[x,y] = "copper";
                count++;
            }
        }

        count = 0;
        while(count < totalCoal){
            int x = Random.Range(1, width - 2);
            int y = Random.Range(1, height - 2);
            if(map[x,y] ==  null ){
                map[x,y] = "coal";
                count++;
            }
        }

        //Don't need a while loop here since we don't really care how much stone is spawned
        for(int i = 0; i < totalRocks; i++){
            int x = Random.Range(1, width - 2);
            int y = Random.Range(1, height - 2);
            if(map[x,y] ==  null ){
                map[x,y] = "rock";
            }
        }
        
        
    }



    public void BuildMap(){
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                string pos = map[x,y];
                GameObject temp =  null ;
                if(pos == "wall"){
                    temp = Instantiate(wall);
                } else if(pos == "ladder wall"){
                    temp = Instantiate(ladderWall);
                } else if(pos == "rock"){
                    temp = Instantiate(rock);
                } else if(pos == "coal"){
                    temp = Instantiate(coalRock);
                } else if(pos == "ladder rock"){
                    temp = Instantiate(rock);
                    temp.GetComponent<Rock>().dropLadder = true;
                    temp.GetComponent<Rock>().dropXP = 6;
                } else if(pos == "copper"){
                    temp = Instantiate(copperRock);
                }
                
                if(temp){
                    temp.transform.position = new Vector3(x, y, -1);
                }
                
            }
        }
    }
}
