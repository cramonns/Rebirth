using System.Windows.Forms;

namespace Rebirth.EditorClasses
{
    public partial class Form1 : Form {
#if EDITOR
        public Properties p;
        public PropertiesItem pi1,pi2,pi3,pi4;

        public Form1() {
            InitializeComponent();
            p = new Properties();
            pi1 = new PropertiesItem(20, "X", new TextBox());
            pi2 = new PropertiesItem(20, "Y", new TextBox());
            pi3 = new PropertiesItem(20, "Width", new TextBox());
            pi4 = new PropertiesItem(20, "Height", new TextBox());
            
            p.AddItem(pi1);
            p.AddItem(pi2);
            p.AddItem(pi3);
            p.AddItem(pi4);

            this.Controls.Add(p);
            this.Controls.Add(new TextBox());
            p.Width = this.Width;

        }
#endif
    }
}
