using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects")]
public class ClassData : ScriptableObject
{
    public float easyDamage;
    public float normalDamage;
    public float hardDamage;

    public float easyDEF;
    public float normalDEF;
    public float hardDEF;

}
