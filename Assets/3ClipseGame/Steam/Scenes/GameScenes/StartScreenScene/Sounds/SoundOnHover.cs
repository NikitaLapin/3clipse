using UnityEngine;
using UnityEngine.EventSystems;

namespace _3ClipseGame.Steam.Scenes.GameScenes.StartScreenScene.Sounds
{
    public class SoundOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private AudioSource _uiAudioSource;
        [SerializeField] private AudioClip _hoverSound;
        [SerializeField] private AudioClip _unhoverSound;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _uiAudioSource.clip = _hoverSound;
            _uiAudioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _uiAudioSource.clip = _unhoverSound;
            _uiAudioSource.Play();
        }
    }
}
