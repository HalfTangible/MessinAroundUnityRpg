using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicInfo
{
    public string name;
    public string description;
    public Sprite icon;


    public BasicInfo(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public BasicInfo(string name, string description, Sprite icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
    }

    public string getName
    {
        get{ return name; }
    }

    public string getDescription
    {
        get{ return description; }
    }

    public Sprite getIcon
    {
        get{ return icon; }
    }
}
