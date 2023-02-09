using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ground Data", menuName = "Ground Data")]
public class GroundData : ScriptableObject
{
    public List<GameObject> possibleGround;
    public int maxInSuccession;
}
