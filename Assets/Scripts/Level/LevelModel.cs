using System.Collections.Generic;
using Level.Views;
using UI;
using Utils.ProcessTool;

namespace Level
{
    public class LevelModel
    {
        public PlayerView playerView;
        public LevelCameraView levelCameraView;
        public SkillView skillView;
        public EnemyView enemyView;
        
        public int currentSkillId;

        public List<SkillSlot> skillSlots;
        public List<SkillIcon> skillIcons;
        public List<Process> processes;
    }
}