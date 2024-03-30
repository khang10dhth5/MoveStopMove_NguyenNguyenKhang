using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConstant
{
    public const string CURRENT_WEAPON = "CurrentWeapon";
    public const string WEAPON = "Weapon";

    public const string CURRENT_HAT = "CurrentHat";
    public const string HAT = "Hat";

    public const string CURRENT_PANT = "CurrentPant";
    public const string PANT = "Pant";
}

public enum TagName
{
    Character,
}
public enum AminState
{
    idle,
    run,
    attack,
    dead,
    win
}