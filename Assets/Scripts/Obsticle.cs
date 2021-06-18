using System;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public static Action OnPlayerEnterObsticle = delegate { };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            OnPlayerEnterObsticle?.Invoke();
    }
}
