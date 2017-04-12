using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BOY/ New Actor")]
/// <summary>
/// This is used to hold the sprite along with scale information
/// This can be used over and over again inside the performer class
/// </summary>
public class ActorSprite : ScriptableObject {

    public Sprite sprite;
    public Vector2 scale;
}
