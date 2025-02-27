﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UIPlugin
{
    /// <summary>
    /// 自动销毁
    /// </summary>
    public class DestoryAuto : MonoBehaviour
    {
        public float WaitTime;
        // Use this for initialization
        private void Start()
        {
            StartCoroutine(DelayDestory());
        }


        private IEnumerator DelayDestory()
        {
            yield return new WaitForSeconds(WaitTime);

            Destroy(gameObject);
        }
    }
}