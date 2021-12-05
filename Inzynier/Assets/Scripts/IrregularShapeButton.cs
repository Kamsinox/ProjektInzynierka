using UnityEngine;
using UnityEngine.UI;

public class IrregularShapeButton : MonoBehaviour
{
    public float alphaTreshold = 0.1f;
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaTreshold;
    }
}
