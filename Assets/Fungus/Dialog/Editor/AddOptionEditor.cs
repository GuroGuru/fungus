using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rotorz.ReorderableList;

namespace Fungus.Script
{

	[CustomEditor (typeof(AddOption))]
	public class AddOptionEditor : FungusCommandEditor
	{
		public override void DrawCommandGUI() 
		{
			AddOption t = target as AddOption;

			EditorGUI.BeginChangeCheck();

			string optionText = EditorGUILayout.TextField(new GUIContent("Option Text", "Text display on the option button."),
			                                              t.optionText);

			Sequence targetSequence = SequenceEditor.SequenceField(new GUIContent("Target Sequence", "Sequence to execute when this option is selected by the player."),
			                                                       new GUIContent("<Continue>"),
			                                                       t.GetFungusScript(),
			                                                       t.targetSequence);

			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(t, "Set Add Option");
				t.optionText = optionText;
				t.targetSequence = targetSequence;
			}			
		}
	}

}