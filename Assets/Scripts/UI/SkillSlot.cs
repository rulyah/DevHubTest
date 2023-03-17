using UnityEngine;
using UnityEngine.EventSystems;
using Utils.FactoryTool;

namespace UI
{
    public class SkillSlot : PoolableMonoBehaviour, IDropHandler
    {
    
        private SkillIcon _skillInSlot;
    
        public void SetSkill(SkillIcon skill)
        {
            _skillInSlot = skill;
        }

        public void OnDrop(PointerEventData eventData)
        {
            var skill = eventData.pointerDrag.transform;
            skill.transform.SetParent(transform);
            skill.transform.position = Vector3.zero;
            SetSkill(eventData.pointerDrag.GetComponent<SkillIcon>());
        }
    }
}