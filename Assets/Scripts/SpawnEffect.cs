using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start() => _particleSystem.Play();
}
