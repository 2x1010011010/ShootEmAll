using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class PlayerAnimationSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayAnimation(string animation)
    {
        _animator.StopPlayback();
        _animator.Play(animation);
    }
}
