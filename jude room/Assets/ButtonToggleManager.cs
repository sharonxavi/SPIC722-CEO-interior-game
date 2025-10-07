using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI; // Include if using XR buttons

public class ButtonToggleManager : MonoBehaviour
{
    // These variables will hold the GameObject references to your buttons
    public GameObject buttonA;
    public GameObject buttonB;

    // Call this method when ButtonA is pressed
    public void OnButtonAClicked()
    {
        // When A is clicked, A disappears (is disabled), and B appears (is enabled)
        buttonA.SetActive(false);
        buttonB.SetActive(true);
        Debug.Log("Button A clicked: B is now visible.");
    }

    // Call this method when ButtonB is pressed
    public void OnButtonBClicked()
    {
        // When B is clicked, B disappears (is disabled), and A appears (is enabled)
        buttonB.SetActive(false);
        buttonA.SetActive(true);
        Debug.Log("Button B clicked: A is now visible.");
    }
}