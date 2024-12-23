using UnityEngine;

public abstract class SpaceTriggerNext : SpaceTrigger
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetPosition();
    }

    protected abstract void ResetPosition();

    protected override bool IsSpaceLoadFinish()
    {
        //TODO: make sure space finish loading before turn true
        this.spaceCtrl.Show();
        return true;
    }
}
