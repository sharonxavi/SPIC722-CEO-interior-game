using UnityEngine;
using UnityEngine.UI;

public class ButtonChoiceController : MonoBehaviour
{
    public GameObject buttonA;
    public GameObject buttonB;

    public void OnButtonAChosen()
    {
        buttonB.SetActive(false);
        // Add code to show Arrangement A if needed
    }

    public void OnButtonBChosen()
    {
        buttonA.SetActive(false);
        // Add code to show Arrangement B if needed
    }
}
