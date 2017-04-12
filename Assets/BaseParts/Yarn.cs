using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>This is a choice the player is given</summary>
public class Yarn {
    /// <summary>The stitch we will load if chosen</summary>
    public Stitch choiceStitch;
    /// <summary>The string shown for the choice</summary>
    public string choiceString;
}
