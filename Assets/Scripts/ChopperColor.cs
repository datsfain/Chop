using UnityEngine;

public class ChopperColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] m_Renderers;
    [SerializeField] private TeamReferenceSO m_ChoppingTeam;

    private void Start()
    {
        m_ChoppingTeam.Changed += ChoppingTeam_Changed;
        ChoppingTeam_Changed();
    }
    private void OnDestroy()
    {
        m_ChoppingTeam.Changed -= ChoppingTeam_Changed;
    }

    private void ChoppingTeam_Changed()
    {
        SetColor(m_ChoppingTeam.Ref.Color);
    }

    private void SetColor(Color color)
    {
        foreach(var renderer in m_Renderers)
        {
            renderer.color = color;
        }
    }
}
