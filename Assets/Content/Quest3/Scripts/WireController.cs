using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
}
