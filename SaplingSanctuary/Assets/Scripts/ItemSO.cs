using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StattoChange stattoChange = new StattoChange();
    public int amountToChangeStat;

    public void UseItem()
    {
        if(stattoChange == StattoChange.Oxygen)
        {
            // Change oxygen stat
        }
    }


    public enum StattoChange
    {
        None,
        Oxygen
    };

}
