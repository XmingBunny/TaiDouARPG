﻿using System;
using System.Reflection;
using UnityEngine;


namespace Assets.Scripts.View.Skill.Action
{
    /// <summary>
    /// 所有技能action的基类
    /// </summary>
    public abstract class ActionBase : ScriptableObject, ICloneable
    {
        /// <summary>
        /// 等待执行时间
        /// </summary>
        public float WaitTime;

        /// <summary>
        /// Action类型
        /// </summary>
        public abstract ActionType ActionType { get; }

        /// <summary>
        /// 计时器
        /// </summary>
        protected float _timer = 0f;

        /// <summary>
        /// 是否在执行
        /// </summary>
        public bool IsExcute { get; private set; }

        /// <summary>
        /// 初始化函数,初始化过后才能执行
        /// </summary>
        /// <param name="playerGameObject"></param>
        public abstract void Init(GameObject playerGameObject);

        public virtual void Update()
        {
            if (!IsExcute)
                return;

            if (_timer <= WaitTime)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                Play();
            }
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        public virtual void Excute()
        {
            IsExcute = true;
        }

        /// <summary>
        /// 正在执行
        /// </summary>
        protected abstract void Play();

        /// <summary>
        /// 执行结束
        /// </summary>
        public virtual void Finish()
        {
            IsExcute = false;
            _timer = 0f;
        }

        public object Clone()
        {
            var newObject = Activator.CreateInstance(this.GetType());

            var fildes = GetType().GetFields();

            var thisFilds = GetType().GetFields();

            for (var i = 0; i < thisFilds.Length; i++)
            {
                var fi = thisFilds[i];
                fildes[i].SetValue(newObject, fi.GetValue(this));
            }

            return newObject;
        }
    }

    public enum ActionType : byte
    {
        Attack,
        Buffer
    }
}