using UnityEngine;

public class SpaceCtrl : SaiMonoBehaviour
{
    [SerializeField] protected SpacesCtrl spacesCtrl;
    [SerializeField] protected int spaceId = -1;
    [SerializeField] protected int lastSpaceId = -1;
    [SerializeField] protected int nextSpaceId = -1;
    [SerializeField] protected SpaceCtrl lastSpace;
    [SerializeField] protected SpaceCtrl nextSpace;
    [SerializeField] protected Transform lastSpacePosition;
    [SerializeField] protected Transform nextSpacePosition;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpacesCtrl();
        this.LoadYearId();
        this.LoadNextSpaces();
        this.LoadSpacePositions();
    }

    protected virtual void LoadSpacesCtrl()
    {
        if (this.spacesCtrl != null) return;
        this.spacesCtrl = GetComponentInParent<SpacesCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpacesCtrl", gameObject);
    }

    protected virtual void LoadSpacePositions()
    {
        if (this.nextSpacePosition != null && this.lastSpacePosition != null) return;
        this.nextSpacePosition = transform.Find("nextSpaces").Find("nextSpacePosition");
        this.lastSpacePosition = transform.Find("nextSpaces").Find("lastSpacePosition");
        Debug.LogWarning(transform.name + ": LoadSpacePositions", gameObject);
    }

    public virtual string Name()
    {
        return transform.name;
    }

    protected virtual void LoadNextSpaces()
    {
        if (this.nextSpace != null & this.lastSpace != null) return;
        this.lastSpace = this.spacesCtrl.Manager.Spaces[this.lastSpaceId];
        this.nextSpace = this.spacesCtrl.Manager.Spaces[this.nextSpaceId];
        Debug.LogWarning(transform.name + ": LoadNextSpaces", gameObject);
    }

    protected virtual void LoadYearId()
    {
        if (this.spaceId > -1) return;
        this.spaceId = int.Parse(this.Name().Replace("Space_", ""));
        this.nextSpaceId = this.spaceId + 1;
        this.lastSpaceId = this.spaceId - 1;
        if (this.nextSpaceId >= this.spacesCtrl.Manager.Spaces.Count-1) this.nextSpaceId = 0;
        if (this.lastSpaceId < 0) this.lastSpaceId = this.spacesCtrl.Manager.Spaces.Count - 1;
        Debug.LogWarning(transform.name + ": LoadYearId", gameObject);
    }

    public virtual void Show()
    {
        this.nextSpace.MoveTo(this.nextSpacePosition.position);
        this.lastSpace.MoveTo(this.lastSpacePosition.position);
        this.SetActive(true);
    }

    public virtual void Hide()
    {

        this.SetActive(false);
    }

    public virtual void MoveTo(Vector3 position)
    {
        transform.position = position;
        this.SetActive(true);
    }
}
