using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class SpaceTrigger : SaiMonoBehaviour
{
    [SerializeField] protected SpaceCtrl spaceCtrl;
    [SerializeField] protected BoxCollider boxCollider;

    protected virtual void OnTriggerEnter()
    {
        this.ShowSpace();
    }

    protected abstract void ShowSpace();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTriggerCollider();
        this.LoadSpaceCtrl();
    }

    protected virtual void LoadTriggerCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector3(40, 3, 2);
        Debug.LogWarning(transform.name + ": LoadTriggerCollider", gameObject);
    }

    protected virtual void LoadSpaceCtrl()
    {
        if (this.spaceCtrl != null) return;
        this.spaceCtrl = GetComponentInParent<SpaceCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpaceCtrl", gameObject);
    }

}
