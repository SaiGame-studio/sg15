using UnityEngine;

public class SpaceTriggerNext : SpaceTrigger
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(20, 1.5f, -15);
    }

    protected override void ShowSpace()
    {
        Debug.LogWarning("SpaceTriggerNext");
        this.spaceCtrl.Show();
    }
}
