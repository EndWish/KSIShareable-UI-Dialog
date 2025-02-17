using System;
using UnityEngine;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{
    public abstract class ConfirmationDialog : MonoBehaviour
    {
        protected Canvas canvas;
        [SerializeField] protected RectTransform dialogRectTransform;

        private Action onClickYes;
        private Action onClickNo;

        protected void Awake() {
            canvas = GetComponent<Canvas>();
        }

        protected ConfirmationDialog Init(Action onClickYes, Action onClickNo) {
            this.onClickYes = onClickYes;
            this.onClickNo = onClickNo;

            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);

            return this;
        }
        public ConfirmationDialog SetWidth(float width) {
            dialogRectTransform.sizeDelta = new Vector2(width, dialogRectTransform.sizeDelta.y);
            LayoutRebuilder.ForceRebuildLayoutImmediate(dialogRectTransform);
            return this;
        }
        public ConfirmationDialog SetSortOder(int order) {
            canvas.sortingOrder = order;
            return this;
        }

        public void ActOnClickYes() {
            onClickYes?.Invoke();
            Destroy(gameObject);
        }
        public void ActOnClickNo() {
            onClickNo?.Invoke();
            Destroy(gameObject);
        }


    }
}