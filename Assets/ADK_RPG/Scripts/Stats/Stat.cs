using UnityEngine;

[System.Serializable] //fields inside this class shows up on the inspector
public class Stat
{
    [SerializeField] private int baseValue; //when protected by something taken damage decreases when base value increases

    public int getValue() { return baseValue; }

}
