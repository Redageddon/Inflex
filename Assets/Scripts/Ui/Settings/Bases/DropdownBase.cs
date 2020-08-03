using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Bases
{
    public abstract class DropdownBase : MonoBehaviour //SettingsBase
    {
        [SerializeField] private Dropdown dropdown;

        protected Dropdown Dropdown => this.dropdown;

        protected abstract int Index { get; set; }

        protected abstract void FillDropdown();

        protected virtual void OnOptionChange(int index)
        {
            this.Index = index;
            ScreenResolution.Refresh();
        }

        private void Start()
        {
            this.dropdown.onValueChanged.AddListener(this.OnOptionChange);
            this.dropdown.ClearOptions();
            this.FillDropdown();
            if (this.Index == 0)
            {
                this.OnOptionChange(0);
            }

            this.dropdown.value = this.Index;
            this.dropdown.RefreshShownValue();
        }
    }
}