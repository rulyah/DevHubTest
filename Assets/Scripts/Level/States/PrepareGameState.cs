using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class PrepareGameState : State<LevelCore>
    {
        public PrepareGameState(LevelCore core) : base(core) {}
        
        public override void OnEnter()
        {
            core.model.levelCameraView = core.factoryService.levelCameraView.Produce();
            core.model.enemyView = core.factoryService.enemy.Produce();
            core.model.enemyView.transform.position = new Vector3(17.0f,0.0f,80.0f);
            core.model.enemyView.InitHealth(core.model.levelCameraView);
            ChangeState(new MenuState(core));
        }
    }
}