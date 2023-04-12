using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//collapseButton.Image = isCollapsed ? Bitmap.FromFile(".\\icons8_expand_arrow_32.png") : Bitmap.FromFile(".\\icons8_Collapse_Arrow_32.png");
namespace LABLibary.Forms
{
    public class CollapsibleGroupBox : GroupBox
    {
        private bool _isCollapsed = false;
        private string _collapseText = "Collapse";
        private string _expandText = "Expand";
        private int _expandedHeight;
        private Button _toggleButton;

        [Category("Collapsible GroupBox")]
        [Description("Gets or sets a value indicating whether the group box is collapsed.")]
        [DefaultValue(false)]
        public bool IsCollapsed
        {
            get { return _isCollapsed; }
            set
            {
                if (_isCollapsed != value)
                {
                    _isCollapsed = value;
                    UpdateGroupBox();
                }
            }
        }

        [Category("Collapsible GroupBox")]
        [Description("Gets or sets the text to display when the group box is collapsed.")]
        [DefaultValue("Collapse")]
        public string CollapseText
        {
            get { return _collapseText; }
            set
            {
                if (_collapseText != value)
                {
                    _collapseText = value;
                    UpdateGroupBox();
                }
            }
        }

        [Category("Collapsible GroupBox")]
        [Description("Gets or sets the text to display when the group box is expanded.")]
        [DefaultValue("Expand")]
        public string ExpandText
        {
            get { return _expandText; }
            set
            {
                if (_expandText != value)
                {
                    _expandText = value;
                    UpdateGroupBox();
                }
            }
        }

        public CollapsibleGroupBox()
        {
            _toggleButton = new Button();
            _toggleButton.Size = new Size(15, 15);
            _toggleButton.Location = new Point(Width - _toggleButton.Width - 5, 5);
            _toggleButton.Click += new EventHandler(ToggleButtonClick);
            Controls.Add(_toggleButton);
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            _expandedHeight = Height;
            _toggleButton.Location = new Point(Width - _toggleButton.Width - 5, 5);
        }

        private void UpdateGroupBox()
        {
            if (_isCollapsed)
            {
                _expandedHeight = Height;
                Height = Font.Height + Padding.Top + Padding.Bottom + 6;
                Text = _collapseText;
                _toggleButton.Text = "+";
            }
            else
            {
                Height = _expandedHeight;
                Text = _expandText;
                _toggleButton.Text = "-";
            }
        }

        private void ToggleButtonClick(object sender, EventArgs e)
        {
            _isCollapsed = !_isCollapsed;
            UpdateGroupBox();
        }
    }
}

