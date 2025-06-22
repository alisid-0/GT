using UnityEngine;

[System.Serializable]
public class CharacterSaveData
{
    [Header("Character Name")]
    public string chartacterName = "Character";

    [Header("Time Played")]
    public float secondsPlayed;

    // QUESTION: WHY NOT USE A VECTOR3
    // WE CAN ONLY SAVE DATA FROM BASIC VARIABLE TYPES
    [Header("World Coordinate")]
    public float xPosition;
    public float yPosition;
    public float zPosition;
    
}
