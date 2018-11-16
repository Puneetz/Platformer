﻿namespace Scripts.Attributes
{
    using UnityEditor;

    using UnityEngine;

    public class SerializeAs : PropertyAttribute
    {
        private readonly string _label;

        public SerializeAs(string label)
        {
            _label = label;
        }

        [CustomPropertyDrawer(typeof(SerializeAs))]
        public class ThisPropertyDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                SerializeAs propertyAttribute = (SerializeAs)attribute;

                if (IsArray(property))
                {
                    Debug.LogWarningFormat("{0} (\"{1}\") does not support arrays", typeof(SerializeAs).Name, propertyAttribute._label);
                }
                else
                {
                    label.text = propertyAttribute._label;
                }

                EditorGUI.PropertyField(position, property, label);
            }

            private static bool IsArray(SerializedProperty property)
            {
                int periodIndex = property.propertyPath.IndexOf('.');

                if (periodIndex == -1)
                {
                    return false;
                }

                string propertyName = property.propertyPath.Substring(0, periodIndex);

                return property.serializedObject
                               .FindProperty(propertyName)
                               .isArray;
            }
        }
    }
}