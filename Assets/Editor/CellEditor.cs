using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("CellLinker", typeof(Cell))]
public class CellEditor : EditorTool
{
    // Start is called before the first frame update
    public override void OnToolGUI(EditorWindow window)
    {
        base.OnToolGUI(window);
    }
}
