using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Database/Levels/Database Level Item")]
public class LevelItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<LevelItem> levelItems;

    public List<LevelItem> GetLevelItems()
    {
        return levelItems;
    }
}
