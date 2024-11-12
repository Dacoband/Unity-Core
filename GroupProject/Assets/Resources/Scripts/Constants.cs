using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public static Dictionary<string, int> FruitScore = new Dictionary<string, int>(){
        {"Apple", 10},
        {"Banana", 20},
        {"Cherries", 30},
        {"Grape", 40},
        {"Kiwi", 50},
        {"Melon", 60},
        {"Orange", 70},
        {"Pineapple", 80},
        {"Strawberry", 100}
    };
    public static Dictionary<string, int> EnemyDamage = new Dictionary<string, int>(){
        {"Slime", 5}
    };
    public static Dictionary<string, int> EnemyScore = new Dictionary<string, int>(){
        {"Slime", 1000}
    };
    public static int PlayerHealth = 100;
}
