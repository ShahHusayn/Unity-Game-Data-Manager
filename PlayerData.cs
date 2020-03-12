using System;
using System.Collections;
using System.Collections.Generic;

[Serializable()]
public class PlayerData
{
    public int earning;
    public float cgpa;
    public bool isMarried;
    public List<CharactersData> characters = new List<CharactersData>();

    public PlayerData()
    {
    }
}
