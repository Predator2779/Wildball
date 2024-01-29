using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Controllers
{
    public class DoorsControl : MonoBehaviour
    {
        [SerializeField] private bool _isLocked;
        [SerializeField] private bool _isAuto;
        [SerializeField] private bool _isOpened;

        [SerializeField] [CanBeNull] private AnimationClip _openAnim;
        [SerializeField] [CanBeNull] private AnimationClip _closeAnim;

        private Animator _animator;
        private bool _isDelayed;

        private void Start()
        {
            _animator = transform.parent.GetComponent<Animator>();
        }

        public void OpenDoors()
        {
            PlayAnim(_openAnim);
            _isOpened = true;
            StartCoroutine(OpeningDelay());
        }

        public void CloseDoors()
        {
            PlayAnim(_closeAnim);
            _isOpened = false;
            StartCoroutine(OpeningDelay());
        }

        public void OpeningDoors(bool value)
        {
            if (value) OpenDoors();
            else CloseDoors();
        }

        private void PlayAnim(AnimationClip anim)
        {
            if (anim == null) return;

            _animator.StopPlayback();
            _animator.Play(anim.name);
        }

        private IEnumerator OpeningDelay()
        {
            _isDelayed = true;
            yield return new WaitForSeconds(0.5f);
            _isDelayed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isAuto || _isLocked || _isOpened || _isDelayed) return;
            OpeningDoors(true);
        }

        private void OnTriggerStay(Collider other)
        {
            if (_isLocked || _isDelayed) return;
            if (Input.GetKeyUp(KeyCode.F) && !_isAuto) OpeningDoors(!_isOpened);
        }

        private void OnTriggerExit(Collider other)
        {
            if (_isLocked || _isDelayed || !_isAuto || !_isOpened) return;
            OpeningDoors(false);
        }
    }
}