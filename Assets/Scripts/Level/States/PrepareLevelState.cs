using System.Collections.Generic;
using Level.Processes;
using UI;
using UnityEngine;
using Utils.ProcessTool;
using Utils.StateMachineTool;

namespace Level.States
{
    public class PrepareLevelState : State<LevelCore>
    {
        public PrepareLevelState(LevelCore core) : base(core) {}
        
        public override void OnEnter()
        {
            core.model.processes ??= new List<Process>();
            core.model.skillSlots ??= new List<SkillSlot>();
            core.model.skillIcons ??= new List<SkillIcon>();

            SetPlayer();
            core.model.processes.Add(new CameraFollowProcess(core).Start());
            ChangeState(new PrepareSkillsState(core));
        }
        
        private void SetPlayer()
        {
            core.model.playerView = core.factoryService.players.Produce();
            core.model.playerView.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
        }
    }
}