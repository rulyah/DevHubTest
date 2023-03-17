using UnityEngine;

namespace UI
{
    public class GameScreen : Screen
    {
        [SerializeField] private Transform _skillsPanel;
        public Transform skillsPanel => _skillsPanel;
    }
}