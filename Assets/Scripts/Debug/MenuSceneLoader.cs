using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuSceneLoader
{
    private const string LobbyScene = "Assets/Scenes/TitleScene.unity";
    private const string GameScene = "Assets/Scenes/Testing/Input-ds.unity";

    [MenuItem("Scene/Lobby")] 
    private static void Lobby() => OpenScene(LobbyScene);

    [MenuItem("Scene/Game")] 
    private static void Game() => OpenScene(GameScene);

    private static void OpenScene(string scene) => EditorSceneManager.OpenScene(scene);
}
