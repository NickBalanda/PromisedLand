using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

[CustomEditor(typeof(TweenOptions))]
public class SimpleTweenOptionsEditor : Editor{

	public override void OnInspectorGUI(){
		
		TweenOptions myScript = (TweenOptions)target;

		EditorGUILayout.Space ();

		myScript.myTweenType = (TweenOptions.TweenType)EditorGUILayout.EnumPopup ("Tween option", myScript.myTweenType);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		myScript.playOnStart = EditorGUILayout.Toggle ("Play On Start?", myScript.playOnStart);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		myScript.startDelay = EditorGUILayout.FloatField ("Start Delay", myScript.startDelay);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		switch(myScript.myTweenType)
		{
		case TweenOptions.TweenType.Move: 
			myScript.movePosition = EditorGUILayout.Vector3Field ("Move Position", myScript.movePosition);
			EditorGUILayout.Space ();
			myScript.moveDuration = EditorGUILayout.FloatField ("Move Duration", myScript.moveDuration);
            EditorGUILayout.Space();
            myScript.localMove = EditorGUILayout.Toggle("Is local Movement?", myScript.localMove);
                break;
		case TweenOptions.TweenType.Scale:
			myScript.scaleSize = EditorGUILayout.FloatField ("Scale Size", myScript.scaleSize);
			EditorGUILayout.Space ();
			myScript.scaleDuration = EditorGUILayout.FloatField ("Scale Duration", myScript.scaleDuration);
			break;
		case TweenOptions.TweenType.Rotate:
			myScript.rotatePosition = EditorGUILayout.Vector3Field ("Rotate Position", myScript.rotatePosition);
			EditorGUILayout.Space ();
			myScript.rotateDuration = EditorGUILayout.FloatField ("Rotate Duration", myScript.rotateDuration);
			EditorGUILayout.Space ();
			myScript.rotateMode = (RotateMode)EditorGUILayout.EnumPopup ("Rotate Mode", myScript.rotateMode);
			break;
		case TweenOptions.TweenType.Color:
			myScript.color = EditorGUILayout.ColorField ("Color to change", myScript.color);
			EditorGUILayout.Space ();
			myScript.colorDuration = EditorGUILayout.FloatField ("Color Duration", myScript.colorDuration);
			break;
		case TweenOptions.TweenType.Path:
			serializedObject.Update ();
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("waypoints"), true);
			serializedObject.ApplyModifiedProperties ();
			EditorGUILayout.Space ();
			myScript.pathDuration = EditorGUILayout.FloatField ("Path Duration", myScript.pathDuration);
            EditorGUILayout.Space();
            myScript.closePath = EditorGUILayout.Toggle("Closed Path?", myScript.closePath);
			EditorGUILayout.Space ();
			myScript.pathType = (PathType)EditorGUILayout.EnumPopup ("Path Type", myScript.pathType);
			EditorGUILayout.Space ();
			myScript.pathMode = (PathMode)EditorGUILayout.EnumPopup ("Path Mode", myScript.pathMode);
            EditorGUILayout.Space();
            myScript.localPath = EditorGUILayout.Toggle("Is local Path?", myScript.localPath);
            break;
		case TweenOptions.TweenType.Shake:
			GUILayout.Label ("POSITION", EditorStyles.boldLabel);
			myScript.shakePosition = EditorGUILayout.Toggle ("Shake Position", myScript.shakePosition);
			EditorGUILayout.Space ();
			if (myScript.shakePosition) {
				myScript.shakePduration = EditorGUILayout.FloatField ("Shake Duration", myScript.shakePduration);
				myScript.shakePstrenght = EditorGUILayout.FloatField ("Shake strenght", myScript.shakePstrenght);
				myScript.shakePvibrato = EditorGUILayout.IntField ("Shake Vibrato", myScript.shakePvibrato);
				myScript.shakePrandomness = EditorGUILayout.FloatField ("Shake Randomness", myScript.shakePrandomness);
				myScript.shakePfadeOut = EditorGUILayout.Toggle ("Fade Out", myScript.shakePfadeOut);
				myScript.shakePsnapping = EditorGUILayout.Toggle ("Snapping", myScript.shakePsnapping);
				EditorGUILayout.Space ();
			}
			GUILayout.Label ("ROTATION", EditorStyles.boldLabel);
			myScript.shakeRotation = EditorGUILayout.Toggle ("Shake Rotation", myScript.shakeRotation);
			EditorGUILayout.Space ();
			if (myScript.shakeRotation) {
				myScript.shakeRduration = EditorGUILayout.FloatField ("Shake Duration", myScript.shakeRduration);
				myScript.shakeRstrenght = EditorGUILayout.FloatField ("Shake strenght", myScript.shakeRstrenght);
				myScript.shakeRvibrato = EditorGUILayout.IntField("Shake Vibrato", myScript.shakeRvibrato);
				myScript.shakeRrandomness = EditorGUILayout.FloatField ("Shake Randomness", myScript.shakeRrandomness);
				myScript.shakeRfadeOut = EditorGUILayout.Toggle ("Fade Out",myScript.shakeRfadeOut);
				EditorGUILayout.Space ();
			}
			GUILayout.Label ("SCALE", EditorStyles.boldLabel);
			myScript.shakeScale = EditorGUILayout.Toggle ("Shake Scale", myScript.shakeScale);
			EditorGUILayout.Space ();
			if ( myScript.shakeScale) {
				myScript.shakeSduration = EditorGUILayout.FloatField ("Shake Duration", myScript.shakeSduration);
				myScript.shakeSstrenght = EditorGUILayout.FloatField ("Shake strenght", myScript.shakeSstrenght);
				myScript.shakeSvibrato = EditorGUILayout.IntField("Shake Vibrato", myScript.shakeSvibrato);
				myScript.shakeSrandomness = EditorGUILayout.FloatField ("Shake Randomness", myScript.shakeSrandomness);
				myScript.shakeSfadeOut = EditorGUILayout.Toggle ("Fade Out",myScript.shakeSfadeOut);
				EditorGUILayout.Space ();
			}
			break;
		}

		GUILayout.Space (20);
		EditorGUILayout.LabelField ("LOOP AND EASE SETTINGS:");
		EditorGUILayout.Space ();
		EditorGUILayout.HelpBox("if number of loops set to -1 we get infinite loops ",MessageType.Info);
		myScript.numLoops = EditorGUILayout.IntField ("Number of loops", myScript.numLoops);
		myScript.loopeType = (LoopType)EditorGUILayout.EnumPopup ("Loope Type", myScript.loopeType);
		myScript.ease = (Ease)EditorGUILayout.EnumPopup ("Ease Type", myScript.ease);

	}
}
