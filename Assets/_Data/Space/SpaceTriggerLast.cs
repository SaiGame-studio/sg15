using UnityEngine;

public class SpaceTriggerLast : SpaceTrigger
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(20, 1.5f, 15);
    }

    protected override void ShowSpace()
    {
        Debug.LogWarning("SpaceTriggerLast");
        this.spaceCtrl.Show();
    }
}
