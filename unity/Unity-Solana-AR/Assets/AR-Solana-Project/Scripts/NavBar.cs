using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NavBar : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> pageElements = new List<GameObject>();
    public int uiIndex;
    private void Start()
    {
        pageElements.Add(GameObject.Find("SportsPage"));
        pageElements.Add(GameObject.Find("MapPage"));
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        foreach (GameObject ui in pageElements)
        {
            ui.SetActive(false);
        }
        pageElements[uiIndex].SetActive(true);
    }
}
