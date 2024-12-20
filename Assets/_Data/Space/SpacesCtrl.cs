using UnityEngine;

public class SpacesCtrl : Singleton<SpaceCtrl>
{
    [SerializeField] protected SpaceManager manager;
    public SpaceManager Manager => manager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpaceManager();
    }

    protected virtual void LoadSpaceManager()
    {
        if (this.manager != null) return;
        this.manager = GetComponent<SpaceManager>();
        Debug.LogWarning(transform.name + ": LoadSpaceManager", gameObject);
    }
}
