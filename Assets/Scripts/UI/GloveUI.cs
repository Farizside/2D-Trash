using System;
using Input;
using Player;
using Trash;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GloveUI : MonoBehaviour
    {
        private Image _image;
        private Color _buttonColor = new Color();

        private void Start()
        {
            _image = GetComponent<Image>();
            GetButtonColor(PlayerController.Instance.playerInteraction._currentGlove);
            SetButtonColor();
        }

        public void OnGloveChanged()
        {
            GetButtonColor(PlayerController.Instance.playerInteraction._currentGlove);
            SetButtonColor();
        }

        private void GetButtonColor(TrashEnum type)
        {
            switch (type)
            {
                case TrashEnum.Organik:
                    _buttonColor = Color.green;
                    break;
                case TrashEnum.Anorganik:
                    _buttonColor = Color.yellow;
                    break;
                case TrashEnum.Kertas:
                    _buttonColor = Color.blue;
                    break;
                case TrashEnum.Residu:
                    _buttonColor = Color.gray;
                    break;
                case TrashEnum.B3:
                    _buttonColor = Color.red;
                    break;
            }
        }

        private void SetButtonColor()
        {
            _image.color = _buttonColor;
        }
    }
}
