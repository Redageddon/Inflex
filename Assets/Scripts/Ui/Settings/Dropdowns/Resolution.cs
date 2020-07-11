using System.Collections.Generic;
using System.Linq;
using Logic;
using Ui.Settings.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Settings.Dropdowns
{
    public class Resolution : DropdownBase
    {
        private IEnumerable<Dropdown.OptionData> optionDatas;
        private void Awake() => this.optionDatas = Screen.resolutions.Select(r => $"{r.width} x {r.height}").Distinct().Select(r => new Dropdown.OptionData(r));

        protected override int Index
        {
            get
            {
                for (int i = 0; i < this.optionDatas.Count(); i++)
                {
                    if (this.optionDatas.ElementAt(i).text.Equals($"{Assets.Instance.Settings.Resolution.Width} x {Assets.Instance.Settings.Resolution.Height}"))
                    {
                        return i;
                    }
                }
                return 0;
            }
            set
            {
                string[] values = this.Dropdown.options[value].text.Split("x".ToCharArray());
                Assets.Instance.Settings.Resolution.Width = int.Parse(values[0]);
                Assets.Instance.Settings.Resolution.Height = int.Parse(values[1]);
            }
        }

        protected override void FillDropdown() => this.Dropdown.options.AddRange(this.optionDatas);
    }
}