using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startmoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;
    void Start()
    {
        Money = startmoney; 
        Lives = startLives;

        Rounds = 0;
    }
}
