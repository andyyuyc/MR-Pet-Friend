using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class ReadmeWindow : EditorWindow
{
    bool showUIText = true;
    bool showSceneNavText = true;

    int labelFieldHeight = 200;
    int labelFieldWidth = 400;

    [MenuItem("Window/ Read Me")]
    // Start is called before the first frame update
    static void Init()
    {
        ReadmeWindow window = (ReadmeWindow)EditorWindow.GetWindow(typeof(ReadmeWindow));
        window.Show();
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUIStyle readMeStyle = new GUIStyle(EditorStyles.label);
        readMeStyle.wordWrap = true;
        readMeStyle.richText = true;
 
        EditorGUILayout.LabelField("<b>USER INTERFACE</b>\nProject Window - Locate and manage all of the assets in the project\n" +
                                        "Hierarchy – Contains a list of every GameObject in the current scene\n" +
                                        "Scene View – Editor view of the project\n" +
                                        "Inspector Window – List of editable characteristics about GameObjects \n" +
                                        "Toolbar – Contains several groups of controls \n\n" +
                                        "<b>TERMINOLOGY</b>\n" +
                                        "Asset – A game file (e.g. texture, scripts, 3D models). All assets are stored in the Assets folder and are visible in the Project Window.\n" +
                                        "GameObject – The pieces that make up a scene. These are viewable in the Hierarchy Window.\n" +
                                        "Component – A module piece of behavior added to GameObjects and visible in the Inspector window.\n" +
                                        "Play Mode – When the project begins to run and simulates what the user will see. Changes made in Play Mode are not saved.\n" +
                                        "Prefab – Templates of GameObjects that can be reused.\n" +
                                        "Script – A piece of code that allows you to add custom behavior to your GameObjects. Scripts are written in C#, which is the programming language of Unity.\n\n" +
                                        "<b>SCENE VIEW NAVIGATION </b>\n" +
                                        "Movement: \n" +
                                        "Around: Arrow Keys or W, A, S, D + right-click\n" +
                                        "Up and Down: Q, E + right-click\n" +
                                        "Zoom: Middle mouse button\n" +
                                        "Orbit: Alt / Opt(Mac) + left-click\n" +
                                        "Focus: Select GameObject, place cursor over Scene Window, tap F\n\n" +
                                        "<b>TOOLBAR</b>\n" +
                                        "Hand - Move scene around (Q)\n" +
                                        "Translate - Reposition GameObjects (W)\n" +
                                        "Rotate - Rotate GameObjects (E)\n" +
                                        "Scale - Scale GameObjects (R)\n\n" +
                                        "<b>MISCELLANEOUS</b>\n" +
                                        "Save: ctrl / cmd(Mac) + S\n" +
                                        "Duplicate: ctrl / cmd(Mac) + D\n" +
                                        "Undo: ctrl / cmd(Mac) + Z", readMeStyle);
        
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }
}
