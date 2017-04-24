using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ITAdvices.CustomUI
{
    public partial class uiElement : ListBox
    {
        public uiType Type { get; set; }
        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            base.OnPagePreLoad(sender, e);
            SelectionMode = ListSelectionMode.Multiple;
        }



        protected override void Render(HtmlTextWriter writer)
        {
            if (this.Items == null || this.Items.Count == 0)
                return;
            switch (Type)
            {
                case uiType.CheckBox:
                    foreach (ListItem i in this.Items)
                        renderCheckBox(writer, i.Value, i.Text);
                    break;
                case uiType.RadioButton:
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "custom-controls-stacked");
                    foreach (ListItem i in this.Items)
                        div.Controls.Add(renderRadioButton(i.Value, i.Text));

                    div.RenderControl(writer);
                    break;
            }
        }
        //<div class="custom-controls-stacked">
        //  <label class="custom-control custom-radio">
        //    <input id = "radioStacked1" name="radio-stacked" type="radio" class="custom-control-input">
        //    <span class="custom-control-indicator"></span>
        //    <span class="custom-control-description">Toggle this custom radio</span>
        //  </label>
        //  <label class="custom-control custom-radio">
        //    <input id = "radioStacked2" name="radio-stacked" type="radio" class="custom-control-input">
        //    <span class="custom-control-indicator"></span>
        //    <span class="custom-control-description">Or toggle this other custom radio</span>
        //  </label>
        //</div>
        private Control renderRadioButton(string id, string text)
        {
            HtmlGenericControl label = new HtmlGenericControl("label");
            label.Attributes.Add("class", "custom-control custom-radio");

            HtmlGenericControl input = new HtmlGenericControl("input");
            input.Attributes.Add("name", "radio-stacked" + ID);
            input.Attributes.Add("type", "radio");
            input.Attributes.Add("class", "custom-control-input");
            input.ID = id;

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "custom-control-indicator");
            HtmlGenericControl span2 = new HtmlGenericControl("span");
            span2.Attributes.Add("class", "custom-control-description");
            span2.InnerText = text;

            label.Controls.Add(input);
            label.Controls.Add(span);
            label.Controls.Add(span2);

            return label;
        }
        //<label class="custom-control custom-checkbox">
        //    <input id = "chkRememberMe" runat="server" type="checkbox" class="custom-control-input">
        //    <span class="custom-control-indicator"></span>
        //    <span class="custom-control-description">Ricordami</span>
        //</label>
        private void renderCheckBox(HtmlTextWriter writer, string id, string text)
        {
            HtmlGenericControl label = new HtmlGenericControl("label");
            label.Attributes.Add("class", "custom-control custom-checkbox");

            HtmlGenericControl input = new HtmlGenericControl("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("class", "custom-control-input");
            input.ID = id;

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "custom-control-indicator");

            HtmlGenericControl span2 = new HtmlGenericControl("span");
            span2.Attributes.Add("class", "custom-control-description");
            span2.InnerText = text;

            label.Controls.Add(input);
            label.Controls.Add(span);
            label.Controls.Add(span2);

            label.RenderControl(writer);
        }
    }

    public enum uiType
    {
        Unset,
        CheckBox,
        RadioButton,
    }
}