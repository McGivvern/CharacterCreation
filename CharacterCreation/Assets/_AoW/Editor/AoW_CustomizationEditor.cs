using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(AoW_Customization))]
public class AoW_CustomizationEditor : Editor 
{
    private SerializedObject  _aow;

    private static bool _generalIsOpen;
    private SerializedProperty _atlasResolutionScale;
    private SerializedProperty _animationController;

    private static bool _colorsIsOpen;
    //Eye Color variables
    private SerializedProperty _eyeColors;
    private int _eyeColorsCount;
    private int _oldEyeColorsCount;
    private static bool _showEyecolors;

    //Hair Color variables
    private SerializedProperty _hairColors;
    private int _hairCorlorsCount;
    private int _oldHairColorsCount;
    private static bool _showHairColors;

    //Skin Tone variables
    private SerializedProperty _skinTones;
    private int _skinToneCount;
    private int _oldSkinToneCount;
    private static bool _showSkinTones;

    //Shirt Color variables
    private SerializedProperty _shirtColors;
    private int _shirtColorsCount;
    private int _oldShirtColorsCount;
    private static bool _showShirtColors;

    void OnEnable()
    {
        _aow = new SerializedObject(target);

        _atlasResolutionScale = _aow.FindProperty("AtlasResolutionScale");
        _animationController = _aow.FindProperty("AnimationController");

        //Eye Color variables
        _eyeColors = _aow.FindProperty("EyeColors");
        _eyeColorsCount = _eyeColors.arraySize;
        _oldEyeColorsCount = _eyeColorsCount;

        //Hair Color variables
        _hairColors = _aow.FindProperty("HairColors");
        _hairCorlorsCount = _hairColors.arraySize;
        _oldHairColorsCount = _hairCorlorsCount;

        //Skin Tone variables
        _skinTones = _aow.FindProperty("SkinTones");
        _skinToneCount = _skinTones.arraySize;
        _oldSkinToneCount = _skinToneCount;

        //Shirt Color variables
        _shirtColors = _aow.FindProperty("ShirtColors");
        _shirtColorsCount = _shirtColors.arraySize;
        _oldShirtColorsCount = _shirtColorsCount;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal("box");
        GUILayout.FlexibleSpace();
        GUILayout.Label("Age of Wolves Studios Character Customization Thingie", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Label("");

        _generalIsOpen = EditorGUILayout.Foldout(_generalIsOpen, "General");

        if (_generalIsOpen)
        {
             _atlasResolutionScale.floatValue = EditorGUILayout.Slider("Atlas Resolution Scale: ", _atlasResolutionScale.floatValue, 0, 10);
            _animationController.objectReferenceValue = EditorGUILayout.ObjectField("Animation Controller", _animationController.objectReferenceValue, typeof(RuntimeAnimatorController), true) as RuntimeAnimatorController;
        }
        GUILayout.Label("");

        _colorsIsOpen = EditorGUILayout.Foldout(_colorsIsOpen, "Colors");

        if (_colorsIsOpen)
        {
            _showEyecolors = EditorGUILayout.Foldout(_showEyecolors, "Eye Colors");

            if (_showEyecolors)
            {
                _eyeColorsCount = EditorGUILayout.IntField("Size", _eyeColorsCount);

                if (_oldEyeColorsCount < _eyeColorsCount)
                {
                    _eyeColors.arraySize++;
                    _oldEyeColorsCount = _eyeColorsCount;
                }
                else if (_oldEyeColorsCount > _eyeColorsCount)
                {
                    _eyeColors.arraySize--;
                    _oldEyeColorsCount = _eyeColorsCount;
                }

                for (int i = 0; i < _eyeColorsCount; i++)
                {
                    _eyeColors.GetArrayElementAtIndex(i).colorValue = EditorGUILayout.ColorField("Element " + i.ToString(), _eyeColors.GetArrayElementAtIndex(i).colorValue);
                }
            }

            _showHairColors = EditorGUILayout.Foldout(_showHairColors, "Hair Colors");
            if (_showHairColors)
            {
                _hairCorlorsCount = EditorGUILayout.IntField("Size", _hairCorlorsCount);

                if (_oldHairColorsCount < _hairCorlorsCount)
                {
                    _hairColors.arraySize++;
                    _oldHairColorsCount = _hairCorlorsCount;
                }
                else if (_oldHairColorsCount > _hairCorlorsCount)
                {
                    _hairColors.arraySize--;
                    _oldHairColorsCount = _hairCorlorsCount;
                }

                for (int i = 0; i < _hairCorlorsCount; i++)
                {
                    EditorGUILayout.ColorField("Element " + i.ToString(), _hairColors.GetArrayElementAtIndex(i).colorValue);
                }
            }

            _showSkinTones = EditorGUILayout.Foldout(_showSkinTones, "Skin Tones");
            if (_showSkinTones)
            {
                _skinToneCount = EditorGUILayout.IntField("Size", _skinToneCount);

                if (_oldSkinToneCount < _skinToneCount)
                {
                    _skinTones.arraySize++;
                    _oldSkinToneCount = _skinToneCount;
                }
                else if (_oldSkinToneCount > _skinToneCount)
                {
                    _skinTones.arraySize--;
                    _oldSkinToneCount = _skinToneCount;
                }

                for (int i = 0; i < _skinToneCount; i++)
                {
                    EditorGUILayout.ColorField("Element " + i.ToString(), _skinTones.GetArrayElementAtIndex(i).colorValue);
                }
            }

            _showShirtColors = EditorGUILayout.Foldout(_showShirtColors, "Shirt Colors");
            if (_showShirtColors)
            {
                _shirtColorsCount = EditorGUILayout.IntField("Size", _shirtColorsCount);

                if (_oldShirtColorsCount < _shirtColorsCount)
                {
                    _shirtColors.arraySize++;
                    _oldShirtColorsCount = _shirtColorsCount;
                }
                else if (_oldShirtColorsCount > _shirtColorsCount)
                {
                    _shirtColors.arraySize--;
                    _oldShirtColorsCount = _shirtColorsCount;
                }

                for (int i = 0; i < _shirtColorsCount; i++)
                {
                    EditorGUILayout.ColorField("Element " + i.ToString(), _shirtColors.GetArrayElementAtIndex(i).colorValue);
                }
            }
        }

        _aow.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}
