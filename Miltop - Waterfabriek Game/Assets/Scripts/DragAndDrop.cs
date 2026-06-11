using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Image image;

    private GameObject[] DropSpots;
    private float[] DropSpotsDistancens;

    private float shortestDistance;
    private int index;

    private int snapDistance = 100;

    private bool canLerp;

    private DropSpot nearestDropSpotScript;

    public int objectID;

    public bool correctPos;
    private Vector2 movePosition;

    RectTransform canvasRect;
    float currentScreenWidth, currentScreenHeight;
    private Vector2 originalPosition, currentPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        MakeDropSpotArray();
        Singleton.Instance.audioScript.PlayPickup();

        if (correctPos)
            return;

        image.color = new Color32(255, 255, 255, 170);
        canLerp = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!correctPos)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canLerp = true;
        if (!correctPos)
        {
            Singleton.Instance.audioScript.PlayDrop();
            image.color = new Color32(255, 255, 255, 255);

            for (int i = 0; i < DropSpots.Length; i++)
            {
                DropSpotsDistancens[i] = Vector2.Distance(transform.position, DropSpots[i].transform.position);
            }

            shortestDistance = float.PositiveInfinity;
            index = -1;

            for (int i = 0; i < DropSpotsDistancens.Length; i++)
            {
                if (DropSpotsDistancens[i] < shortestDistance)
                {
                    index = i;
                    shortestDistance = DropSpotsDistancens[i];
                    nearestDropSpotScript = DropSpots[i].GetComponent<DropSpot>();

                    if (DropSpotsDistancens[i] < snapDistance)
                    {
                        movePosition = DropSpots[i].transform.position; //save position of dropspot
                    }
                }
            }
            if (shortestDistance < snapDistance)
            {
                nearestDropSpotScript.OnItemDrop(objectID, this);
            }
        }
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        currentScreenWidth = canvasRect.rect.width / 2;
        currentScreenHeight = canvasRect.rect.height / 2;
        originalPosition = transform.position;
    }

    void Update()
    {
        if (canLerp)
        {
            currentPosition = this.transform.localPosition;
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        if (shortestDistance < snapDistance && index != -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePosition, 1000 * Time.deltaTime);
        }

        if (shortestDistance < 1 && index != -1)
        {
            shortestDistance = 0;
            index = -1;
        }
        if (currentPosition.x > currentScreenWidth || currentPosition.x < -currentScreenWidth || currentPosition.y > currentScreenHeight || currentPosition.y < -currentScreenHeight)
        {
            transform.position = originalPosition;
            Debug.Log("Out of bounds");
        }
    }

    public void CheckAllDropSpots()
    {
        MakeDropSpotArray();
        for (int i = 0; i < DropSpotsDistancens.Length; i++)
        {
            DropSpots[i].GetComponent<DropSpot>().CheckDropSpot();
        }
    }

    private void MakeDropSpotArray()
    {
        DropSpots = null;
        DropSpots = GameObject.FindGameObjectsWithTag("Dropspot");
        DropSpotsDistancens = new float[DropSpots.Length];
    }
}