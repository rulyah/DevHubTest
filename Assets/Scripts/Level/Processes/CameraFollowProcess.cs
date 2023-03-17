using Level.Views;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class CameraFollowProcess : Process
    {
        private readonly PlayerView _player;
        private readonly LevelCameraView _camera;
     
        public CameraFollowProcess(LevelCore core) : base(core)
        {
            _player = core.model.playerView;
            _camera = core.model.levelCameraView;
        }

        protected override void OnUpdate()
        {
            _camera.transform.position = _player.transform.position;
            _camera.transform.forward = _player.transform.forward;
        }
    }
}