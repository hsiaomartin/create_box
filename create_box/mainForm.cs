using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace create_box
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    Form form1 = new Form1();
                    //不要顯示Title
                    form1.FormBorderStyle = FormBorderStyle.None;

                    //非最上層
                    form1.TopLevel = false;

                    //顯示From，要加上去才會顯示Form
                    form1.Visible = true;

                    //設定From位置
                    form1.Top = 0;
                    form1.Left = 0;

                    //將Form加入tabPage中
                    tabPage1.Controls.Add(form1);

                    //顯示tabPage
                    tabPage1.Show();
                    break;
                case 1:
                    //do page1
                    break;
                case 2:
                    //do page2
                    break;
            }
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            //不要顯示Title
            form1.FormBorderStyle = FormBorderStyle.None;

            //非最上層
            form1.TopLevel = false;

            //顯示From，要加上去才會顯示Form
            form1.Visible = true;

            //設定From位置
            //form1.Top = 0;
            //form1.Left = 0;
            
            //將Form加入tabPage中
            tabPage1.Controls.Add(form1);

            //顯示tabPage
            tabPage1.Show();
        }
    }
}
