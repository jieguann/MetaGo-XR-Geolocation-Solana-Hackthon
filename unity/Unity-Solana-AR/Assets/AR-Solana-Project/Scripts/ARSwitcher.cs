using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ARSwitcher : MonoBehaviour, IPointerClickHandler
{   //[SerializeField] private string 
    [SerializeField] private string sceneName;
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }
}
