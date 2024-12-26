using UnityEngine;

public class SpaceTriggerNext2 : SpaceTriggerNext
{
    protected override void ResetPosition()
    {
        transform.localPosition = new Vector3(5.3f, 1f, -20f);
    }

    protected override string GetDoorName()
    {
        return "SliderDoorNext2";
    }
}
