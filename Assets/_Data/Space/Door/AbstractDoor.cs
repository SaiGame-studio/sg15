using UnityEngine;

public abstract class AbstractDoor : SaiMonoBehaviour
{
    [Header("Door")]
    [SerializeField] protected bool isOpen = true;

    public virtual void Open()
    {
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.isOpen = false;
    }
}
