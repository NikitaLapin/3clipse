using UnityEngine;
using UnityEngine.EventSystems;

namespace _3ClipseGame.Steam.Scenes.GameScenes.StartScreenScene.Sounds
{
    public class SoundOnClick : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioSource _uiAudioSource;
        [SerializeField] private AudioClip _clickSound;

        public void OnPointerClick(PointerEventData eventData)
        {
            _uiAudioSource.clip = _clickSound;
            _uiAudioSource.Play();
        }
    }
}
