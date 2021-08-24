using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerViewController : MonoBehaviour
{
    private ScrollRect scrollRect;
    public float space = 50f;
    public GameObject uiPrefab;
    public List<RectTransform> uiObjects = new List<RectTransform>();
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddNewUiobject(){
        var newUi = Instantiate(uiPrefab, scrollRect.content).GetComponent<RectTransform>();
        uiObjects.Add(newUi);

        float x = 0f;
        for(int i = 0; i < uiObjects.Count; i++){
            uiObjects[i].anchoredPosition = new Vector2(x, 0f);
            x += uiObjects[i].sizeDelta.x + space;
        }

        scrollRect.content.sizeDelta = new Vector2(x,scrollRect.content.sizeDelta.y);
    }
}
