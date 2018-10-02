using DigitalRuby.AnimatedLineRenderer;
using UnityEngine;

public class ImageTargetProperty : DefaultTrackableEventHandler
{
    /// <summary>
    /// Whether current Image Target is showed on screen
    /// </summary>
    public bool IsShowed;
    private PhasorScript phasorScript;

    private void Awake()
    {
        phasorScript = GetComponent<PhasorScript>();
    }

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

    public void DrawLine(Vector3 position)
    {
        phasorScript.Source = gameObject;
        // phasorScript.Fire(position);
    }
}