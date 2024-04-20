using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public Transform TF;
    public void SetState(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
