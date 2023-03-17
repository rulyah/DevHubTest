using Level.States;
using Services.Factory;
using UI;
using UnityEngine;
using Utils.ProcessTool;
using Utils.StateMachineTool;

namespace Level
{
    public class LevelCore : MonoBehaviour, ICoroutineRunner
    {
        [Header("Services")]
        public FactoryService factoryService;

        [Header("Screens")]
        public MenuScreen menuScreen;
        public GameScreen gameScreen;
        
        [Space]
        public LevelConfig config;
        public LevelModel model { get; private set; }
        
        
        private StateMachine<LevelCore> _stateMachine;

        private void Start()
        {
            model = new LevelModel();
            _stateMachine = new StateMachine<LevelCore>(new PrepareGameState(this));
        }
    }
}