namespace Scripts.Player
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    public class ColourPicker : MonoBehaviour
    {
        [SerializeField]
        private GameObject _headColorPicker;


        [SerializeField]
        private GameObject _bodyColorPicker;


        [SerializeField]
        private GameObject _lightAccentColorPicker;

        [SerializeField]
        private GameObject _darkAccentColorPicker;

        private Material _spriteMaterial;

        private void Awake()
        {
            _spriteMaterial = GetComponent<SpriteRenderer>().material;

            string[] colorValues = { "_Head", "_Body", "_AccentLight", "_AccentDark" };
            GameObject[] colorPickers = { _headColorPicker, _bodyColorPicker, _lightAccentColorPicker, _darkAccentColorPicker };

            for (int colorIndex = 0; colorIndex < colorPickers.Length; ++colorIndex)
            {
                string colorValue = colorValues[colorIndex];

                colorPickers[colorIndex].GetComponent<ColorPickerTriangle>()
                                        .ColorChanged
                                        .AddListener(color => _spriteMaterial.SetColor(colorValue, color));
            }
        }
    }
}