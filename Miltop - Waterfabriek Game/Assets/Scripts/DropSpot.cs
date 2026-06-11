using UnityEngine;
using UnityEngine.LightTransport;
using TMPro;

public class DropSpot : MonoBehaviour
{
    public int requiredItemID;

    public int orderIndex;

    public SBS_GuidManager guidManager;

    public bool isTaken;

    private DragAndDrop _dragDropScript;
    private TextMeshProUGUI progressText;

    public void Awake()
    {
        progressText = GetComponentInChildren<TextMeshProUGUI>();
        progressText.SetText(orderIndex.ToString());
    }

    public void OnItemDrop(int id, DragAndDrop dragDropScript)
    {
        _dragDropScript = dragDropScript;

        if (id != requiredItemID) //incorrect item
        {
            guidManager.CompomentCorrectToStep(false, false);
            isTaken = true;
            Singleton.Instance.audioScript.PlayWrong();
            return;
        }

        if (Singleton.Instance.guidManager.stepIndex + 1 != orderIndex) //correct item, incorrect order
        {
            guidManager.CompomentCorrectToStep(true, false);
            isTaken = true;
            return;
        }
        //correct item, correct order

        Singleton.Instance.audioScript.PlayCorrect();
        dragDropScript.correctPos = true;
        dragDropScript.CheckAllDropSpots(); //check every drop spot

        guidManager.CompomentCorrectToStep(true, true);

        //Debug.Log("On item drop");
        Destroy(gameObject);
    }

    public void CheckDropSpot()
    {
        
        if (_dragDropScript != null)
        {
            int requiredIndex = Singleton.Instance.guidManager.stepIndex + 2; //check for 1 step ahead

            if (_dragDropScript.objectID == requiredItemID && requiredIndex == orderIndex)
            {
                _dragDropScript.correctPos = true;
                guidManager.CompomentCorrectToStep(true, true);

                _dragDropScript.CheckAllDropSpots(); //check every drop spot again

                //Debug.Log("Check Drop");
                Destroy(gameObject);
            }
        }
    }
}