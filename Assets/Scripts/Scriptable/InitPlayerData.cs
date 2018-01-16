using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InitPlayerData", menuName = "CreateScriptable/InitPlayerData", order = 1)]
public class InitPlayerData : ScriptableObject
{
    public int life;
    public float pongSpeed;
}
