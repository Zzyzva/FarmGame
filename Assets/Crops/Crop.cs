using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Crop")]
public class Crop : ScriptableObject
{
    public string cropName;
    public Sprite seeds;

    [Serializable]
    public struct GrowthPeriod {
        public Sprite sprite;
        public int day;
    }

    public List<GrowthPeriod> growth;

    public Item item;
    public int numDrops = 1;
    public int repeatGrowthDays = 0;

    public int xp;
    }
