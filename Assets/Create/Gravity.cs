using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;

    const float G = 0.00667f;
    public static List<Gravity> gravityObjectList;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectList == null)
        {
            gravityObjectList = new List<Gravity>();
        }

        gravityObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectList)
        {
            if (obj != this)
            Attract(obj);
        }
    }

    void Attract(Gravity Other)
    {
        Rigidbody otherRB = Other.rb;
        Vector3 directiong = otherRB.position - otherRB.position;
        float distance = directiong.magnitude;

        float forceMagnitude = G * (otherRB.mass * otherRB.mass/ Mathf.Pow( distance, 2));
        Vector3 gavityForce = forceMagnitude * directiong.normalized;

        otherRB.AddForce(gavityForce);
    }
}
