using DigitalRuby.AnimatedLineRenderer;
using UnityEngine;

public class DrawArrow : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public PhasorScript phasorScript;

    private void Start()
    {
        phasorScript = GetComponent<PhasorScript>();
    }

    void Update()
    {
        if (first != null && second != null)
        {
            if (first.activeSelf && second.activeSelf)
            {
                phasorScript.Source = first;
                
                phasorScript.Fire(second.transform.position);
            }
        }
    }
}