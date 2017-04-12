using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BOY/ New Stitch")]
/// <summary>This is a scene in the story</summary>
public class Stitch : ScriptableObject {

    public int stitchID;
    /// <summary>This is purely for designers to help keep track</summary>
    public string stitchName;
    /// <summary>This is purely for designers to help keep track</summary>
    public string summary;
    public Sprite background;   
    public Performer[] performers;
    public Dialog[] dialogs;
    public Yarn[] yarns;
    /// <summary>
    /// Auto is used to mark that a stitch has no choices and will go to the next automatically
    /// </summary>
    public enum stitchStatus { start, end, regular, auto };
    /// <summary>The stitch can only occupy one state at a time</summary>
    public stitchStatus status;
}
