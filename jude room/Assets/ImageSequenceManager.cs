using UnityEngine;
using System.Collections.Generic;

public class ImageSequenceManager : MonoBehaviour
{
    // Drag your 7 Couple GameObjects (the parents) into this list in the Inspector
    public List<GameObject> imageCouples = new List<GameObject>();

    // Reference to your 'Next' button GameObject
    public GameObject nextButton;

    private int currentCoupleIndex = 0;

    void Start()
    {
        // 1. Ensure only the first couple is visible at the start
        // And hide the Next button until a choice is made.

        // Safety check to ensure the list isn't empty
        if (imageCouples.Count > 0)
        {
            // Deactivate all couples first, then activate only the first one
            for (int i = 0; i < imageCouples.Count; i++)
            {
                imageCouples[i].SetActive(false);
            }
            ActivateCouple(0);
        }
        else
        {
            Debug.LogError("Image Couples list is empty! Please assign your 7 Couple GameObjects in the Inspector.");
        }

        // Hide the Next button until an image is selected
        nextButton.SetActive(false);
    }

    // Call this method from the click event of EITHER image button, passing its own GameObject
    public void SelectImage(GameObject selectedImage)
    {
        // Get the parent (the current Couple GameObject) of the clicked image
        Transform currentCoupleTransform = selectedImage.transform.parent;

        if (currentCoupleTransform == null)
        {
            Debug.LogError("Selected image does not have a parent, cannot find sibling image.", selectedImage);
            return;
        }

        // Loop through all children (the two images) of the current couple's parent
        foreach (Transform child in currentCoupleTransform)
        {
            GameObject otherImage = child.gameObject;

            // Check: If the child is NOT the image that was clicked
            if (otherImage != selectedImage)
            {
                // Disable the non-selected image (the one that should disappear)
                otherImage.SetActive(false);
            }
        }

        // Ensure the selected image stays visible
        selectedImage.SetActive(true);

        // Show the Next button now that a choice has been made
        nextButton.SetActive(true);

        Debug.Log($"Image {selectedImage.name} selected in Couple {currentCoupleIndex + 1}. Other image disappeared.");
    }

    // Call this method from the 'On Release' event of the NEXT Button
    public void GoToNextCouple()
    {
        // 1. Hide the current couple and the Next Button
        imageCouples[currentCoupleIndex].SetActive(false);
        nextButton.SetActive(false);

        // 2. Move to the next index
        currentCoupleIndex++;

        // 3. Check if there are more couples to show
        if (currentCoupleIndex < imageCouples.Count)
        {
            // Activate the next couple
            ActivateCouple(currentCoupleIndex);
            Debug.Log($"Displaying Couple {currentCoupleIndex + 1}.");
        }
        else
        {
            // All couples have been processed
            Debug.Log("Sequence complete! All couples processed.");
            // OPTIONAL: Add end-of-sequence logic here (e.g., load a results scene)
        }
    }

    // Helper function to activate a couple and ensure both its images are visible for the new round
    private void ActivateCouple(int index)
    {
        if (index >= 0 && index < imageCouples.Count)
        {
            GameObject currentCouple = imageCouples[index];
            currentCouple.SetActive(true);

            // Ensure both images within the couple are active for the new round
            foreach (Transform child in currentCouple.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}