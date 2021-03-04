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
        Form form1 = new Form1();
        Form form2 = new Form2();
        public mainForm()
        {
            InitializeComponent();
            initial_Page();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void initial_Page()
        {
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


            //不要顯示Title
            form2.FormBorderStyle = FormBorderStyle.None;

            //非最上層
            form2.TopLevel = false;

            //顯示From，要加上去才會顯示Form
            form2.Visible = true;

            //設定From位置
            form2.Top = 0;
            form2.Left = 0;

            //將Form加入tabPage中
            tabPage2.Controls.Add(form2);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Hide();
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:

                    //顯示tabPage
                    tabPage1.Show();

                    break;
                case 1:

                    //顯示tabPage
                    tabPage2.Show();
                    break;
                case 2:
                    //do page2
                    break;
            }
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            //顯示tabPage
            tabPage1.Show();
        }
    }
}
