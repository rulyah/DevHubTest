using Level.Processes;
using Utils.StateMachineTool;
using Object = UnityEngine.Object;

namespace Level.States
{
    public class GamePlayState : State<LevelCore>
    {
        public GamePlayState(LevelCore core) : base(core) {}

        private InputProcess _inputProcess;
        
        public override void OnEnter()
        {
            _inputProcess = (InputProcess)core.model.processes.Find(n => n is InputProcess);

            if (_inputProcess == null)
            {
                _inputProcess = new InputProcess(core);
                _inputProcess.Start();
                core.model.processes.Add(_inputProcess);
            }
            
            _inputProcess.onFire += OnFire;
            core.model.playerView.onCasted += OnCasted;
        }

        private void OnCasted()
        {
            core.model.skillView.Fire(10.0f);
            ChangeState(new CheckCollisionState(core));
        }

        private void OnFire(int skillId)
        {
            if (core.model.playerView.isDoubleCast) return;
            
            if (core.model.playerView.isCast)
            {
                if(skillId == core.model.currentSkillId) return;
                ChangeSkill(skillId);
            }
            else
            {
                CreateSkill(skillId);
            }
        }

        private void ChangeSkill(int skillId)
        {
            var firstSkill = core.model.skillView;
            core.model.currentSkillId = GetNewSkillId(core.model.currentSkillId, skillId);
            Object.Destroy(firstSkill.gameObject);
            CreateSkill(core.model.currentSkillId);
        }

        private int GetNewSkillId(int firstSkillId, int secondSkillId)
        {
            return (firstSkillId + secondSkillId) switch
            {
                3 => 5,
                2 => 4,
                _ => 3
            };
        }

        private void CreateSkill(int skillId)
        {
            core.model.currentSkillId = skillId;
            var skillView = Object.Instantiate(core.config.effects[skillId].skillView);
            core.model.skillView = skillView;
            skillView.transform.position = core.model.playerView.shootPoint.position;
            skillView.transform.forward = core.model.playerView.transform.forward;
            core.model.playerView.CastSkill();
        }

        public override void OnExit()
        {
            _inputProcess.onFire -= OnFire;
            core.model.playerView.onCasted -= OnCasted;
        }
    }
}