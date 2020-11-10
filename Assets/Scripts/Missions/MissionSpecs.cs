using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MissionSpecs
{
    #region INSPECTOR
    [SerializeField]
    protected string name;
    [SerializeField]
    protected string id;
    [SerializeField]
    [Multiline]
    protected string description;
    [SerializeField]
    protected string sceneName;
    [SerializeField]
    protected Sprite image;
    #endregion


    #region PROPERTIES
    public string Id => id;
    public string Name => name;
    public string Description => description;
    public string SceneName => sceneName;
    public Sprite Image => image;
    #endregion
}
