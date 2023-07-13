using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DeadlyTestObjects/EnemyType")]

public class EnemyType : ScriptableObject
{
    public int hp;
    public int Damage;
    public float Speed;
    public float ShotTime;
    public float AffectedArea;
    public int BulletsCountMagazine;
    public int BulletsCountAll;
    public float ReloadTime;
    public string Name;
    public string Description;
    

}
