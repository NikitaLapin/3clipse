using System.Collections;
using System.Globalization;
using _3ClipseGame.Steam.GameMechanics.GameSaves.InGame;
using TMPro;
using UnityEngine;

namespace _3ClipseGame.Steam.Scenes.GameScenes.FirstIntroScene
{
    public class WaitAndSave : MonoBehaviour
    {
        [SerializeField] private float _waitTime;
        [SerializeField] private SceneObject _newLoadScene;
        
        private float _time;
        
        private IEnumerator Start()
        {
            while (_time < _waitTime)
            {
                _time += Time.deltaTime;
                yield return null;
            }
            
            Skip();
        }

        public void Skip()
        {
            InterSceneSavesEntry.Instance.LoadScene(_newLoadScene);
        }
    }
}
