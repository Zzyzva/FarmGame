using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ForestType {outskirts, inner};


public class ForestPCG : MonoBehaviour
{

    string[,] map;

    public GameObject tree;
    public GameObject fineTree;
    public GameObject berryBush;
    public GameObject rabbit;
    public GameObject lake;
    public GameObject wall;

    public GameObject pathOutInstance;



    int minTrees;
    int maxTrees;

    int minFineTrees;
    int maxFineTrees;

    int minBush;
    int maxBush;

    int minRabbits;
    int maxRabbits;

    int mapSize;

    bool hasLake;



    void Start()
    {
        if(Forest_Manager.instance.map != null){
            map = Forest_Manager.instance.map;
        } else{
            Forest_Manager.instance.map = GenerateMap();
        }
        BuildMap();
        
    }
    string[,] GenerateMap(){

        if(Forest_Manager.instance.forestType == ForestType.outskirts){
            minTrees = 10;
            maxTrees = 15;
            minBush = 4;
            maxBush = 8;
            minRabbits = 0;
            maxRabbits = 2;
            mapSize = 40;
            hasLake = false;
            minFineTrees = 0;
            maxFineTrees = 0;
        } else if(Forest_Manager.instance.forestType == ForestType.inner){
            minTrees = 15;
            maxTrees = 20;
            minBush = 4;
            maxBush = 8;
            minRabbits = 3;
            maxRabbits = 6;
            mapSize = 60;
            hasLake = true;
            minFineTrees = 2;
            maxFineTrees = 4;
        }
        map = new string[mapSize, mapSize];


        int emergency = 0;

        int x = 0;
        int y = 0;

        //Set walls
        for(int i = 0; i < mapSize; i++){
            map[0, i] = "wall";
            map[mapSize - 1, i] = "wall";
            map[i, 0] = "wall";
            map[i, mapSize - 1] = "wall";
        }

        //Set player and exit
        map[mapSize - 1, mapSize / 2] = null;
        map[mapSize - 1, mapSize / 2 + 1] = null;
        map[mapSize - 1, mapSize / 2 - 1] = null;



        //Generate lake
        if(hasLake){
            while(emergency < 1000){
                emergency++;
                x = Random.Range(10, mapSize - 10);
                y = Random.Range(10, mapSize - 10);
                if(map[x,y] == null){
                    map[x,y] = "water";
                    SetAdjacentToString(x, y, "water");
                    SetAdjacentToString(x + 1, y + 1, "water");
                    SetAdjacentToString(x + 1, y - 1, "water");
                    SetAdjacentToString(x - 1, y + 1, "water");
                    SetAdjacentToString(x - 1, y - 1, "water");
                    break;
                }
            }
        }
        

        //Generate Berries
        int numBushes = Random.Range(minBush, maxBush + 1);
        x = Random.Range(8, mapSize - 8);
        y = Random.Range(8, mapSize - 8);
        int tempx = x;
        int tempy = y;
        int direction = Random.Range(0,4);

        for(int i = 0; i < numBushes; i++){
            while(emergency < 1000){
                emergency++;
                //Move the 'brush' over small amount to make patch of berries
                direction += Random.Range(1,4);
                direction %= 4;
                int jump = Random.Range(1,3);
                if(direction == 0){
                    x += jump;
                } else if(direction == 1){
                    x -= jump;
                } else if(direction == 2){
                    y += jump;
                } else{
                    y -= jump;
                }
                if( x > mapSize - 2 || x < 2 ){
                    x = tempx;
                }
                if( y > mapSize - 2 || y < 2 ){
                    y = tempy;
                }
                if(map[x,y] == null){
                    map[x,y] = "bush";
                    break;
                }
            }
        }


        //Generate fine trees
        int numFineTrees = Random.Range(minFineTrees, maxFineTrees + 1);
        for(int i = 0; i < numFineTrees; i++){
            while(emergency < 1000){
                emergency++;
                x = Random.Range(4, mapSize - 4);
                y = Random.Range(4, mapSize - 4);
                if(CheckAdjacentNull(x,y)){
                    map[x,y] = "fineTree";
                    SetAdjacentToString(x, y, "N");
                    break;
                }
            }     
        }


        //Generate trees
        int numTrees = Random.Range(minTrees, maxTrees + 1);
        for(int i = 0; i < numTrees; i++){
            while(emergency < 1000){
                emergency++;
                x = Random.Range(4, mapSize - 4);
                y = Random.Range(4, mapSize - 4);
                if(CheckAdjacentNull(x,y)){
                    map[x,y] = "tree";
                    SetAdjacentToString(x, y, "N");
                    break;
                }
            }     
        }

        

        //Generate Rabbits
        int numRabbits;
        numRabbits = Random.Range(minRabbits, maxRabbits + 1);

        for(int i = 0; i < numRabbits; i++){
            while(emergency < 1000){
                emergency++;
                x = Random.Range(4, mapSize - 4);
                y = Random.Range(4, mapSize - 4);
                if(CheckAdjacentNull(x,y)){
                    map[x,y] = "rabbit";
                    SetAdjacentToString(x, y, "N");
                    break;
                }
            }     
        }
        return map;
    }

    

