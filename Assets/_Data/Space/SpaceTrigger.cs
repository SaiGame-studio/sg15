using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class SpaceTrigger : SaiMonoBehaviour
{
    [Header("Space Trigger")]
    [SerializeField] protected SpaceCtrl spaceCtrl;
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected AbstractDoor door;
    protected abstract string GetDoorName();

    protected virtual void OnTriggerEnter()
    {
        StartCoroutine(this.CheckSpaceAndOpenDoor());
    }

    protected virtual void OnTriggerExit()
    {
        StartCoroutine(this.CheckSpaceAndCloseDoor());
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTriggerCollider();
        this.LoadSpaceCtrl();
        this.LoadDoor();
    }

    protected virtual void LoadDoor()
    {
        if (this.door != null) return;
        string doorName = this.GetDoorName();
        this.door = this.spaceCtrl.Doors.Find(doorName).GetComponent<SliderDoor>();
        Debug.LogWarning(transform.name + ": LoadDoor", gameObject);
    }

    protected virtual void LoadTriggerCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector3(4, 3, 3.5f);
        Debug.LogWarning(transform.name + ": LoadTriggerCollider", gameObject);
    }

    protected virtual void LoadSpaceCtrl()
    {
        if (this.spaceCtrl != null) return;
        this.spaceCtrl = GetComponentInParent<SpaceCtrl>();
        Debug.LogWarning(transform.name + ": LoadSpaceCtrl", gameObject);
    }

    IEnumerator CheckSpaceAndOpenDoor()
    {
        float elapsedTime = 0f;

        while (!this.IsSpaceLoadFinish())
        {
            if (elapsedTime > 7f)
            {
                Debug.LogError("Space load false");
                yield break;
            }
            elapsedTime += 0.1f;
            yield return new WaitForSeconds(0.2f);
        }

        this.door.Open();
    }

    IEnumerator CheckSpaceAndCloseDoor()
    {
        yield return new WaitForSeconds(0.2f);
        this.door.Close();
    }

    protected abstract bool IsSpaceLoadFinish();
}
