using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BOY/ New Spool")]
/// <summary>Used to hold the collection of stitches and where we start</summary>
public class Spool : ScriptableObject {
    /// <summary>Store the name of the story, used to show at load time</summary>
    public string storyName;
    /// <summary>Stitch that starts the story!</summary>
    public Stitch startStitch;
    /// <summary>
    /// A collection of ALL of the stitches in the story
    /// if a new one is added, it need to be added to this array.
    /// </summary>
    public Stitch[] stitchCollection;
}
