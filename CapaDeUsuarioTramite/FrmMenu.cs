using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void lblminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblnormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            lblnormal.Visible = false;
            lblmaximizar.Visible = true;
            
        }

        private void lblmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            lblmaximizar.Visible = false;
            lblnormal.Visible = true;
        }

        private void lbleliminar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage CurrentTab = tabControl1.TabPages[e.Index];
            Rectangle ItemRect = tabControl1.GetTabRect(e.Index);
            SolidBrush FillBrush = new SolidBrush(Color.Red);
            SolidBrush TextBrush = new SolidBrush(Color.White);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //If we are currently painting the Selected TabItem we'll
            //change the brush colors and inflate the rectangle.
            if (System.Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                FillBrush.Color = Color.White;
                TextBrush.Color = Color.Red;
                ItemRect.Inflate(2, 2);
            }

            //Set up rotation for left and right aligned tabs
            if (tabControl1.Alignment == TabAlignment.Left || tabControl1.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tabControl1.Alignment == TabAlignment.Left)
                    RotateAngle = 270;
                PointF cp = new PointF(ItemRect.Left + (ItemRect.Width / 2), ItemRect.Top + (ItemRect.Height / 2));
                e.Graphics.TranslateTransform(cp.X, cp.Y);
                e.Graphics.RotateTransform(RotateAngle);
                ItemRect = new Rectangle(-(ItemRect.Height / 2), -(ItemRect.Width / 2), ItemRect.Height, ItemRect.Width);
            }

            //Next we'll paint the TabItem with our Fill Brush
            e.Graphics.FillRectangle(FillBrush, ItemRect);

            //Now draw the text.
            e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, (RectangleF)ItemRect, sf);

            //Reset any Graphics rotation
            e.Graphics.ResetTransform();

            //Finally, we should Dispose of our brushes.
            FillBrush.Dispose();
            TextBrush.Dispose();
        }
    }
}
