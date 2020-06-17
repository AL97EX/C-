//Вектор направления пули
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public Vector3 a { get; set; }
    public Vector3 b { get; set; }


    public Vector3 Target()
    {
        Vector3 c = b - a;
        return c;
    }
}
