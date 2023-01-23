using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Fish")]
public class Fish : Item
{
    public enum FishType {random, dash, jagged, spiral};
    public enum CatchTime {any, night, day};

    public float speed;
    public int probability;
    public CatchTime time;
    public FishType type;
    [Range (4,10)] public int difficulty;
    public int xp;

    public int numCaught = 0;

    public List<Water.Type> waterTypes = new List<Water.Type>();
}
