using UnityEngine;

public class ChopperMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private TeamSO m_TopTeam;
    [SerializeField] private TeamSO m_BottomTeam;
    [SerializeField] private FloatVariable m_MinCutSize;
    [SerializeField] private FloatVariable m_ChopperY;

    private float MinY => -m_BottomTeam.RemainingSize.Value;
    private float MaxY => m_TopTeam.RemainingSize.Value;

    private float m_MoveDirection = -1f;

    private void Move()
    {
        if (ShouldChangeDirection())
        {
            InvertDirection();
        }

        var deltaY = m_MoveDirection * m_Speed * Time.deltaTime;
        var newPosition = transform.position + new Vector3(0f, deltaY, 0f);
        transform.position = newPosition;
        m_ChopperY.Value = newPosition.y;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InvertDirection()
    {
        m_MoveDirection *= -1f;
    }

    private bool ShouldChangeDirection()
    {
        var y = transform.position.y;
        var minCutSize = m_MinCutSize.Value;
        return (y + minCutSize >= MaxY && m_MoveDirection > 0f) || (y - minCutSize <= MinY && m_MoveDirection < 0f);
    }
}
