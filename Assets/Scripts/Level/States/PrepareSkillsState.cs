using UI;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class PrepareSkillsState : State<LevelCore>
    {
        public PrepareSkillsState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.gameScreen.Show();
            
            for (var i = 0; i < 3; i++)
            {
                SetSlot();
            }
            
            ChangeState(new GamePlayState(core));
        }

        private void SetSlot()
        {
            var slot = core.factoryService.skillSlot.Produce();
            slot.transform.SetParent(core.gameScreen.skillsPanel);
            slot.transform.localPosition = Vector3.zero;
            slot.SetSkill(SetIcon(slot));
            core.model.skillSlots.Add(slot);
        }
        
        private SkillIcon SetIcon(SkillSlot slot)
        {
            var skill = core.factoryService.skillIcon.Produce();
            skill.transform.SetParent(slot.transform);
            skill.SetSprite(core.config.skillImages[core.model.skillSlots.Count]);
            skill.skillId = core.model.skillIcons.Count;
            core.model.skillIcons.Add(skill);
            skill.Init();
            return skill;
        }
    }
}