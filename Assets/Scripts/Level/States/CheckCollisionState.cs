using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class CheckCollisionState : State<LevelCore>
    {
        public CheckCollisionState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.model.skillView.onEnemyCollision += OnEnemyHit;
            core.model.skillView.onMissed += OnMissed;
        }

        private void OnMissed()
        {
            Unsubscribe();
            var skill = core.model.skillView;
            core.model.skillView = null;
            Object.Destroy(skill.gameObject);
            ChangeState(new GamePlayState(core));
        }

        private void Unsubscribe()
        {
            core.model.skillView.onEnemyCollision -= OnEnemyHit;
            core.model.skillView.onMissed -= OnMissed;
        }

        private void OnEnemyHit()
        {
            Unsubscribe();
            ChangeState(new PlayHitEffectState(core));
        }
    }
}