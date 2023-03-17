using System;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class InputProcess : Process
    {
        private LevelCore _core;
        public InputProcess(LevelCore core) : base(core)
        {
            _core = core;
        }

        public event Action<int> onFire;
        
        protected override void OnStart()
        {
            base.OnStart();
            foreach (var skill in _core.model.skillIcons)
            {
                skill.onSkillClick += Click;
            }
        }

        private void Click(int skillId)
        {
            onFire?.Invoke(skillId);
        }

        protected override void OnStop()
        {
            foreach (var skill in _core.model.skillIcons)
            {
                skill.onSkillClick -= Click;
            }
            base.OnStop();
        }
    }
}