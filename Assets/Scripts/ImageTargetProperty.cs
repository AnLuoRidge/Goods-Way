public class ImageTargetProperty : DefaultTrackableEventHandler
{
    /// <summary>
    /// Whether current Image Target is showed on screen
    /// </summary>
    public bool IsShowed;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        IsShowed = true;
        ImageTargetManager.Instance.ITList.Add(gameObject);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        IsShowed = false;
        ImageTargetManager.Instance.ITList.Remove(gameObject);
    }
}