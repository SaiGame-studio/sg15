using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : SaiMonoBehaviour
{
    [SerializeField] protected int currentSpace = 0;
    [SerializeField] protected List<SpaceCtrl> spaces;
    public List<SpaceCtrl> Spaces => spaces;

    protected override void Awake()
    {
        base.Awake();
        this.HideAllSpaces();
    }

    protected override void Start()
    {
        base.Start();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpaces();
    }

    protected virtual void LoadSpaces()
    {
        if (this.spaces.Count > 0) return;
        SpaceCtrl[] arraySpaces = GetComponentsInChildren<SpaceCtrl>();
        this.spaces = new List<SpaceCtrl>(arraySpaces);
        Debug.LogWarning(transform.name + ": LoadSpaces", gameObject);
    }

    protected virtual void HideAllSpaces()
    {
        for(int i = 0; i < this.spaces.Count; i++)
        {         
            this.spaces[i].Hide();
        }

        this.spaces[this.currentSpace].Show();
    }

    protected virtual void ShowNextSpaces()
    {

    }

    protected virtual SpaceCtrl CurrentSpace()
    {
        return this.spaces[this.currentSpace];
    }
}
