using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        List<APS> collect = new List<APS>();
        APS selectingObject;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Задает для узла подузлы, содержащие значения свойств
        /// </summary>
        /// <param name="node"> Коллекция дочерних элементов узла</param>
        /// <param name="item"> Объект, из которого берутся значения свойств</param>
        private void assignValue(TreeNodeCollection node, APS item)
        {
            node.Clear();
            node.Add(item.name);
            node.Add(item.number.ToString());
            node.Add(item.addres);
            node.Add(item.countUsers.ToString());
            node.Add(item.usersPay.ToString());
            node.Add(item.tarif);
            node.Add(item.freeLines.ToString());
        }

        private void Form_Load(object sender, EventArgs e)
        {

            textBoxCount.Text = APS.count.ToString();
            APS newAbstractAPS = new APS("Наша станция", 12345, "ул. Рождественского, 51", 1100, 35.50, "Стандартный", 900);
            collect.Add(newAbstractAPS);
            textBoxIndex.Text = (collect.Count - 1).ToString();
            buttonSelect_Click(null, null);
            textBoxCount.Text = APS.count.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Форма для ввода имени
            InputBox.InputBox inputBox = new InputBox.InputBox();
            String s = inputBox.getString();    // Строка, введенная пользователем
            if (s != null)
            {
                APS newAbstractAPS = new APS(s);
                collect.Add(newAbstractAPS);
                textBoxIndex.Text = (collect.Count - 1).ToString();
                buttonSelect_Click(null, null);
            }
            textBoxCount.Text = APS.count.ToString();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isErrors = false;
            int m1, m2, m4;
            int.TryParse(textBox2.Text, out m1);
            if (int.TryParse(textBox2.Text, out m1) && (m1 >= 0))
            {
                textBox2.BackColor = Color.White;
            }
            else
            {
                isErrors = true;
                textBox2.Focus();
                textBox2.BackColor = Color.Red;
            }
            if (int.TryParse(textBox4.Text, out m2) && (m2 >= 0))
            {
                textBox4.BackColor = Color.White;
            }
            else
            {
                isErrors = true;
                textBox4.Focus();
                textBox4.BackColor = Color.Red;
            }
            double m3;
            if (double.TryParse(textBox5.Text, out m3) && (m3 >= 0))
            {
                textBox5.BackColor = Color.White;
            }
            else
            {
                isErrors = true;
                textBox5.Focus();
                textBox5.BackColor = Color.Red;
            }
            if (int.TryParse(textBox7.Text, out m4) && (m4 >= 0))
            {
                textBox7.BackColor = Color.White;
            }
            else
            {
                isErrors = true;
                textBox7.Focus();
                textBox7.BackColor = Color.Red;
            }
            if (isErrors)
            {
                labelWarning.Text = "Численные параметры заданы некорректно";
            }
            else
            {
                selectingObject.name = textBox1.Text;
                selectingObject.number = m1;
                selectingObject.addres = textBox3.Text;
                selectingObject.countUsers = m2;
                selectingObject.usersPay = m3;
                selectingObject.tarif = textBox6.Text;
                selectingObject.freeLines = m4;
                labelWarning.Text = "";
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode.Text = selectingObject.name;
                    assignValue(treeView1.SelectedNode.Nodes, selectingObject);
                }

            }
        }


        private void buttonGener_Click(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(textBoxGener.Text, out count) && (count >= 0) && (count + collect.Count < int.MaxValue - 100))
            {
                int newCount = collect.Count + count;
                textBoxIndex.BackColor = Color.White;
                for (int i = collect.Count; i < newCount; i++)
                {
                    APS newObject = new APS("name" + i.ToString(), i);
                    collect.Add(newObject);
                }
            }
            else
            {
                textBoxGener.Focus();
                textBoxGener.BackColor = Color.Red;
            }
            textBoxCount.Text = APS.count.ToString();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxIndex.Text, out int index) && (index >= 0) && (index < collect.Count))
            {
                textBoxIndex.BackColor = Color.White;
                //selectingObject = RandomAcces.randomAcces(collect, index);
                selectingObject = collect[index];
                textBox1.Text = selectingObject.name;
                textBox2.Text = selectingObject.number.ToString();
                textBox3.Text = selectingObject.addres;
                textBox4.Text = selectingObject.countUsers.ToString();
                textBox5.Text = selectingObject.usersPay.ToString();
                textBox6.Text = selectingObject.tarif;
                textBox7.Text = selectingObject.freeLines.ToString();
            }
            else
            {
                textBoxIndex.Focus();
                textBoxIndex.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonView_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            foreach (APS item in collect)
            {
                treeView1.Nodes.Add(item.ToString());
                assignValue(treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes, item);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((treeView1.SelectedNode != null) && (treeView1.SelectedNode.Level == 1))
            {
                treeView1.SelectedNode = treeView1.SelectedNode.Parent;
            }
            if ((treeView1.SelectedNode != null) && (treeView1.SelectedNode.Level == 0))
            {
                textBoxIndex.Text = treeView1.SelectedNode.Index.ToString();
                buttonSelect_Click(null, null);
            }
            labelWarning.Text = "";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
        }
    }
}