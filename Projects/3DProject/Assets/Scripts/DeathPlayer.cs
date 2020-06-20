//Смерть врага. Рагдольное падение врага. Замедление времени

using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Rigidbody> _rigitbodyRagdollElements;
    [Range(0,1)][SerializeField] private float _timeScale;
    [SerializeField] private SavedEnemyData _savedEnemyData;

    public void EnablePhysics()
    {
        Time.timeScale = _timeScale;
        _animator.enabled = false;
        for (int i = 0; i < _rigitbodyRagdollElements.Count; i++)
        {
            _rigitbodyRagdollElements[i].isKinematic = false;
        }
    }

    public void DisablePhysics()
    {
        _savedEnemyData.LoadData();
        Time.timeScale = 1f;
        _animator.enabled = true;
        for (int i = 0; i < _rigitbodyRagdollElements.Count; i++)
        {
            _rigitbodyRagdollElements[i].isKinematic = true;
        }
    }
}
