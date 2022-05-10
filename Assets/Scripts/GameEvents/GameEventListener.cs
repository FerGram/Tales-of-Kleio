using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] UnityEvent _response;

    //When object is enabled, add to the list of listeners
    private void OnEnable() {
        
        _gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        
        _gameEvent.UnegisterListener(this);
    }

    //The unityEvent response. This can execute a method of any script attached to the GameObject
    public void RaiseResponse()
    {
        _response.Invoke();
    }
}
