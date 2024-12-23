using UnityEngine;

public class SpaceTriggerNext2 : SpaceTriggerNext
{
    protected override void ResetPosition()
    {
        transform.localPosition = new Vector3(3.5f, 1.5f, -12f);
    }

    protected override string GetDoorName()
    {
        return "SliderDoor2";
    }
}
