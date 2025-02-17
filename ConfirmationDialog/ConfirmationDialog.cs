using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KSIShareable.UI.Dialog
{
    public abstract class ConfirmationDialog : MonoBehaviour
    {
        protected Canvas canvas;
        [SerializeField] protected RectTransform dialogRectTransform;

        [SerializeField] protected UnityEvent onClickYes;
        [SerializeField] protected UnityEvent onClickNo;
        

        protected void Awake() {
            canvas = GetComponent<Canvas>();
        }

        protected ConfirmationDialog Init(UnityAction actionOnYes, UnityAction actionOnNo) {
            this.onClickYes.AddListener(actionOnYes);
            this.onClickNo.AddListener(actionOnNo);

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