using System;
using UnityEngine;
using FMODUnity;
using UnityEngine.Events;

public class AnimationFunctionManager : MonoBehaviour
{
    //Used in SuperJumpPlayerState to play sound when jump
    public static Action OnJumpAction;

    public static event Action AnimationJumpEvent;

    [SerializeField] private EventReference _steps;

    [SerializeField] private EventReference _jump;

    [SerializeField] private EventReference _climb;

    [SerializeField] private EventReference _landingHard;

    [SerializeField] private EventReference _landingSoft;

    [SerializeField] private EventReference _dragingObject;

    // Subscribes the method JumpSound to an event
    // that happens when player jumps
    private void OnEnable()
    {
        OnJumpAction += JumpsSound;
    }

    private void OnDisable()
    {
        OnJumpAction -= JumpsSound;
    }

    public void FootstepSounds()
    {
        RuntimeManager.PlayOneShot(_steps);
    }

    public void ClimbSound()
    {
        if (_climb.IsNull) { return; }
        RuntimeManager.PlayOneShot(_climb);
    }

    public void JumpsSound()
    {
        AnimationJumpEvent?.Invoke();
        if (_jump.IsNull) { return; }
        RuntimeManager.PlayOneShot(_jump);
    }

    public void landingHard()
    {
        RuntimeManager.PlayOneShot(_landingHard);
    }

    public void landingSoft()
    {
        RuntimeManager.PlayOneShot(_landingSoft);
    }

    public void dragingObject()
    {
        RuntimeManager.PlayOneShot(_dragingObject);
    }
}