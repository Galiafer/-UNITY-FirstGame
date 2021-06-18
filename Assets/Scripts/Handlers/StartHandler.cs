using System;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    private void Awake() => ClearSubscribers(Obsticle.OnPlayerEnterObsticle);

    private void ClearSubscribers(Action actionEvent)
    {
        foreach (Delegate @delegate in actionEvent.GetInvocationList())
        {
            if (@delegate.Method.Name == @delegate.Method.Name)
                actionEvent -= (Action)@delegate;
        };
    }
}
