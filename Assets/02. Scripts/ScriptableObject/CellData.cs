using UnityEngine;

[CreateAssetMenu(fileName = "Cell Data", menuName = "Scriptable Object/Cell Data", order = int.MaxValue)]

public class CellData : ScriptableObject
{
    [SerializeField]
    private string zombieName;
    public string CelleName { get { return CelleName; } }

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float sightRange;
    public float SightRange { get { return sightRange; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}
