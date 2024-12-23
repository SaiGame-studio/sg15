using UnityEngine;

public class SpaceTriggerNext1 : SpaceTriggerNext
{
    protected override void ResetPosition()
    {
        transform.localPosition = new Vector3(35f, 1.5f, -12f);
    }

    protected override string GetDoorName()
    {
        return "SliderDoor1";
    }
}
