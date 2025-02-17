using System;
using TMPro;
using UnityEngine;

namespace KSIShareable.UI.Dialog
{
    public class BasicConfirmationDialog : ConfirmationDialog
    {
        [SerializeField] protected TextMeshProUGUI questionText;
        [SerializeField] protected TextMeshProUGUI yesBtnText;
        [SerializeField] protected TextMeshProUGUI noBtnText;

        public ConfirmationDialog Init(string questionText, string yesBtnText, string noBtnText, Action onClickYes, Action onClickNo) {
            this.questionText.text = questionText;
            this.yesBtnText.text = yesBtnText;
            this.noBtnText.text = noBtnText;

            base.Init(onClickYes, onClickNo);

            return this;
        }


    }
}
