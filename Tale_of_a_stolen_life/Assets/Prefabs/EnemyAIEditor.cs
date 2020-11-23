using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyAI))]

public class EnemyAIEditor : Editor
{

	public GameObject waypoint; // префаб вейпоинта

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		EnemyAI t = (EnemyAI)target;
		if (GUILayout.Button("Generate Waypoints"))
		{
			t.GenerateWaypoints(waypoint);
		}
	}
}