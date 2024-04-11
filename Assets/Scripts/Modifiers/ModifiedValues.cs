using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedValues 
{
    public int BaseValue;
    public int FinalValue;

    public ModifiedValues(int baseValue)
    {
        FinalValue = BaseValue = baseValue;
    }
}
