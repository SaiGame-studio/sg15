using System.Collections;
using UnityEngine;

public class SliderDoor : AbstractDoor
{
    [Header("Slider")]
    [SerializeField] protected float duration = 0.3f;

    [SerializeField] protected Transform leftDoor;
    [SerializeField] protected Vector3 leftDoorStartPos;
    [SerializeField] protected Vector3 leftDoorEndPos;

    [SerializeField] protected Transform rightDoor;
    [SerializeField] protected Vector3 rightDoorStartPos;
    [SerializeField] protected Vector3 rightDoorEndPos;

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.Close), 2f);
        //Invoke(nameof(this.Open), 4f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoors();
    }

    protected virtual void LoadDoors()
    {
        if (this.leftDoor != null && this.leftDoor != null) return;
        this.leftDoor = transform.Find("door02_door1");
        this.leftDoorEndPos = this.leftDoorStartPos = this.leftDoor.transform.localPosition;
        this.leftDoorEndPos.x -= 0.807f;

        this.rightDoor = transform.Find("door02_door2");
        this.rightDoorEndPos = this.rightDoorStartPos = this.rightDoor.transform.localPosition;
        this.rightDoorEndPos.x += 0.917f;

        Debug.LogWarning(transform.name + ": LoadDoors", gameObject);
    }

    public override void Close()
    {
        base.Close();
        this.CloseLeftDoor();
        this.CloseRightDoor();
    }

    public override void Open()
    {
        base.Open();
        this.OpenLeftDoor();
        this.OpenRightDoor();
    }

    protected virtual void CloseLeftDoor()
    {
        StartCoroutine(MoveOverTime(this.leftDoor, this.leftDoorStartPos, this.leftDoorEndPos));
    }

    protected virtual void CloseRightDoor()
    {
        StartCoroutine(MoveOverTime(this.rightDoor, this.rightDoorStartPos, this.rightDoorEndPos));
    }

    protected virtual void OpenLeftDoor()
    {
        StartCoroutine(MoveOverTime(this.leftDoor, this.leftDoorEndPos, this.leftDoorStartPos));
    }

    protected virtual void OpenRightDoor()
    {
        StartCoroutine(MoveOverTime(this.rightDoor, this.rightDoorEndPos, this.rightDoorStartPos));
    }

    IEnumerator MoveOverTime(Transform door, Vector3 start, Vector3 end)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < this.duration)
        {
            door.localPosition = Vector3.Lerp(start, end, elapsedTime / this.duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        door.localPosition = end;
    }
}
