using UnityEngine;

public class SpaceTriggerLast1 : SpaceTriggerNext
{
    protected override void ResetPosition()
    {
        transform.localPosition = new Vector3(53f, 1f, 20f);
    }

    protected override string GetDoorName()
    {
        return "SliderDoorLast1";
    }
}
