using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymNotes;

namespace UiForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exercise.Load();
            foreach (var exercise in Exercise.Items)
            {
                LbAll.Items.Add(exercise);
            }
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            ThrowItem(LbAll, LbSelected);
        }

        private void ThrowItem(ListBox source, ListBox goal)
        {
            var item = source.SelectedItem;
            if (item == null) return;

            goal.Items.Add(item);
            source.Items.Remove(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThrowItem(LbSelected, LbAll);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (LbSelected.Items.Count > 0)
                TbMessage.Text = "Training Started";
            else
            {
                TbMessage.Text = "Can't start. Select exercise";
            }
        }
    }
}
