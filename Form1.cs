using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;

namespace SystemInformationGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetInformation(comboBox1.Text);
        }
        private ArrayList GetInformation(string qry)
        {
            ManagementObjectSearcher searcher;
            int i = 0;
            ArrayList collector = new ArrayList();
            try
            {
                searcher = new ManagementObjectSearcher("select * from " + qry);
                foreach (ManagementObject mo in searcher.Get())
                {
                    i++;
                    PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (PropertyData sp in searcherProperties)
                    {
                        collector.Add(sp);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return collector;
        }
    }
}
