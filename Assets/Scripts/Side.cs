using UnityEngine;

public class Side : MonoBehaviour
{
    [SerializeField] private TeamSO m_Team;
    [SerializeField] private SpriteRenderer m_Renderer;

    private void Start()
    {
        m_Renderer.color = m_Team.Color;
        m_Team.RemainingSize.Changed += RemainingSize_Changed;
        RemainingSize_Changed();
    }

    private void OnDestroy()
    {
        m_Team.RemainingSize.Changed -= RemainingSize_Changed;
    }

    private void RemainingSize_Changed()
    {
        transform.localScale = new Vector3(1f, m_Team.RemainingSize.Value, 1f);
    }
}
