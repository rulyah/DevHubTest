using System.Collections.Generic;
using Level.Views;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public float cameraSensitivity = 15.0f;
        public float cameraSmooth = 0.1f;
        public float cameraVerticalMin = -10.0f;
        public float cameraVerticalMax = 10.0f;
        public List<Sprite> skillImages;
        public List<SkillEffects> effects;
    }
}