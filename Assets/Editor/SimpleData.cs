using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSimpleData", menuName = "Custom/Simple Data")]
public class SimpleData : ScriptableObject
{
    public int someValue;
    public string someText;
}