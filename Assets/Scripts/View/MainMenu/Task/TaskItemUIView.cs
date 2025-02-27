﻿using Assets.Scripts.Presenter.Manager;
using Assets.Scripts.UIPlugin;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View.MainMenu.Task
{
    public class TaskItemUIView : MonoBehaviour
    {
        public Text nameText;
        public Text descriptionText;
        public Text coinText;
        public Text diamondText;
        public Image icon;
        public Image taskType;
        public Button button;
        //任务面板缩放
        [HideInInspector] public UIScale TaskUiScale;

        private string AssetPath = "ItemPrefabs/";
        private Task task;


        public void SetTask(Task task)
        {
            this.task = task;

            nameText.text = task.Name;
            descriptionText.text = task.Description;
            coinText.text = task.Coin.ToString();
            diamondText.text = task.Diamond.ToString();

            GameObject iconSpritePre = Resources.Load<GameObject>(AssetPath + task.Icon);
            icon.sprite = iconSpritePre.GetComponent<SpriteRenderer>().sprite;

            GameObject typeSpritePre = Resources.Load<GameObject>(AssetPath + task.TaskType.ToString());
            taskType.sprite = typeSpritePre.GetComponent<SpriteRenderer>().sprite;

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            TaskManager.Instance.Excute(task);
            TaskUiScale.ScaleOut();
        }
    }
}