using UnityEngine;

[CreateAssetMenu(fileName = "Cell Data", menuName = "Scriptable Object/Cell Data")]

public class CellData : ScriptableObject
{
    public string grade;
    public int number;
    public new string name;
    public int hP;
    public int power;
    public int upgradeCost;
    public int primeEnergy;
    public string description;
    public Sprite image;
}
