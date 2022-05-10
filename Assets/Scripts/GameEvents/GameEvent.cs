using System.Collections.Generic;
using UnityEngine;

//From the create asset menu you can create a new GameEvent. E.g OnBlowMic, OnStageEnded, etc.
//Once done, you'll need two things: have a script that fires the event (e.g when mic volume surpasses
//the threshold, and then fire the event by calling Raise() function) and make sure all items needed
//listen for the GameEvent

//PROS: you don't manually have to make everything subscribe to the event by code. Just by dragging
//the GameEventListener script it already listens to the event you have selected. Also you can have for 
//example some gameplay and UI logic work independently when the event fires.

//CONS: I still haven't figured out how to pass arguments with the event.

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent", order = 51)]
public class GameEvent : ScriptableObject {
    
    //Hold a list of all listeners (e.g all the moving platforms will listen for OnBlowMic)
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener){
        _listeners.Add(listener);
    }
    
    public void UnegisterListener(GameEventListener listener){
        _listeners.Remove(listener);       
    }

    //Iterate through every listener on the list and call its RaiseResponse() method
    public void Raise(){

        for (int i = 0; i < _listeners.Count; i++)
        {
            _listeners[i].RaiseResponse();
        }
    }
}

