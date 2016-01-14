/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 013/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * Might be a good idea to have each weapon type be its own base class in which weapons inherit from...
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

//This might not be neccessary, every weapon might hold its own data...
public enum WeaponType
{
    NoWeapon = 0,
    Dagger, Shortsword, Longsword, Greatsword,
    Curvedsword, Katana, 
    Shield, Greatshield,
    Axe, Greataxe,
    Spear, Greatspear, Pole,
    Hammer, Greathammer,

    Whip, Sickle,
    Special, // Unique properties that cannot be defined in any single weapon catagory... Tira's weapon would be an example...
}

public interface IWeapon
{
    void Attack();
    void DealDamage(Collision aTarget);
}
