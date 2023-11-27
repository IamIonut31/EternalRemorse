using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase title;
    public ItemType type;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Both")]
    public Sprite image;
}
public enum ItemType
{
    Key1,
    Key2,
    Book,
    Axe,
    PuzzlePieceLT,
    PuzzlePieceLD,
    PuzzlePieceRT,
    PuzzlePieceRD,
    Mathes,
    Wood,
    SlidingPuzzlePiece
}
