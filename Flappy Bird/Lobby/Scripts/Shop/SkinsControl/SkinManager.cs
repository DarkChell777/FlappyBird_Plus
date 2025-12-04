using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkinManager : MonoBehaviour
{
    [SerializeField] protected Image _skin;
    [SerializeField] protected ConfigsController _controller;

    [NonSerialized] public int SkinIndex;

    public abstract void GoToLeft();

    public abstract void GoToRight();

    public abstract void UpdateSkin();

    public abstract void SetSkin(int skin);

    public abstract bool IsUnlock(int skin);

    public abstract bool IsSelectedSkin(int skin);

    public abstract void SaveData();

    public abstract void LoadData();
    
}
