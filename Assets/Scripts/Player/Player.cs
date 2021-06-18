using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PathDrawer _pathDrawer;
    [SerializeField] private PathFollower _pathFollower;

    private void Start() => Obsticle.OnPlayerEnterObsticle += PlayerFailed;

    private void Update()
    {
        #region Path Creating

        #region PC
        if (Input.GetMouseButtonDown(0)) _pathDrawer.ClearPath();

        if (Input.GetMouseButton(0)) _pathDrawer.DrawPath();

        if (Input.GetMouseButtonUp(0)) _pathDrawer.CreatePath();
        #endregion

        #region Mobile
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) _pathDrawer.ClearPath();

            if (Input.GetTouch(0).phase == TouchPhase.Moved) _pathDrawer.DrawPath();

            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) _pathDrawer.CreatePath();
        }
        #endregion

        #endregion

        _pathFollower.StartFollow();
    }

    private void PlayerFailed()
    {
        _pathDrawer.ClearPath();
        gameObject?.SetActive(false);
    }
}
