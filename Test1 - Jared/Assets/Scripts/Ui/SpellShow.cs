using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellShow : MonoBehaviour
{
    Image m_image;

    Player player;

    public Sprite m_Fire;
    public Sprite m_Ice;
    public Sprite m_Speed;

    public GameObject fireballText;
    public GameObject iceText;
    public GameObject speedText;

    private void Start()
    {
        m_image = GetComponent<Image>();
    }

    private void Update()
    {
        if (fireballText.activeInHierarchy == true)
        {
            m_image.sprite = m_Fire;
        }
        else if (iceText.activeInHierarchy == true)
        {
            m_image.sprite = m_Ice;
        }
        else if (speedText.activeInHierarchy == true)
        {
            m_image.sprite = m_Speed;
        }
    }
}
