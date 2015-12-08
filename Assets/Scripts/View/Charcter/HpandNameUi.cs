﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View.Charcter.Enemy
{
    /// <summary>
    /// 把血条显示在屏幕上
    /// </summary>
    public class HpandNameUi : MonoBehaviour
    {
        public string Name;
        public float HpPercent = 1f;
        public Transform Fellow;
        public Vector3 DelVector3;
        public float FellowSpeed;

        private Slider _slider;
        private Camera _camera;
        private Text _nameText;

        private void Start()
        {
            _slider = transform.GetComponentInChildren<Slider>();
            _nameText = transform.GetComponentInChildren<Text>();
            _camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();

            //初始化自己的大小,防止显示错误
            var rectTransform = transform as RectTransform;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.offsetMin = Vector2.zero;

            //直接显示在目标位置
            Vector2 screenPosition = _camera.WorldToScreenPoint(Fellow.position + DelVector3);
            transform.position = screenPosition;
        }


        private void Update()
        {
            //跟随角色移动
            Vector2 screenPosition = _camera.WorldToScreenPoint(Fellow.position + DelVector3);
            transform.position = Vector3.Lerp(transform.position, screenPosition, FellowSpeed*Time.deltaTime);

            //显示血量
            _slider.value = HpPercent;
        }
    }
}