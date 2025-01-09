using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SMARTGradeTracker
{
    public class History
    {
        private Stack<Form> backStack;
        private Stack<Form> forwardStack;
        private Form currentForm;

        public bool CanGoBack => backStack.Count > 0;
        public bool CanGoForward => forwardStack.Count > 0;

        public History()
        {
            backStack = new Stack<Form>();
            forwardStack = new Stack<Form>();
        }

        public void AddToHistory(Form newForm, Form currentForm)
        {
            if (currentForm != null)
            {
                backStack.Push(currentForm);
                currentForm.Hide();  // Hide the current form
                forwardStack.Clear();
            }
            NavigateToForm(newForm);
        }

        public void BackForm()
        {
            if (!CanGoBack) return;

            if (currentForm != null)
            {
                forwardStack.Push(currentForm);
                currentForm.Hide();  // Hide current form before going back
            }

            currentForm = backStack.Pop();
            NavigateToForm(currentForm);
        }

        public void ForwardForm()
        {
            if (!CanGoForward) return;

            if (currentForm != null)
            {
                backStack.Push(currentForm);
                currentForm.Hide();  // Hide current form before going forward
            }

            currentForm = forwardStack.Pop();
            NavigateToForm(currentForm);
        }

        private void NavigateToForm(Form form)
        {
            currentForm = form;
            currentForm.Show();
        }
    }
}