    public void BuildMap(){
        Player_Manager.player.transform.position = new Vector3(map.GetLength(0) - 2, map.GetLength(0) / 2, 0);
        pathOutInstance.transform.position = new Vector3(map.GetLength(0) + .5f, map.GetLength(0) / 2, 0);
        //Load Objects
        for(int x = 0; x < map.GetLength(0); x++){
            for(int y = 0; y < map.GetLength(1); y++){
                int z = 0;
                string pos = map[x,y];
                GameObject temp = null;
                if(pos == "tree"){
                    temp = Instantiate(tree);
                }else if(pos == "fineTree"){
                    temp = Instantiate(fineTree);
                } else if(pos == "bush"){
                    temp = Instantiate(berryBush);
                } else if(pos == "picked bush"){
                    temp = Instantiate(berryBush);
                    temp.GetComponent<BerryBush>().SetPicked();
                } else if(pos == "rabbit"){
                    temp = Instantiate(rabbit);
                    temp.GetComponent<Rabbit>().SetBounds(map.GetLength(0)- 2, map.GetLength(0) - 2);
                } else if( pos == "dead rabbit"){
                    temp = Instantiate(rabbit);
                    temp.GetComponent<Rabbit>().dead = true;
                }else if(pos == "water"){
                    temp = Instantiate(lake);
                    z = -1;
                } else if(pos == "wall"){
                    temp = Instantiate(wall);
                }

                
                if(temp){
                    if(temp.GetComponent<ForestObject>()){
                        temp.GetComponent<ForestObject>().SetForestPos(x, y);
                    }
                    temp.transform.position = new Vector3(x, y, z);
                }
                
            }
        }

        //Set Camera
        Camera.main.GetComponent<CameraScript>().maxX = map.GetLength(0) - 1;
        Camera.main.GetComponent<CameraScript>().maxY = map.GetLength(0) - 1;
    }


    void SetAdjacentToString(int x, int y, string s){
        map[x + 1, y - 1] = s;
        map[x + 1, y] = s;
        map[x + 1, y + 1] = s;
        map[x, y - 1] = s;
        map[x, y + 1] = s;
        map[x - 1, y - 1] = s;
        map[x - 1, y] = s;
        map[x - 1, y + 1] = s;
    }

    bool CheckAdjacentNull(int x, int y){
        if(
            map[x - 1, y - 1] == null &&
            map[x - 1, y] == null &&
            map[x - 1, y + 1] == null &&
            map[x, y - 1] == null &&
            map[x, y] == null &&
            map[x, y + 1] == null &&
            map[x + 1, y - 1] == null &&
            map[x + 1, y] == null &&
            map[x + 1, y + 1] == null
        ){
            return true;
        } else{
            return false;
        }
    }
}
