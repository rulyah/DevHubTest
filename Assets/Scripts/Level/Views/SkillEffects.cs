using System;

namespace Level.Views
{
    [Serializable]
    public class SkillEffects
    {
        public Skills skill;
        public SkillView skillView;
        public EffectView effectView;
    }
}