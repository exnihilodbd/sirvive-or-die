using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class freeCam : MonoBehaviour, IDragHandler, 
             IPointerDownHandler, IPointerUpHandler
{
    Image img;
   [SerializeField] public CinemachineFreeLook fl;
    string x = "Mouse X", y = "Mouse Y";
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(img.rectTransform,
            eventData.position,eventData.enterEventCamera,out Vector2 posout))
        {
            // Debug.Log(posout);
            fl.m_XAxis.m_InputAxisName = x;
            fl.m_YAxis.m_InputAxisName = y;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        fl.m_XAxis.m_InputAxisName = null;
        fl.m_YAxis.m_InputAxisName = null;
        fl.m_XAxis.m_InputAxisValue = 0;
        fl.m_YAxis.m_InputAxisValue = 0;
    }
    
}
