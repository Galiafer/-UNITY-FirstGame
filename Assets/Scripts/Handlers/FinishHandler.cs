using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishHandler : MonoBehaviour
{
    [SerializeField] private string _collisionFinishTag = "Player";
    [SerializeField] private float _timeToMoveToNextLevel = 1.5f;

    private int _nextLevel = 1; // 0 - Main Menu; 1 - First Level;

    private bool HasNextLevel => _nextLevel <= SceneManager.sceneCountInBuildSettings;

    private void Start() => Obsticle.OnPlayerEnterObsticle += RestartGame;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(_collisionFinishTag))
            Invoke(nameof(GoToNextLevel), _timeToMoveToNextLevel);
    }

    private void GoToNextLevel()
    {
        _nextLevel = HasNextLevel ? _nextLevel += 1 : SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(_nextLevel);
    }

    private void RestartGame() => SceneManager.LoadScene(1);
}
