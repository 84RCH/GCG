using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color m_BaseColor, m_OffsetColor;
    [SerializeField] private SpriteRenderer m_Renderer;
    [SerializeField] private GameObject m_Active;
    [SerializeField] private GameObject m_Goal;
    [SerializeField] private GameObject m_Start;

    public void Init(bool isOffset)
    {
        if(isOffset)
            m_Renderer.color = m_OffsetColor;
        else
        m_Renderer.color = m_BaseColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameObject.Find("Start"))
            {
                GameObject player = GameObject.Find("Player");
                if ((player.transform.position.x == transform.position.x)
                    && (player.transform.position.y == transform.position.y))
                {
                    m_Start.SetActive(true);
                }
            }
        }
    }
    void OnMouseEnter()
    {
        m_Active.SetActive(true);
    }

    private void OnMouseExit()
    {
        m_Active.SetActive(false);
    }
    void OnMouseDown()
    {
        if (!GameObject.Find("Goal"))
            m_Goal.SetActive(true);
    }

}
