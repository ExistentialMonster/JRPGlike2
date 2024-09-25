using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathThings
{
    // Start is called before the first frame update
    public Vector2 IntersectTwoLines(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
        Vector2 v = b - a;
        Vector2 u = d - c;
        Vector2 f = c - a;
        float i = f.x / (v.x + u.x);
        float j = f.y / (v.y + u.y);
        return a + v * i;
    }



    public Vector2 Gauss (Vector3 a, Vector3 b)
    {
        Vector3 b1 = b / b.x * a.x;
        b1 = b1 - a;
        float ans1 = -b1.z / b1.y;
        Vector2 a1 = new Vector2 (a.y, a.x * ans1 + a.z);
        float ans2 = -a1.y / a1.x;
        return new Vector2(ans1, ans2);

    }
}
