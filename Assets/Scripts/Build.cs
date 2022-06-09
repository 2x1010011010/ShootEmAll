using System.Linq;
using UnityEditor;
using UnityEngine;

public static class Build
{
    private const string PASS = "A2D546CA";

    private static string ProjectFolderPath =>
        Application.dataPath.Substring(0, Application.dataPath.Length - "Assets/".Length);

    private static void APK()
    {
        var buildOptions = new BuildPlayerOptions
        {
            scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray(),
            target = BuildTarget.Android,
            locationPathName = "build/Android.apk"
        };
        EditorUserBuildSettings.buildAppBundle = false;
        EditorUserBuildSettings.androidCreateSymbolsZip = false;
        PlayerSettings.Android.useCustomKeystore = true;
        PlayerSettings.Android.keystoreName = $"{Application.dataPath}/BUILD/tarragon.keystore";
        PlayerSettings.Android.keystorePass = PASS;
        PlayerSettings.Android.keyaliasName = "tarragon";
        PlayerSettings.Android.keyaliasPass = PASS;
        BuildPipeline.BuildPlayer(buildOptions);
    }
}
