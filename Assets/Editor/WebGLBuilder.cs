using UnityEditor;

namespace LotusGangWars.Editor
{
    public class WebGLBuilder
    {
        private const string MAIN_SCENE = "Assets/_Scenes/Main.unity";
        private const string TEST_SCENE = "Assets/_Scenes/Test.unity";
        
        static void Build()
        {
            string[] scenes = { MAIN_SCENE };
            string pathToDeploy = "Builds/lotus-gang-wars";
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);
        }
    }
}