using System;
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
    public const string UI_PATH = "UI/";

    public const string COIN = "Coin";

    public const string TAG_CHACRACTER = "Character";
    public const string KEY_DATA = "DATA";
    public static PoolType ConvertWeaponTypeToPoolType(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Axe:
                return PoolType.AxeWeapon;
            case WeaponType.Boomerang:
                return PoolType.BoomerangWeapon;
            case WeaponType.Sword:
                return PoolType.SwordWeapon;
            default:
                throw new ArgumentException("Invalid weapon type");
        }
        
    }
    public static PoolType ConvertHatTypeToPoolType(HatType hatType)
    {
        switch (hatType)
        {
            case HatType.Arrow:
                return PoolType.ArrowHat;
            case HatType.Cowboy:
                return PoolType.CowboyHat;
            case HatType.Crown:
                return PoolType.CrownHat;
            case HatType.Ear:
                return PoolType.EarHat;
            case HatType.HeadPhone:
                return PoolType.HeadPhoneHat;
            case HatType.Horn:
                return PoolType.HornHat;
            case HatType.Police:
                return PoolType.PolliceHat;
            case HatType.Straw:
                return PoolType.StrawHat;
            default:
                throw new ArgumentException("Invalid hat type");
        }

    }
}

public enum AminState
{
    Idle=0,
    Run=1,
    Attack=2,
    Dead=3,
    Win=4,
}
public enum HatType
{
    Arrow=0,
    Cowboy=1,
    Crown=2,
    Ear=3,
    HeadPhone=4,
    Horn=5,
    Police=6,
    Straw=7,
}
public enum PantType
{
    Batman=0,
    Chambi=1,
    Comy=2,
    Dabao=3,
    Onion=4,
    Pokemon=5,
    Rainbow=6,
    Skull=7,
    Vantim=8,
}
public enum WeaponType
{
    Axe=0,
    Boomerang=1,
    Sword=2,
}
public enum GameState
{
    Begin=0,
    Playing=1,
    EndGame=2,
}
public enum ItemType
{
    Weapon=0,
    Hat=1,
    Pant=2,
}