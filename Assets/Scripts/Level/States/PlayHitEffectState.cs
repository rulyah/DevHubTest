using System;
using System.Collections;
using UnityEngine;
using Utils.StateMachineTool;
using Object = UnityEngine.Object;

namespace Level.States
{
    public class PlayHitEffectState : State<LevelCore>
    {
        public PlayHitEffectState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            var skill = core.model.skillView;
            var hitPos = skill.transform.position;

            var effectView = Object.Instantiate(core.config.effects[core.model.currentSkillId].effectView);
            effectView.transform.position = hitPos;
            Object.Destroy(skill.gameObject);
            
            var targets = Physics.OverlapSphere(hitPos, 10.0f);
            core.model.enemyView.TakeDamage(targets.Length);
            
            foreach (var target in targets)
            {
                Object.Destroy(target.gameObject);
            }
            
            core.StartCoroutine(Delay(0.5f, () =>
            {
                Object.Destroy(effectView.gameObject);
                ChangeState(new GamePlayState(core));
            }));
        }

        private IEnumerator Delay(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }
    }
}