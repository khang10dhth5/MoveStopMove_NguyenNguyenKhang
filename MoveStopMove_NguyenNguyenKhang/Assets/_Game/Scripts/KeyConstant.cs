using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConstant
{
    public const string CURRENT_WEAPON = "CurrentWeapon_";
    public const string WEAPON = "Weapon_";

    public const string CURRENT_HAT = "CurrentHat";
    public const string HAT = "Hat_";

    public const string CURRENT_PANT = "CurrentPant_";
    public const string PANT = "Pant_";

    public const string MAP_PATH = "Map/Map_";
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
public enum HatType
{
    Arrow,
    Cowboy,
    Crown,
    Ear,
    HeadPhone,
    Horn,
    Police,
    Straw,
}
public enum PantType
{
    Batman,
    Chambi,
    Comy,
    Dabao,
    Onion,
    Pokemon,
    Rainbow,
    Skull,
    Vantim,
}
public enum WeaponType
{
    Axe,
    Boomerang,
    Sword,
}
public enum GameState
{
    Begin,
    Playing,
    EndGame
}
public enum ItemType
{
    Weapon,
    Hat,
    Pant,
}