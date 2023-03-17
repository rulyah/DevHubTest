using Level.Views;
using UI;
using UnityEngine;
using Utils.FactoryTool;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private LevelCameraView _cameraPrefab;
        [SerializeField] private SkillSlot _skillSlotPrefab;
        [SerializeField] private SkillIcon _skillIconPrefab;
        [SerializeField] private EnemyView _enemyPrefab;
        
        
        public Factory<PlayerView> players { get; private set; }
        public Factory<LevelCameraView> levelCameraView { get; private set; }
        public Factory<SkillSlot> skillSlot { get; private set; }
        public Factory<SkillIcon> skillIcon { get; private set; }
        public Factory<EnemyView> enemy { get; private set; }
        
        
        private void Awake()
        {
            players = new Factory<PlayerView>(_playerPrefab, 1);
            levelCameraView = new Factory<LevelCameraView>(_cameraPrefab, 1);
            skillSlot = new Factory<SkillSlot>(_skillSlotPrefab, 3);
            skillIcon = new Factory<SkillIcon>(_skillIconPrefab, 3);
            enemy = new Factory<EnemyView>(_enemyPrefab, 1);
        }

        private void OnDestroy()
        {
            players.Dispose();
            enemy.Dispose();
            levelCameraView.Dispose();
            skillSlot.Dispose();
            skillIcon.Dispose();
        }
    }
}
