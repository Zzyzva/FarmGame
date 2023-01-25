using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location{

    //queue.Enqueue(Location.);

    public Vector3 position;
    public string scene;
    public int wait;

    public static Location sleep = new Location(new Vector3(0,0,0), "NULL");


    /**Sample
    public static Location @DoorPath = new Location(new Vector3(5,3.5f,0), "%");
    public static Location @HallLow = new Location(new Vector3(8,3.5f,0), "%");
    public static Location @HallHigh = new Location(new Vector3(8,6.5f,0), "%");
    public static Location @DoorInside = new Location(new Vector3(5,0,0), "%");
    public static Location @SusanBedPath1 = new Location(new Vector3(14,8.5f,0), "%");
    public static Location @SusanBedPath2 = new Location(new Vector3(14,6.5f,0), "%");
    public static Location @SusanBed = new Location(new Vector3(16.5f,8.5f,0), "%");
    public static Location @MarkBed = new Location(new Vector3(11.5f,1.5f,0), "%");
    public static Location @MarkBedPath = new Location(new Vector3(11.5f,3.5f,0), "%");
    public static Location @BenjiBed = new Location(new Vector3(16.5f,3.5f,0), "%");
    public static Location @Chair1 = new Location(new Vector3(3.25f,6,0), "%");
    public static Location @Chair2 = new Location(new Vector3(6.75f,6,0), "%");
    public static Location @Chair3 = new Location(new Vector3(3.25f,5,0), "%");
    public static Location @Chair1Path = new Location(new Vector3(3.25f,6.5f,0), "%");
    public static Location @Chair2Path = new Location(new Vector3(6.75f,6.5f,0), "%");
    public static Location @Chair3Path = new Location(new Vector3(3.25f,3.5f,0), "%");
    */



    //Market
    public static Location marketCenter = new Location(new Vector3(60,30,0), "Town");
    public static Location leftStallPath = new Location(new Vector3(56, 30, 0), "Town");
    public static Location leftStall = new Location(new Vector3(56, 27, 0), "Town");
    public static Location rightStallPath = new Location(new Vector3(64, 30, 0), "Town");
    public static Location rightStall = new Location(new Vector3(64, 27, 0), "Town");
    public static Location marketTopSpotPath = new Location(new Vector3(60, 35, 0), "Town");
    public static Location marketBottomSpotPath = new Location(new Vector3(60, 34, 0), "Town");
    public static Location marketLeftSpot1 = new Location(new Vector3(55, 35, 0), "Town");
    public static Location marketLeftSpot2 = new Location(new Vector3(57, 35, 0), "Town");
    public static Location marketRightSpot1 = new Location(new Vector3(63, 35, 0), "Town");
    public static Location marketRightSpot2 = new Location(new Vector3(65, 35, 0), "Town");
    public static Location marketRightSpot3 = new Location(new Vector3(64, 34, 0), "Town");

    //Kids' field
    public static Location kebaSpot = new Location(new Vector3(52, 46, 0), "Town");
    public static Location kebaSpotPath = new Location(new Vector3(60, 46, 0), "Town");
    public static Location sophiaSpot = new Location(new Vector3(58, 44, 0), "Town");
    public static Location sophiaSpotPath = new Location(new Vector3(60, 44, 0), "Town");
    public static Location kaleySpot = new Location(new Vector3(54, 46, 0), "Town");
    public static Location jimmySpot = new Location(new Vector3(52, 43, 0), "Town");
    public static Location jimmySpotPath = new Location(new Vector3(60, 43, 0), "Town");
    public static Location benjiSpot = new Location(new Vector3(54, 43, 0), "Town");
    public static Location averySpot = new Location(new Vector3(53, 42, 0), "Town");
    public static Location averySpotPath = new Location(new Vector3(60, 42, 0), "Town");
    

    //Din's Garden
    public static Location gardenPath1 = new Location(new Vector3(9, 30, 0), "Town");
    public static Location gardenPath2 = new Location(new Vector3(12, 30, 0), "Town");
    public static Location garden1 = new Location(new Vector3(9, 33, 0), "Town");
    public static Location garden2 = new Location(new Vector3(9, 35, 0), "Town");
    public static Location garden3 = new Location(new Vector3(12, 35, 0), "Town");
    public static Location garden4 = new Location(new Vector3(12, 33, 0), "Town");

    //Town Roads
    public static Location northRoadEdge = new Location(new Vector3(60, 48, 0), "Town");
    public static Location northRoadEnter = new Location(new Vector3(60, 51, 0), "Town");
    public static Location forestRoadEdge = new Location(new Vector3(2, 30, 0), "Town");
    public static Location forestRoadEnter = new Location(new Vector3(-1, 30, 0), "Town");
    public static Location forestRoadPost = new Location(new Vector3(2, 28, 0), "Town");
    public static Location houseRoadRightCorner = new Location(new Vector3(60, 5, 0), "Town");
    public static Location houseRoadLeftCorner = new Location(new Vector3(23, 5, 0), "Town");
    public static Location houseRoadTopCorner = new Location(new Vector3(23, 30, 0), "Town");

    //Town Tree
    public static Location rightTreePath = new Location(new Vector3(40, 16, 0), "Town");
    public static Location rightTreeSpot = new Location(new Vector3(40, 20, 0), "Town");
    public static Location leftTreePath = new Location(new Vector3(38, 13, 0), "Town");
    public static Location leftTreeSpot = new Location(new Vector3(38, 20, 0), "Town");

    //Chicken Yard
    public static Location chickenYardEnter = new Location(new Vector3(43.5f, 36, 0), "Town");
    public static Location chickenYardPath = new Location(new Vector3(43.5f, 34, 0), "Town");
    public static Location chickenCoop1 = new Location(new Vector3(28, 34, 0), "Town");
    public static Location chickenCoopPath1 = new Location(new Vector3(33, 34, 0), "Town");
    public static Location chickenCoopPath2 = new Location(new Vector3(33, 41, 0), "Town");
    public static Location chickenCoop2 = new Location(new Vector3(28, 41, 0), "Town");

    //Sheep Yard
    public static Location sheepYardEnter = new Location(new Vector3(70, 10, 0), "Town");
    public static Location sheepYardPath1 = new Location(new Vector3(70, 8, 0), "Town");
    public static Location sheepYardPath2 = new Location(new Vector3(73, 8, 0), "Town");
    public static Location sheepYard1 = new Location(new Vector3(73, 11, 0), "Town");
    public static Location sheepYard2 = new Location(new Vector3(73, 26, 0), "Town");
    public static Location sheepYard3 = new Location(new Vector3(90, 26, 0), "Town");
    public static Location sheepYard4 = new Location(new Vector3(90, 5, 0), "Town");
    public static Location sheepYard5 = new Location(new Vector3(73, 5, 0), "Town");

    //Inn Garden
    public static Location innGardenPath1 = new Location(new Vector3(80, 30, 0), "Town");
    public static Location innGarden = new Location(new Vector3(80, 46, 0), "Town");
    public static Location innBarrelsPath1 = new Location(new Vector3(80, 42, 0), "Town");
    public static Location innBarrelsPath2 = new Location(new Vector3(84, 42, 0), "Town");
    public static Location innBarrelsPath3 = new Location(new Vector3(84, 46, 0), "Town");
    public static Location innBarrelsPath4 = new Location(new Vector3(90, 46, 0), "Town");
    public static Location innBarrelsPath5 = new Location(new Vector3(84, 43, 0), "Town");
    public static Location innBarrelsPath6 = new Location(new Vector3(90, 43, 0), "Town");


    //North Farm
    public static Location northFarmTownEnter = new Location(new Vector3(38, -1, 0), "North Farm");
    public static Location northFarmCorner = new Location(new Vector3(38, 35, 0), "North Farm");
    public static Location northFarmEastFarmEnter = new Location(new Vector3(76, 35, 0), "North Farm");
    public static Location northFarmFishingSpotPath = new Location(new Vector3(38, 2, 0), "North Farm");
    public static Location northFarmFishingSpot = new Location(new Vector3(70.5f, 2, 0), "North Farm");


    //Mountain
    public static Location mountainLake = new Location(new Vector3(22,4,0), "Mountain Path");

    //Forest Path
    public static Location forestPathTownEnter = new Location(new Vector3(30, 5, 0), "Forest Path");
    public static Location forestPathForestEnter = new Location(new Vector3(-1, 5, 0), "Forest Path");

    //East Farm
    public static Location eastFarmEnter = new Location(new Vector3(-1, 31, 0), "East Farm");
    
    //Vintius' Farm
    public static Location vintiusFarmPath1 = new Location(new Vector3(8, 31, 0), "North Farm");
    public static Location vintiusFarmPath2 = new Location(new Vector3(18, 31, 0), "North Farm");
    public static Location vintiusFarmPath3 = new Location(new Vector3(28, 31, 0), "North Farm");
    public static Location vintiusFarm1 = new Location(new Vector3(8, 25, 0), "North Farm");
    public static Location vintiusFarm2 = new Location(new Vector3(8, 18, 0), "North Farm");
    public static Location vintiusFarm3 = new Location(new Vector3(8, 11, 0), "North Farm");
    public static Location vintiusFarm4 = new Location(new Vector3(18, 11, 0), "North Farm");
    public static Location vintiusFarm5 = new Location(new Vector3(28, 11, 0), "North Farm");
    public static Location vintiusFarm6 = new Location(new Vector3(28, 18, 0), "North Farm");
    public static Location vintiusFarm7 = new Location(new Vector3(18, 18, 0), "North Farm");
    public static Location vintiusFarm8 = new Location(new Vector3(18, 25, 0), "North Farm");
    public static Location vintiusFarm9 = new Location(new Vector3(28, 25, 0), "North Farm");

    //Vintius' House
    public static Location vintiusDoorPath = new Location(new Vector3(5,3.5f,0), "North Farm Hut");
    public static Location vintiusHallLow = new Location(new Vector3(8,3.5f,0), "North Farm Hut");
    public static Location vintiusHallHigh = new Location(new Vector3(8,6.5f,0), "North Farm Hut");
    public static Location vintiusDoorInside = new Location(new Vector3(5,0,0), "North Farm Hut");
    public static Location vintiusBedPath1 = new Location(new Vector3(14,8.5f,0), "North Farm Hut");
    public static Location vintiusBedPath2 = new Location(new Vector3(14,6.5f,0), "North Farm Hut");
    public static Location vintiusBed = new Location(new Vector3(16.5f,8.5f,0), "North Farm Hut");
    public static Location vintiusChair1 = new Location(new Vector3(3.25f,6,0), "North Farm Hut");
    public static Location vintiusChair1Path = new Location(new Vector3(3.25f,6.5f,0), "North Farm Hut");
    public static Location vintiusDoorOutside = new Location(new Vector3(21, 34, 0), "North Farm");
    public static Location vintiusPath1 = new Location(new Vector3(21, 31, 0), "North Farm");
    public static Location vintiusPath2 = new Location(new Vector3(38, 31, 0), "North Farm");
    public static Location vintiusStorage1 = new Location(new Vector3(14, 31, 0), "North Farm");
    public static Location vintiusStorage2 = new Location(new Vector3(14, 32, 0), "North Farm");
    

    //Nek's House
    public static Location nekHutBed = new Location(new Vector3(8.5f, 8, 0), "Nek Hut");
    public static Location nekHutBedPath = new Location(new Vector3(5, 8, 0), "Nek Hut");
    public static Location nekHutChair = new Location(new Vector3(1.5f, 3, 0), "Nek Hut");
    public static Location nekHutChairPath = new Location(new Vector3(5, 3, 0), "Nek Hut");
    public static Location nekHutDoorInside = new Location(new Vector3(5,0,0), "Nek Hut");
    public static Location nekHutDoorOutside = new Location(new Vector3(60, 34, 0), "East Farm");
    public static Location nekPath1 = new Location(new Vector3(60, 31, 0), "East Farm");
    public static Location nekPath2 = new Location(new Vector3(48, 31, 0), "East Farm");

    //Nek's Farm
    public static Location nekFarm1 = new Location(new Vector3(48, 24, 0), "East Farm");
    public static Location nekFarm2 = new Location(new Vector3(48, 17, 0), "East Farm");
    public static Location nekFarm3 = new Location(new Vector3(48, 10, 0), "East Farm");
    public static Location nekFarm4 = new Location(new Vector3(58, 10, 0), "East Farm");
    public static Location nekFarm5 = new Location(new Vector3(68, 10, 0), "East Farm");
    public static Location nekFarm6 = new Location(new Vector3(68, 17, 0), "East Farm");
    public static Location nekFarm7 = new Location(new Vector3(58, 17, 0), "East Farm");
    public static Location nekFarm8 = new Location(new Vector3(58, 24, 0), "East Farm");
    public static Location nekFarm9 = new Location(new Vector3(68, 24, 0), "East Farm");

    //Matthew Farm House
    public static Location eastFarmHutDoorPath = new Location(new Vector3(5,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutHallLow = new Location(new Vector3(8,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutHallHigh = new Location(new Vector3(8,6.5f,0), "East Farm Hut");
    public static Location eastFarmHutDoorInside = new Location(new Vector3(5,0,0), "East Farm Hut");
    public static Location eastFarmHutTopBedPath1 = new Location(new Vector3(12,8.5f,0), "East Farm Hut");
    public static Location eastFarmHutTopBedPath2 = new Location(new Vector3(12,6.5f,0), "East Farm Hut");
    public static Location eastFarmHutIsabelBed = new Location(new Vector3(16.5f,8.5f,0), "East Farm Hut");
    public static Location eastFarmHutMatthewBed = new Location(new Vector3(14.5f,8.5f,0), "East Farm Hut");
    public static Location eastFarmHutAveryBed = new Location(new Vector3(11.5f,1.7f,0), "East Farm Hut");
    public static Location eastFarmHutAveryBedPath = new Location(new Vector3(11.5f,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutJimmyBed = new Location(new Vector3(15.5f,1.7f,0), "East Farm Hut");
    public static Location eastFarmHutJimmyBedPath = new Location(new Vector3(15.5f,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutKaleyBed = new Location(new Vector3(19.5f,1.7f,0), "East Farm Hut");
    public static Location eastFarmHutKaleyBedPath = new Location(new Vector3(19.5f,3.5f,0), "East Farm Hut");

    public static Location eastFarmHutChair1 = new Location(new Vector3(3.25f,6,0), "East Farm Hut");
    public static Location eastFarmHutChair2 = new Location(new Vector3(6.75f,6,0), "East Farm Hut");
    public static Location eastFarmHutChair3 = new Location(new Vector3(3.25f,5,0), "East Farm Hut");
    public static Location eastFarmHutChair4 = new Location(new Vector3(6.75f,5,0), "East Farm Hut");
    public static Location eastFarmHutChair5 = new Location(new Vector3(5,6.5f,0), "East Farm Hut");
    public static Location eastFarmHutChair1Path = new Location(new Vector3(3.25f,6.5f,0), "East Farm Hut");
    public static Location eastFarmHutChair2Path = new Location(new Vector3(6.75f,6.5f,0), "East Farm Hut");
    public static Location eastFarmHutChair3Path = new Location(new Vector3(3.25f,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutChair4Path = new Location(new Vector3(6.75f,3.5f,0), "East Farm Hut");
    public static Location eastFarmHutDoorOutside = new Location(new Vector3(21,34,0), "East Farm");
    public static Location matthewPath1 = new Location(new Vector3(21,31,0), "East Farm");
    public static Location matthewPath2 = new Location(new Vector3(8,31,0), "East Farm");

    //Matthew's Farm
    public static Location matthewFarm1 = new Location(new Vector3(8, 24, 0), "East Farm");
    public static Location matthewFarm2 = new Location(new Vector3(8, 17, 0), "East Farm");
    public static Location matthewFarm3 = new Location(new Vector3(8, 10, 0), "East Farm");
    public static Location matthewFarm4 = new Location(new Vector3(18, 10, 0), "East Farm");
    public static Location matthewFarm5 = new Location(new Vector3(28, 10, 0), "East Farm");
    public static Location matthewFarm6 = new Location(new Vector3(28, 17, 0), "East Farm");
    public static Location matthewFarm7 = new Location(new Vector3(18, 17, 0), "East Farm");
    public static Location matthewFarm8 = new Location(new Vector3(18, 24, 0), "East Farm");
    public static Location matthewFarm9 = new Location(new Vector3(28, 24, 0), "East Farm");

    //Mountain House
    public static Location mountainHutBed = new Location(new Vector3(8.5f, 8, 0), "Mountain Hut");
    public static Location mountainHutBedPath = new Location(new Vector3(5, 8, 0), "Mountain Hut");
    public static Location mountainHutChair = new Location(new Vector3(1.5f, 3, 0), "Mountain Hut");
    public static Location mountainHutChairPath = new Location(new Vector3(5, 3, 0), "Mountain Hut");
    public static Location mountainHutDoorInside = new Location(new Vector3(5,0,0), "Mountain Hut");
    public static Location mountainHutDoorOutside = new Location(new Vector3(18,7,0), "Mountain Path");
    public static Location mountainHutPath = new Location(new Vector3(18,4,0), "Mountain Path");

    //Church
    public static Location churchPath1 = new Location(new Vector3(8, 40, 0), "Town");
    public static Location churchPath2 = new Location(new Vector3(16, 40, 0), "Town");
    public static Location churchPath3 = new Location(new Vector3(16, 30, 0), "Town");
    public static Location churchYard1 = new Location(new Vector3(16, 43, 0), "Town");
    public static Location churchYard2 = new Location(new Vector3(17, 43, 0), "Town");
    public static Location churchDoorOutside = new Location(new Vector3(8, 43, 0), "Town");

    public static Location churchDoorInside = new Location(new Vector3(9.5f,0,0), "Church");
    public static Location churchSophiaBed = new Location(new Vector3(23.5f,1.5f,0), "Church");
    public static Location churchSophiaBedPath1 = new Location(new Vector3(23.5f,6,0), "Church");
    public static Location churchSophiaBedPath2 = new Location(new Vector3(20.5f,6,0), "Church");
    public static Location churchTrulianBed = new Location(new Vector3(23.5f,9,0), "Church");
    public static Location churchTrulianBedPath = new Location(new Vector3(23.5f,14.5f,0), "Church");
    public static Location churchHallHigh = new Location(new Vector3(20.5f,14.5f,0), "Church");
    public static Location churchHallLow = new Location(new Vector3(20.5f,1.5f,0), "Church");
    public static Location churchAltar = new Location(new Vector3(9.5f,14,0), "Church");
    public static Location churchAltarPath1 = new Location(new Vector3(12.5f,14,0), "Church");
    public static Location churchAltarPath2 = new Location(new Vector3(12.5f,10.5f,0), "Church");
    public static Location churchAltarPath3 = new Location(new Vector3(9.5f,10.5f,0), "Church");
    public static Location churchDoorPath = new Location(new Vector3(9.5f,1.5f,0), "Church");

    public static Location churchAisle1 = new Location(new Vector3(9.5f,9,0), "Church");
    public static Location churchAisle1Spot1 = new Location(new Vector3(3,9,0), "Church");
    public static Location churchAisle1Spot2 = new Location(new Vector3(5,9,0), "Church");
    public static Location churchAisle1Spot3 = new Location(new Vector3(7,9,0), "Church");
    public static Location churchAisle1Spot4 = new Location(new Vector3(12,9,0), "Church");
    public static Location churchAisle1Spot5 = new Location(new Vector3(14,9,0), "Church");
    public static Location churchAisle1Spot6 = new Location(new Vector3(16,9,0), "Church");

    //Herbalist Hut
    public static Location herbalistHutPath = new Location(new Vector3(5, 30, 0), "Town");
    public static Location herbalistHutDoorOutside = new Location(new Vector3(5, 33, 0), "Town");
    public static Location herbalistHutDoorInside = new Location(new Vector3(5, 0, 0), "Herbalist Hut");
    public static Location herbalistHutBed = new Location(new Vector3(1.5f, 3.5f, 0), "Herbalist Hut");
    public static Location herbalistHutBedPath = new Location(new Vector3(5, 3.5f, 0), "Herbalist Hut");
    public static Location herbalistHutCauldronPath = new Location(new Vector3(5, 1.5f, 0), "Herbalist Hut");
    public static Location herbalistHutCauldron = new Location(new Vector3(7, 1.5f, 0), "Herbalist Hut");
    
    //Barracks
    public static Location barracksDoorPath = new Location(new Vector3(5,1.5f,0), "Barracks");
    public static Location barracksHallLow = new Location(new Vector3(8,1.5f,0), "Barracks");
    public static Location barracksStoragePath = new Location(new Vector3(13.5f,1.5f,0), "Barracks");
    public static Location barracksStorage = new Location(new Vector3(13.5f,2.5f,0), "Barracks");
    public static Location barracksHallHigh = new Location(new Vector3(8,6.5f,0), "Barracks");
    public static Location barracksDoorInside = new Location(new Vector3(5,0,0), "Barracks");
    public static Location barracksBedPath1 = new Location(new Vector3(14,8.5f,0), "Barracks");
    public static Location barracksBedPath2 = new Location(new Vector3(14,6.5f,0), "Barracks");
    public static Location barracksBed = new Location(new Vector3(16.5f,8.5f,0), "Barracks");
    public static Location barracksChair1 = new Location(new Vector3(3.25f,6,0), "Barracks");
    public static Location barracksChair1Path = new Location(new Vector3(3.25f,1.5f,0), "Barracks");
    public static Location barracksDoorOutside = new Location(new Vector3(86, 33, 0), "Town");
    public static Location barracksPath = new Location(new Vector3(86, 30, 0), "Town");

    //Chicken House
    public static Location chickenDoorPath = new Location(new Vector3(5,3.5f,0), "Chicken Hut");
    public static Location chickenHallLow = new Location(new Vector3(8,3.5f,0), "Chicken Hut");
    public static Location chickenHallHigh = new Location(new Vector3(8,6.5f,0), "Chicken Hut");
    public static Location chickenDoorInside = new Location(new Vector3(5,0,0), "Chicken Hut");
    public static Location chickenMikaBedPath1 = new Location(new Vector3(14,8.5f,0), "Chicken Hut");
    public static Location chickenMikaBedPath2 = new Location(new Vector3(14,6.5f,0), "Chicken Hut");
    public static Location chickenMikaBed = new Location(new Vector3(16.5f,8.5f,0), "Chicken Hut");
    public static Location chickenKebaBed = new Location(new Vector3(16.5f,3.5f,0), "Chicken Hut");
    public static Location chickenChair1 = new Location(new Vector3(3.25f,6,0), "Chicken Hut");
    public static Location chickenChair2 = new Location(new Vector3(6.75f,6,0), "Chicken Hut");
    public static Location chickenChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Chicken Hut");
    public static Location chickenChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Chicken Hut");
    public static Location chickenBackDoorPath = new Location(new Vector3(2,3.5f,0), "Chicken Hut");
    public static Location chickenBackDoor = new Location(new Vector3(2,0,0), "Chicken Hut");
    public static Location chickenDoorOutside = new Location(new Vector3(46, 33, 0), "Town");
    public static Location chickenPath = new Location(new Vector3(46, 30, 0), "Town");

    //Sheep House
    public static Location shepardDoorPath = new Location(new Vector3(5,3.5f,0), "Shepard Hut");
    public static Location shepardHallLow = new Location(new Vector3(8,3.5f,0), "Shepard Hut");
    public static Location shepardHallHigh = new Location(new Vector3(8,6.5f,0), "Shepard Hut");
    public static Location shepardDoorInside = new Location(new Vector3(5,0,0), "Shepard Hut");
    public static Location shepardJohnsonBedPath1 = new Location(new Vector3(14,8.5f,0), "Shepard Hut");
    public static Location shepardJohnsonBedPath2 = new Location(new Vector3(14,6.5f,0), "Shepard Hut");
    public static Location shepardJohnsonBed = new Location(new Vector3(16.5f,8.5f,0), "Shepard Hut");
    public static Location shepardRowanBed = new Location(new Vector3(16.5f,3.5f,0), "Shepard Hut");
    public static Location shepardChair1 = new Location(new Vector3(3.25f,6,0), "Shepard Hut");
    public static Location shepardChair2 = new Location(new Vector3(6.75f,6,0), "Shepard Hut");
    public static Location shepardChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Shepard Hut");
    public static Location shepardChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Shepard Hut");
    public static Location shepardBackDoor = new Location(new Vector3(8,0,0), "Shepard Hut");
    public static Location shepardDoorOutside = new Location(new Vector3(67, 10, 0), "Town");
    public static Location shepardPath = new Location(new Vector3(67,5,0), "Town");


    //Tenant House
    public static Location tenantDoorPath = new Location(new Vector3(5,3.5f,0), "Tenant Hut");
    public static Location tenantHallLow = new Location(new Vector3(8,3.5f,0), "Tenant Hut");
    public static Location tenantHallHigh = new Location(new Vector3(8,6.5f,0), "Tenant Hut");
    public static Location tenantDoorInside = new Location(new Vector3(5,0,0), "Tenant Hut");
    public static Location tenantEmilyBedPath1 = new Location(new Vector3(14,8.5f,0), "Tenant Hut");
    public static Location tenantEmilyBedPath2 = new Location(new Vector3(14,6.5f,0), "Tenant Hut");
    public static Location tenantEmilyBed = new Location(new Vector3(16.5f,8.5f,0), "Tenant Hut");
    public static Location tenantEmilioBed = new Location(new Vector3(16.5f,3.5f,0), "Tenant Hut");
    public static Location tenantChair1 = new Location(new Vector3(3.25f,6,0), "Tenant Hut");
    public static Location tenantChair2 = new Location(new Vector3(6.75f,6,0), "Tenant Hut");
    public static Location tenantChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Tenant Hut");
    public static Location tenantChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Tenant Hut");
    public static Location tenantDoorOutside = new Location(new Vector3(69, 45, 0), "Town");
    public static Location tenantPath1 = new Location(new Vector3(69, 42, 0), "Town");
    public static Location tenantPath2 = new Location(new Vector3(60, 42, 0), "Town");

    //Inn
    public static Location innCharlieBed = new Location(new Vector3(1.5f,16.5f,0), "Inn");
    public static Location innCharlieBedPath1 = new Location(new Vector3(1.5f,18.5f,0), "Inn");
    public static Location innCharlieBedPath2 = new Location(new Vector3(9,18.5f,0), "Inn");
    public static Location innCharlieBedPath3 = new Location(new Vector3(9,19.5f,0), "Inn");
    public static Location innHazelBed = new Location(new Vector3(15.5f,16.5f,0), "Inn");
    public static Location innHazelBedPath = new Location(new Vector3(15.5f,19.5f,0), "Inn");
    public static Location innHazelShelf = new Location(new Vector3(20.5f,18.5f,0), "Inn");
    public static Location innHazelShelfPath = new Location(new Vector3(15.5f,18.5f,0), "Inn");
    public static Location innHallHigh = new Location(new Vector3(12.5f,19.5f,0), "Inn");
    public static Location innHallLow = new Location(new Vector3(12.5f,12.5f,0), "Inn");
    public static Location innBarHallHigh = new Location(new Vector3(1.5f,12.5f,0), "Inn");
    public static Location innBarHallMid = new Location(new Vector3(1.5f,5.5f,0), "Inn");
    public static Location innBarHallLow = new Location(new Vector3(1.5f,2f,0), "Inn");
    public static Location innBar = new Location(new Vector3(8,12.5f,0), "Inn");
    public static Location innTable1 = new Location(new Vector3(5,8.5f,0), "Inn");
    public static Location innTable2 = new Location(new Vector3(10.5f,8.5f,0), "Inn");
    public static Location innTable3 = new Location(new Vector3(5,5.5f,0), "Inn");
    public static Location innTable4 = new Location(new Vector3(10.5f,5.5f,0), "Inn");
    public static Location innTableHallHigh = new Location(new Vector3(7.75f,8.5f,0), "Inn");
    public static Location innTableHallLow = new Location(new Vector3(7.75f,5.5f,0), "Inn");
    public static Location innTable1Chair1Path = new Location(new Vector3(3.75f,5.5f,0), "Inn");
    public static Location innTable1Chair1 = new Location(new Vector3(3.75f,7,0), "Inn");
    public static Location innTable2Chair1Path = new Location(new Vector3(9.25f,5.5f,0), "Inn");
    public static Location innTable2Chair1 = new Location(new Vector3(9.25f,7,0), "Inn");
    public static Location innTable3Chair1Path = new Location(new Vector3(3.75f,2,0), "Inn");
    public static Location innTable3Chair1 = new Location(new Vector3(3.75f,4,0), "Inn");
    public static Location innTable3Chair2Path = new Location(new Vector3(6.25f,2,0), "Inn");
    public static Location innTable3Chair2 = new Location(new Vector3(6.25f,4,0), "Inn");
    public static Location innTable4Chair1Path = new Location(new Vector3(9.25f,2,0), "Inn");
    public static Location innTable4Chair1 = new Location(new Vector3(9.25f,4,0), "Inn");
    public static Location innTable4Chair2Path = new Location(new Vector3(11.75f,2,0), "Inn");
    public static Location innTable4Chair2 = new Location(new Vector3(11.75f,4,0), "Inn");
    public static Location innDoorPath = new Location(new Vector3(5,2,0), "Inn");
    public static Location innDoorInside = new Location(new Vector3(5,0,0), "Inn");
    public static Location innDoorOutside = new Location(new Vector3(75,33,0), "Town");
    public static Location innPath = new Location(new Vector3(75,30,0), "Town");


    //Woodsman Hut
    public static Location woodsmanDoorPath = new Location(new Vector3(5,3.5f,0), "Woodsman Hut");
    public static Location woodsmanHallLow = new Location(new Vector3(8,3.5f,0), "Woodsman Hut");
    public static Location woodsmanHallHigh = new Location(new Vector3(8,6.5f,0), "Woodsman Hut");
    public static Location woodsmanWilliamBedPath1 = new Location(new Vector3(12,8.5f,0), "Woodsman Hut");
    public static Location woodsmanWilliamBedPath2 = new Location(new Vector3(12,6.5f,0), "Woodsman Hut");
    public static Location woodsmanWilliamBed = new Location(new Vector3(16.5f,8.5f,0), "Woodsman Hut");
    public static Location woodsmanOliviaBed = new Location(new Vector3(14.5f,8.5f,0), "Woodsman Hut");
    public static Location woodsmanLanaBed = new Location(new Vector3(16.5f,3.5f,0), "Woodsman Hut");
    public static Location woodsmanChair1 = new Location(new Vector3(3.25f,6,0), "Woodsman Hut");
    public static Location woodsmanChair2 = new Location(new Vector3(6.75f,6,0), "Woodsman Hut");
    public static Location woodsmanChair3 = new Location(new Vector3(3.25f,5,0), "Woodsman Hut");
    public static Location woodsmanChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Woodsman Hut");
    public static Location woodsmanChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Woodsman Hut");
    public static Location woodsmanChair3Path = new Location(new Vector3(3.25f,3.5f,0), "Woodsman Hut");
    public static Location woodsmanDoorInside = new Location(new Vector3(5,0,0), "Woodsman Hut");
    public static Location woodsmanDoorOutside = new Location(new Vector3(30, 17, 0), "Town");
    public static Location woodsmanPath1 = new Location(new Vector3(30, 13, 0), "Town");
    public static Location woodsmanPath2 = new Location(new Vector3(23, 13, 0), "Town");

    //Bakery
    public static Location bakeryDoorPath = new Location(new Vector3(5,3.5f,0), "Bakery");
    public static Location bakeryHallLow = new Location(new Vector3(8,3.5f,0), "Bakery");
    public static Location bakeryHallHigh = new Location(new Vector3(8,6.5f,0), "Bakery");
    public static Location bakeryDoorInside = new Location(new Vector3(5,0,0), "Bakery");
    public static Location bakerySusanBedPath1 = new Location(new Vector3(14,8.5f,0), "Bakery");
    public static Location bakerySusanBedPath2 = new Location(new Vector3(14,6.5f,0), "Bakery");
    public static Location bakerySusanBed = new Location(new Vector3(16.5f,8.5f,0), "Bakery");
    public static Location bakeryMarkBed = new Location(new Vector3(11.5f,1.5f,0), "Bakery");
    public static Location bakeryMarkBedPath = new Location(new Vector3(11.5f,3.5f,0), "Bakery");
    public static Location bakeryBenjiBed = new Location(new Vector3(16.5f,3.5f,0), "Bakery");
    public static Location bakeryChair1 = new Location(new Vector3(3.25f,6,0), "Bakery");
    public static Location bakeryChair2 = new Location(new Vector3(6.75f,6,0), "Bakery");
    public static Location bakeryChair3 = new Location(new Vector3(3.25f,5,0), "Bakery");
    public static Location bakeryChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Bakery");
    public static Location bakeryChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Bakery");
    public static Location bakeryChair3Path = new Location(new Vector3(3.25f,3.5f,0), "Bakery");
    public static Location bakeryDoorOutside = new Location(new Vector3(52, 8, 0), "Town");
    public static Location bakeryPath = new Location(new Vector3(52, 5, 0), "Town");


    //Blacksmith
    public static Location blacksmithDoorPath = new Location(new Vector3(5,3.5f,0), "Blacksmith");
    public static Location blacksmithHallLow = new Location(new Vector3(8,3.5f,0), "Blacksmith");
    public static Location blacksmithHallHigh = new Location(new Vector3(8,6.5f,0), "Blacksmith");
    public static Location blacksmithDoorInside = new Location(new Vector3(5,0,0), "Blacksmith");
    public static Location blacksmithToddBedPath1 = new Location(new Vector3(14,8.5f,0), "Blacksmith");
    public static Location blacksmithToddBedPath2 = new Location(new Vector3(14,6.5f,0), "Blacksmith");
    public static Location blacksmithToddBed = new Location(new Vector3(16.5f,8.5f,0), "Blacksmith");
    public static Location blacksmithGrahamBed = new Location(new Vector3(16.5f,3.5f,0), "Blacksmith");
    public static Location blacksmithChair1 = new Location(new Vector3(3.25f,6,0), "Blacksmith");
    public static Location blacksmithChair2 = new Location(new Vector3(6.75f,6,0), "Blacksmith");
    public static Location blacksmithChair1Path = new Location(new Vector3(3.25f,6.5f,0), "Blacksmith");
    public static Location blacksmithChair2Path = new Location(new Vector3(6.75f,6.5f,0), "Blacksmith");
    public static Location blacksmithForgePath2 = new Location(new Vector3(5,1.5f,0), "Blacksmith");
    public static Location blacksmithForgePath1 = new Location(new Vector3(-3,1.5f,0), "Blacksmith");
    public static Location blacksmithForge = new Location(new Vector3(-3,7,0), "Blacksmith");
    public static Location blacksmithDoorOutside = new Location(new Vector3(47, 19, 0), "Town");
    public static Location blacksmithPath1 = new Location(new Vector3(47, 16, 0), "Town");
    public static Location blacksmithPath2 = new Location(new Vector3(60, 16, 0), "Town");

    
    public Location(Vector3 position, string scene){
        this.position = position;
        this.scene = scene;
        this.wait = 0;
    }

    public Location(Vector3 position, string scene, int wait){
        this.position = position;
        this.scene = scene;
        this.wait = wait;
    }

    //Adds a wait time and return itself
    //Makes declaration easier
    public Location withWait(int wait){
        return new Location(position, scene, wait);
    }

}

