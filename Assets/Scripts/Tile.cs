using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color m_BaseColor, m_OffsetColor;
    [SerializeField] private SpriteRenderer m_Renderer;
    [SerializeField] private GameObject m_Active;

    public void Init(bool isOffset)
    {
        if(isOffset)
            m_Renderer.color = m_OffsetColor;
        else
        m_Renderer.color = m_BaseColor;
    }

    void OnMouseEnter()
    {
        m_Active.SetActive(true);
    }

    private void OnMouseExit()
    {
        m_Active.SetActive(false);
    }
}
