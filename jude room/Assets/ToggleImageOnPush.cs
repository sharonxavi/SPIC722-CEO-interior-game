using UnityEngine;
using UnityEngine.UI;

public class ToggleImageOnPush : MonoBehaviour
{
    public Image imageToHide;  // Drag the other image here in Inspector

    // This method will be called on button "push"
    public void OnPush()
    {
        if (imageToHide != null)
            imageToHide.gameObject.SetActive(false);
    }
}
