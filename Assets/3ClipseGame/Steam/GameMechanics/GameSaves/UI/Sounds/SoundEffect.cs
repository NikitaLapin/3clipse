using System.Collections;
using UnityEngine;

namespace _3ClipseGame.Steam.GameMechanics.GameSaves.UI.Sounds
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip _startClip;
        [SerializeField] private AudioClip _activeClip;
        [SerializeField] private AudioSource _source;

        public void Play()
        {
            _source.clip = _startClip;
            _source.Play();
            StartCoroutine(WaitForEndRoutine());
        }

        public void Stop()
        {
            _source.Stop();
        }

        private IEnumerator WaitForEndRoutine()
        {
            yield return new WaitForSeconds(_startClip.length + Mathf.Epsilon);
            _source.clip = _activeClip;
            _source.Play();
        }
    }
}
